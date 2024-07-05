using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.DTOs.Category;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
       bool success= await _categoryService.CreateAsync(new CreateCategoryDto { Name=request.Name,Type=request.Type});
        if (success)
        {
            return new CreateCategoryCommandResponse { Succeeded = true };
        }
        return new CreateCategoryCommandResponse { Succeeded= false };

    }
}
