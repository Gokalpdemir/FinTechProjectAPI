using FinTechProjectAPI.Application.Repositories.DefaultCategories;
using MediatR;

namespace FinTechProjectAPI.Application.Features.DefaultCategories.Commands.Create;

public class CreateDefaultCategoryCommandHandler : IRequestHandler<CreateDefaultCategoryCommandRequest, CreateDefaultCategoryCommandResponse>
{
    private readonly IDefaultCategoryWriteRepository _defaultCategoryWriteRepository;

    public CreateDefaultCategoryCommandHandler(IDefaultCategoryWriteRepository defaultCategoryWriteRepository)
    {
        _defaultCategoryWriteRepository = defaultCategoryWriteRepository;
    }

    public async Task<CreateDefaultCategoryCommandResponse> Handle(CreateDefaultCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        bool response = await _defaultCategoryWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Type = request.Type,

        });
        await _defaultCategoryWriteRepository.SaveAsync();
        if (response)
            return new CreateDefaultCategoryCommandResponse { Succeeded = true };
        else
            return new CreateDefaultCategoryCommandResponse { Succeeded = false };
    }
}