using FinTechProjectAPI.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandRequest:IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }
}
