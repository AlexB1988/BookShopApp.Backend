using AutoMapper;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
