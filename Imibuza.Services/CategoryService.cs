using System;
using System.Collections.Generic;
using System.Linq;
using Imibuza.Domain;
using Imibuza.Domain.Enums;

namespace Imibuza.Services
{
    public class CategoryService
    {
        public List<string> GetAllCategories()
        {
            var categories = new List<string>();
            foreach (CategoriesEnum category in Enum.GetValues(typeof(CategoriesEnum)))
            {
                categories.Add(category.ToString());
            }

            return categories.OrderBy(i => i).ToList();
        }
    }
}