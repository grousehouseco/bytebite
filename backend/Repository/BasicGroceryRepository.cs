using digital_pantry.Models;
using Microsoft.Extensions.Options;

namespace digital_pantry.Repository;

public class BasicGroceryRepository(IOptions<MongoOptions> options)
    : RepositoryBase<BasicGrocery>(options)
{
    
}