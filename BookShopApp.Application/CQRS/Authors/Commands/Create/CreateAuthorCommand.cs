using MediatR;

namespace BookShopApp.Application.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
