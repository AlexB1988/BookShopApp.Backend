﻿using AutoMapper;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;

namespace BookShopApp.Application.CQRS.Sales.Command.Create
{
    public class CreateSaleViewModel : IMapWith<Sale>
    {
        public int BookId { get; set; }
       
        public int Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSaleViewModel, Sale>()
                .ForMember(sale => sale.BookId,
                    opt => opt.MapFrom(saleCreate => saleCreate.BookId))
                .ForMember(sale => sale.Amount,
                    opt => opt.MapFrom(saleCreate => saleCreate.Amount));
        }
    }
}