using MediatR;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList
{
    // TODO: Также слишком усложненный кейс.
    // Папка просто GetList, она у тебя лежит в Authors, то есть и так понятно что ты получаешь лист авторов, а не потолков.
    // Дальше, возвращать из комманды лучше коллецию. Сейчас у тебя два класса: дто и вью модель, и одно содержится в другом. 
    // В некоторых ситуациях такой подход имеет место быть, но в твоем случае можно сделать проще.
    // Пишешь просто AuthorViewModel, там у тебя поля Id, Name. А из комманды возвращаешь ICollection<AuthorViewModel>.

    public class GetAuthorListQuery:IRequest<AuthorListViewModel>
    {
    }
}
