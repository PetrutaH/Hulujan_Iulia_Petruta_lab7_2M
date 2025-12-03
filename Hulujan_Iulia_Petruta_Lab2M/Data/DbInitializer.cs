using Microsoft.EntityFrameworkCore;
using Hulujan_Iulia_Petruta_Lab2M.Models;

namespace Hulujan_Iulia_Petruta_Lab2M.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Hulujan_Iulia_Petruta_Lab2MContext
           (serviceProvider.GetRequiredService
            <DbContextOptions<Hulujan_Iulia_Petruta_Lab2MContext>>()))
            {
                if (context.Book.Any())
                {
                    return; // BD a fost creata anterior
                }
                //context.Book.AddRange(
                //new Book
                //{
                //    Title = "Baltagul",
                //    Author = "Mihai Sadoveanu",
                //    Price = Decimal.Parse("22")
                //},

                //new Book
                //{
                //    Title = "Enigma Otiliei",
                //    Author = "George Calinescu",
                //    Price = Decimal.Parse("18")
                //},

                //new Book
                //{
                //    Title = "Maytrei",
                //    Author = "Mircea Eliade",
                //    Price = Decimal.Parse("27")
                //}
                //);

                //context.Genre.AddRange(
                //    new Genre { Name = "Roman" },
                //    new Genre { Name = "Nuvela" },
                //    new Genre { Name = "Poezie" }
                //    );
                //context.Customer.AddRange(
                //    new Customer { Name = "Popescu Marcela", Adress = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01") },
                //    new Customer { Name = "Mihailescu Cornel", Adress = "Str. Bucuresti, nr.45, ap. 2", BirthDate = DateTime.Parse("1969-07-08") }
                //    );
                //context.SaveChanges();
            }
        }
    }
}
