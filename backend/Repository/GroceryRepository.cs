using digital_pantry.Models;
using Microsoft.Extensions.Options;

namespace digital_pantry.Repository;

public class GroceryRepository(IOptions<MongoOptions> options)
    : RepositoryBase<Grocery>(options)
{
    
}