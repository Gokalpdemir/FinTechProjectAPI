using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.DTOs.Category;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Categories.Queries.GetAll;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
{
    private readonly ICategoryService _categoryService;

    public GetAllCategoryQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
       List<object> response= await _categoryService.GetAllAsync();

        return new GetAllCategoryQueryResponse()
        {
            allCategories = response
        };
        
       //return  response.Select(response => new GetAllCategoryQueryResponse
       // {
       //     Id= response.Id,
       //     Name= response.Name,
       //     Type= response.Type,
       // }).ToList();

     
    }
}
