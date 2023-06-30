using AutoMapper;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography;
using BookShopApp.Domain;
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
        // TODO: На создание айдишник не нужен, он сам сгенерится (если ты указал в конфигураторе)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

    }
}
