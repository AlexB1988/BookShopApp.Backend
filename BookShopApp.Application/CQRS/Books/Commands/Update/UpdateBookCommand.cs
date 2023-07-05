using BookShopApp.Domain;
using MediatR;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Books.Commands.Update
{
    public class UpdateBookCommand:IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public IList<int> Authors { get; set; }
    }
}
