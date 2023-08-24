using CommonTypesLayer.Model;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Model.Dtos.Book
{
    public class BookPutDto:IDto
    {
        public int BookID { get; set; }
        public string? Name { get; set; }
        public string? Writer { get; set; }
        public decimal? Price { get; set; }
        public int? NumberPage { get; set; }
    }
}
