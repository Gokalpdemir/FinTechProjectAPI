using FinTechProjectAPI.Application.Abstractions.Services;
using MediatR;

namespace FinTechProjectAPI.Application.Features.AppUsers.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
          var result= await _userService.CreateUserAsync(new() { Email=request.Email,NameSurname=request.NameSurname,Password=request.Password,PasswordConfirm=request.PasswordConfirm,UserName=request.UserName});

            return new CreateUserCommandResponse()
            {
                IsSuccess = result
            };
        }
    }
}
