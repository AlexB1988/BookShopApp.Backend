using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;

namespace BookShopApp.Application
{
    public class Seed
    {

        private IDataContext _dataContext;
        
        public Seed(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedDataContext()
        {
            if(!_dataContext.Books.Any())
            {
                var bookAuthors=new List<BookAuthor>
                {
                    new BookAuthor
                    {
                        Book=new Book
                        {
                            Name="Report",
                            Year=2022,
                            Amount=new BookCurrentAmount(){CurrentAmount=35},
                            Publisher=new Publisher{Name="Moscow",YearBegin=1990,City="Moscow"},
                            Prices =new List<BookPrice> { new BookPrice { Price=2000} },
                            Incomes=new List<BookIncome> { new BookIncome { Amount=35,IncomePrice=1500} }
                        },
                        Author=new Author { Name="Pushkin",Biography=""}
                    },
                    new BookAuthor
                    {
                        Book = new Book
                        {
                            Name = "Fantastic",
                            Year = 2000,
                            Amount = new BookCurrentAmount() { CurrentAmount = 20 },
                            Publisher = new Publisher { Name = "Piter", YearBegin = 1999, City = "Piter" },
                            Prices = new List<BookPrice> { new BookPrice { Price = 2500.56M } },
                            Incomes = new List<BookIncome> { new BookIncome { Amount = 35, IncomePrice = 1500 } }
                        },
                        Author = new Author { Name = "Gorin", Biography = "" }
                    }
                };

                _dataContext.BookAuthors.AddRange(bookAuthors);
                _dataContext.SaveChanges();
            }
        }
    }
}
