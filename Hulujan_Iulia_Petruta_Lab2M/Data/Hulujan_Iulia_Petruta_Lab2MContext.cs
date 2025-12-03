using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hulujan_Iulia_Petruta_Lab2M.Models;

namespace Hulujan_Iulia_Petruta_Lab2M.Data
{
    public class Hulujan_Iulia_Petruta_Lab2MContext : DbContext
    {
        public Hulujan_Iulia_Petruta_Lab2MContext (DbContextOptions<Hulujan_Iulia_Petruta_Lab2MContext> options)
            : base(options)
        {
        }

        public DbSet<Hulujan_Iulia_Petruta_Lab2M.Models.Book> Book { get; set; } = default!;
        public DbSet<Hulujan_Iulia_Petruta_Lab2M.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Hulujan_Iulia_Petruta_Lab2M.Models.Genre> Genre { get; set; } = default!;
        public DbSet<Hulujan_Iulia_Petruta_Lab2M.Models.Author> Author { get; set; } = default!;
        public DbSet<Hulujan_Iulia_Petruta_Lab2M.Models.Order> Order { get; set; } = default!;
    }
}
