using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CQRS.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public int BookIncomeAmount { get; set; }
        public decimal BookIncomePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public IList<int> Authors { get; set; }
    }
}
