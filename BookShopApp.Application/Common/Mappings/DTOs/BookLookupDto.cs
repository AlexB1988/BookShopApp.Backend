using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain;
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                    opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Name,
                    opt => opt.MapFrom(book => book.Name));
        }
    }
}
