using BookShopApp.Application.Common.Mappings.DTOs;
using MediatR;


namespace BookShopApp.Application.CQRS.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery:IRequest<BookLookupDto>
    {
        public int Id { get; set; }
    }
}
