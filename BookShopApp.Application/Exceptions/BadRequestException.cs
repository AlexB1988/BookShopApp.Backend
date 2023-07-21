using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string name) :base($"Некорректный зарос: {name}") { }
    }
}
