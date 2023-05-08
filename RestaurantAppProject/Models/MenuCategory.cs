using System;
using System.Collections.Generic;

namespace RestaurantAppProject.Models
{
    public partial class MenuCategory
    {
        public int Mcid { get; set; }
        public int? MenuId { get; set; }
        public int? CategoryId { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual CategoryTable? Category { get; set; }
        public virtual MenuTable? Menu { get; set; }
    }
}
