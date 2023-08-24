using CommonTypesLayer.Model;
using MK.Model.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Model.Dtos.Category
{
    public class CategoryGetDto : IDto
    {
        public int CategoryID { get; set; }
        public String? CategoryName { get; set; }
        public String? Description { get; set; }
        public List<BookGetDto>? Books { get; set; }

    }
}
