using MediatR;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Delete
{
    public class DeletePublisherCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
