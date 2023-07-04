using AutoMapper;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.Common.Mappings.DTOs
{
    public class BookLookupDto : IMapWith<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public IList<AuthorLookupDto> Authors { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                    opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Name,
                    opt => opt.MapFrom(book => book.Name))
                .ForMember(bookDto => bookDto.Year,
                    opt => opt.MapFrom(book => book.Year))
                .ForMember(bookDto => bookDto.Publisher,
                    opt => opt.MapFrom(book => book.Publisher.Name))
                .ForMember(bookDto => bookDto.Price,
                    opt => opt.MapFrom(book => book.Price
                                        .FirstOrDefault(price=>price.DateEnd==null).Price));
        }//////////Нужно смаппить список авторов
    }
}
