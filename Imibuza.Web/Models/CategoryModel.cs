using Imibuza.Domain;

namespace Imibuza.Web.Models
{
    public class CategoryModel
    {
        public static CategoryModel FromDomain(string category)
        {
            return new CategoryModel
            {
                Title = category
            };
        }

        public string Title { get; set; }
    }
}