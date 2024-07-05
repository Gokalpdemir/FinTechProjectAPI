using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.DTOs.Category;
using FinTechProjectAPI.Application.Repositories.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;


    public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
    }

    public async Task<bool> CreateAsync(CreateCategoryDto createCategoryDto)
    {
        bool success = await _categoryWriteRepository.AddAsync(new Category { Id = Guid.NewGuid(), Name = createCategoryDto.Name, Type = createCategoryDto.Type });
        await _categoryWriteRepository.SaveAsync();
        if (success)
        {
            return true;
        }
        return false;
    }

    public async Task<List<ListCategoryDto>> GetAllAsync()
    {
        List<ListCategoryDto> response = await _categoryReadRepository.Table.Select(c => new ListCategoryDto
        {
            Id = c.Id.ToString(),
            Name = c.Name,
            Type = c.Type.ToString(),
        }).ToListAsync();
        return response;
    }

    public async Task<List<GetByTypeCategoryDto>> GetByTypeAsync(int type)
    {
      List<GetByTypeCategoryDto> responses =  await _categoryReadRepository.GetWhere(c => ((int)c.Type) == type).Select(c => new GetByTypeCategoryDto
        {
            Id = c.Id.ToString(),
            Name = c.Name,
            Type = (int)c.Type
        }).ToListAsync();

        return responses;
    }
}
