using CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Model.Dtos.Category
{
    public class CategoryPostDto : IDto
    {
        public String? CategoryName { get; set; }
        public String? Description { get; set; }
    }
}
