using System;
using System.Collections.Generic;

namespace RestaurantAppProject.Models
{
    public partial class DishTable
    {
        public DishTable()
        {
            CategoryDishes = new HashSet<CategoryDish>();
        }

        public int DishId { get; set; }
        public string? DishName { get; set; }
        public string? DishDescription { get; set; }
        public decimal? DishPrice { get; set; }
        public string? DishImage { get; set; }
        public string? Nature { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<CategoryDish> CategoryDishes { get; set; }
    }
}
