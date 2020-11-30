using System.Linq;

namespace ShoppingCart.Application.Interfaces
{
    public interface iCategoriesService
    {
        IQueryable<application.ViewModels.CategoryViewModel> GetCategories();
    }
}