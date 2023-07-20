using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.Authors.Commands.Create
{
    // TODO: Есть некоторые замечания по поводу структуры и названию папок в Application.
    // Папку CQRS лучше обзвови как Usecases, папка Common вообще не нужна, ее содержимое должно просто валяться в Application. Лишний уровень вложенности нет необходимости городить.


    public class CreateAuthorCommand : IRequest<int>,IMapWith<Author> // Пробел между интерфейсами. IRequest<int>, IMapWith<Author>
    {
        public string Name { get; set; }  // Между свойствами пустая строка должна быть. Сейчас исправлено мной.

        public string Biography { get; set; }

        // TODO: Хэндлер можно класть прям сюда. Так гораздо удобнее, когда у тебя и команда и хэндлер в одном файле.
        // Вот тут и пишешь: private class Handler : IRequestHandler... {}

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorCommand, Author>()
                .ForMember(author => author.Name,
                    opt => opt.MapFrom(authorCommand => authorCommand.Name))
                .ForMember(author => author.Biography,
                    opt => opt.MapFrom(authorCommand => authorCommand.Biography)); 
        }
    }
}
