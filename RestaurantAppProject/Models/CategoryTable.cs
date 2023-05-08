using System;
using System.Collections.Generic;

namespace RestaurantAppProject.Models
{
    public partial class CategoryTable
    {
        public CategoryTable()
        {
            CategoryDishes = new HashSet<CategoryDish>();
            MenuCategories = new HashSet<MenuCategory>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? CategoryImage { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<CategoryDish> CategoryDishes { get; set; }
        public virtual ICollection<MenuCategory> MenuCategories { get; set; }
    }
}
