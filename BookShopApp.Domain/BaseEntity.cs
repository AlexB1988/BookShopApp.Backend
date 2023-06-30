using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    // TODO: Не нужна. Доменные модели можно без наследования прописывать, то что id общий это ок, однако name здесь точно лишний.
    // Что если добавится сущность, которая не содержит Name? Смута привнесется
    // PS. Я уже увидел, что такие сущности есть, и это плохой тон, что некоторые сущности у тебя наследуются, а некоторые нет.
    // В целом не вижу смысла в таком наследовании.
    public class BaseEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
