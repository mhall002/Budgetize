using BudgetSplit.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetSplit.New.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Import> Imports { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}