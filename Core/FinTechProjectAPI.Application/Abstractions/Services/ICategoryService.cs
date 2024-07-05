using FinTechProjectAPI.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Abstractions.Services;

public interface ICategoryService
{
    Task<bool> CreateAsync(CreateCategoryDto createCategoryDto);
    Task<List<ListCategoryDto>> GetAllAsync();
    Task<List<GetByTypeCategoryDto>> GetByTypeAsync(int type);
}
