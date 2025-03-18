using System.Text.Json;
using CoreLib.Models;
using CoreLib.Services;
using CoreLib.ServiceUtils;
using GroceryLibrary.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace GroceryLibrary;

public class GroceryService(IOptions<MongoOptions> options, IMediator mediator, HttpClient httpClient)
{
    private const string OpenFoodFactsUrl = "https://world.openfoodfacts.org/api/v2/search?code={0}";
    private readonly RepositoryBase<BasicGrocery> _basicGroceryRepo = new RepositoryBase<BasicGrocery>(options);
    private readonly RepositoryBase<Grocery> _groceryRepo = new RepositoryBase<Grocery>(options);

    public async Task<Grocery?> GetGroceryByUpc(string upc)
    {
        if(string.IsNullOrEmpty(upc)) return null;
        var res = (await _groceryRepo.GetByNamedParamAsync("Id", upc))?.FirstOrDefault();
        if (res is not null) return res;
        var groceryItem = (await GetOpenFoodItem(upc))?.Products[0];
        if (groceryItem is null) return null;
        await _groceryRepo.AddOrReplaceAsync(groceryItem);
        return groceryItem;
    }

    public async Task<List<BasicGrocery>?> GetBasicGroceryByKeyword(string keywords)
    {
        if (string.IsNullOrEmpty(keywords)) return null;
        var allBasicGroceries = await _basicGroceryRepo.GetAsync();
        var keywordList = keywords.Split(',').Select(x => x.Trim()).ToArray();
        List<BasicGrocery> filteredList = [];
        foreach (var keyword in keywordList)
        {
            // find the first match, then keep going
            var match = allBasicGroceries.FirstOrDefault(g => g.Description.Select(d => d.ToLowerInvariant())
                .Contains(keyword.ToLowerInvariant()));
            if (match is null) continue;
            filteredList.Add(match);
        }
        return filteredList;
    }

    private async Task<OpenFoodResponse?> GetOpenFoodItem(string upc)
    {
        var httpResponse = await httpClient.GetAsync(string.Format(OpenFoodFactsUrl, upc));
        return !httpResponse.IsSuccessStatusCode ? null : JsonSerializer.Deserialize<OpenFoodResponse>(await httpResponse.Content.ReadAsStringAsync());
    }
    
}