﻿using AutoMapper;

namespace BookShopApp.Application.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}