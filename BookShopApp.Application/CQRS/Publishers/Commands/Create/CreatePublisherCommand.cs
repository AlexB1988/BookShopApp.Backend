using MediatR;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Create
{
    public class CreatePublisherCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int YearBegin { get; set; }
    }
}
