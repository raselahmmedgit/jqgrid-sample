using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.JQGridSample.ViewModels
{
    public class CategoryGridModels
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
    }

    public class ProductGridModels
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}