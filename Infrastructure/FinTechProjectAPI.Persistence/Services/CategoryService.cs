using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.DTOs.Category;
using FinTechProjectAPI.Application.DTOs.DefaultCategory;
using FinTechProjectAPI.Application.Exceptions;
using FinTechProjectAPI.Application.Repositories.Categories;
using FinTechProjectAPI.Application.Repositories.DefaultCategories;
using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Domain.Entities.Identity;
using FinTechProjectAPI.Persistence.Repositories.DefaultCategories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly UserManager<AppUser> _userManager;
    private readonly IDefaultCategoryReadRepository _defaultCategoryReadRepository;



    public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager, IDefaultCategoryReadRepository defaultCategoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _contextAccessor = contextAccessor;
        _userManager = userManager;
        _defaultCategoryReadRepository = defaultCategoryReadRepository;
    }

    public async Task<bool> CreateAsync(CreateCategoryDto createCategoryDto)
    {
        AppUser user = await ContextUser();
        if(user == null)
        {
          throw new UserNotFoundException();

        }
        bool success = await _categoryWriteRepository.AddAsync(new Category { Id = Guid.NewGuid(), Name = createCategoryDto.Name, Type = createCategoryDto.Type, AppUserId = user.Id });
        await _categoryWriteRepository.SaveAsync();
        if (success)
        {
            return true;
        }
        return false;
    }

    public async Task<List<object>> GetAllAsync()
    {
        AppUser user = await ContextUser();


        List<ListDefaultCategoryDto> defaultCategories =  _defaultCategoryReadRepository.GetAll().Select(dc => new ListDefaultCategoryDto
        {
            Id = dc.Id.ToString(),
            Name = dc.Name,
            Type = dc.Type.ToString()
        }).ToList();


        List<ListCategoryDto> response = await _categoryReadRepository.Table.Include(c => c.AppUser).Select(c => new ListCategoryDto
        {
            Id = c.Id.ToString(),
            Name = c.Name,
            Type = c.Type.ToString()

        }).ToListAsync();

        List<object> allCategories = new List<Object>();
        allCategories.AddRange(defaultCategories);
        allCategories.AddRange(response);



        return allCategories;
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


    private async Task<AppUser>  ContextUser()
    {
        var userName = _contextAccessor?.HttpContext?.User?.Identity?.Name;
        AppUser? user = await _userManager.FindByNameAsync(userName);
        if (user != null)
        {
            return user;
        }

        throw new Exception("User Not Found");
    }

}
