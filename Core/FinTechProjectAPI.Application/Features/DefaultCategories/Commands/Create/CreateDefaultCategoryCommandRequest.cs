using FinTechProjectAPI.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Features.DefaultCategories.Commands.Create;


public class CreateDefaultCategoryCommandRequest : IRequest<CreateDefaultCategoryCommandResponse>
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }
}
