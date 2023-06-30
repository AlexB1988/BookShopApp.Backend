using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: В проекте Domain надо создать папку Entities и все домменные модели перетащить в нее. (Укажи вижле чтоб автоматом пространства имен изменила) 
// TODO: Ненужные юзинги сверху надо убирать. Они подсвечисваются серым цветом. В данном случае ни один из юзингов не нужен.

namespace BookShopApp.Domain
{
    public class Author: BaseEntity  // TODO: Пробелы до и после двоеточния (Author : BaseEntity)
    {
        public string Biography { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }

        // TODO: Вижла тебе подчеркивает зеленой волнистой линией поля, которые могут быть null. 
        // Это NullReferenceTypes. Погугли, изучи, и либо применяй этот подход, либо в файле прожекта отруби эту настройку. (<Nullable>enable</Nullable> удаляй эту строку)
    }
}
