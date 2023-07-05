using MediatR;

namespace BookShopApp.Application.CommandsQueries.Authors.Commands.Delete
{
    public class DeleteAuthorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
