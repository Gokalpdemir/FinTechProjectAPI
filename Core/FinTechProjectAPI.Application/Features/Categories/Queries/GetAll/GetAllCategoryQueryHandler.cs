using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.DTOs.Category;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Categories.Queries.GetAll;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetAllCategoryQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
       List<ListCategoryDto> response= await _categoryService.GetAllAsync();
        
       return  response.Select(response => new GetAllCategoryQueryResponse
        {
            Id= response.Id,
            Name= response.Name,
            Type= response.Type,
        }).ToList();

     
    }
}
