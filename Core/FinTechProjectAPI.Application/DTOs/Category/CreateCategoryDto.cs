using FinTechProjectAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.DTOs.Category;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }
}
