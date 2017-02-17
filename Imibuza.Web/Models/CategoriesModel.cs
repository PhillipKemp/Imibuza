using System.Collections.Generic;
using Imibuza.Domain;
using System.Linq;

namespace Imibuza.Web.Models
{
    public class CategoriesModel
    {
        public static List<CategoryModel> FromDomain(List<string> categories)
        {
            return categories.Select(CategoryModel.FromDomain).ToList();
        }
    }
}