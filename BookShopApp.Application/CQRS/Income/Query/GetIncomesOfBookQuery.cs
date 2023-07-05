using MediatR;

namespace BookShopApp.Application.CQRS.Income.Query
{
    public class GetIncomesOfBookQuery : IRequest<GetIncomesOfBookViewModel>
    {
        public int BookId { get; set; }
    }
}
