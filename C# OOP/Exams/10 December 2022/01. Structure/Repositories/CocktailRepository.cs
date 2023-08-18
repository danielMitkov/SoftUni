using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;
namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository:IRepository<ICocktail>
    {
        private List<ICocktail> models;
        public IReadOnlyCollection<ICocktail> Models => models.AsReadOnly();
        public void AddModel(ICocktail model)
        {
            models.Add(model);
        }
    }
}