using CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Model.Entities
{
    public class Book:IEntity
    {
        public int BookID { get; set; }
        public string? Name { get; set; }
        public string? Writer { get; set; }
        public decimal? Price { get; set; }
        public int? NumberPage { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
