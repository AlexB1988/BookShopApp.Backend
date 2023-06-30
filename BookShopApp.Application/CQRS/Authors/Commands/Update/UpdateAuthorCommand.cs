using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Authors.Commands.Update
{
    public class UpdateAuthorCommand:IRequest<Unit>
    {
        // TODO: Пихаешь команду в аргумент методу контроллера, здесь ставишь аттрибут [JsonIgnore] из NewtonsoftJson над айди. Там отдельным параметром айдишник прописываешь и присваиваешь.
        // Привел пример в контроллере.

        // [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
