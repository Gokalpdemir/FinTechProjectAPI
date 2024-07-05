using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Features.Categories.Queries.GetByType;

public class GetByTypeCategoryQueryRequest : IRequest<List<GetByTypeCategoryQueryResponse>>
{
    public int Type { get; set; }
}
public class GetByTypeCategoryQueryResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
}
public class GetByTypeCategoryQueryRequestHandler : IRequestHandler<GetByTypeCategoryQueryRequest, List<GetByTypeCategoryQueryResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetByTypeCategoryQueryRequestHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<List<GetByTypeCategoryQueryResponse>> Handle(GetByTypeCategoryQueryRequest request, CancellationToken cancellationToken)
    {
       List<GetByTypeCategoryDto> responses= await  _categoryService.GetByTypeAsync(request.Type);

        return responses.Select(responses => new GetByTypeCategoryQueryResponse
        {
            Id = responses.Id,
            Name = responses.Name,
            Type = responses.Type,
        }).ToList();
    }
}
