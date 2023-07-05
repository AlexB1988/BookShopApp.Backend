using MediatR;

namespace BookShopApp.Application.CQRS.Books.Commands.Delete
{
    public class DeleteBookCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
