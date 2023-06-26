﻿using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookDetail
{
    public class BookViewModel:IMapWith<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string PublisherName { get; set; }
        public decimal Price { get; set; }
        //public IList<int> Authors { get; set; } //Реализовать маппинг листа авторов

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookViewModel>()
                .ForMember(bookVm => bookVm.Id,
                    opt => opt.MapFrom(book => book.Id))
                .ForMember(bookvm => bookvm.Name,
                    opt => opt.MapFrom(book => book.Name))
                .ForMember(bookVm => bookVm.Year,
                    opt => opt.MapFrom(book => book.Year))
                .ForMember(bookVm => bookVm.PublisherName,
                    opt => opt.MapFrom(book => book.Publisher.Name))
                .ForMember(bookDto => bookDto.Price,
                    opt => opt.MapFrom(book => book.Price.Where(book => book.Id == Id && book.DateEnd == null).FirstOrDefault()));
            //.ForMember(bookVm => bookVm.Authors,
            //    opt => opt.MapFrom(book => book.BookAuthors
            //            .Where(book=>book.BookId==Id).Select(author=>author.AuthorId).ToList()));
        }
    }
}
