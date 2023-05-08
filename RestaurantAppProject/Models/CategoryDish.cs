using System;
using System.Collections.Generic;

namespace RestaurantAppProject.Models
{
    public partial class CategoryDish
    {
        public int Cdid { get; set; }
        public int? CategoryId { get; set; }
        public int? DishId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual CategoryTable? Category { get; set; }
        public virtual DishTable? Dish { get; set; }
    }
}
