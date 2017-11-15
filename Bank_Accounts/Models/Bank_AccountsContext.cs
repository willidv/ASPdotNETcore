using Microsoft.EntityFrameworkCore;
 
namespace Bank_Accounts.Models
{
    public class Bank_AccountsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Bank_AccountsContext(DbContextOptions<Bank_AccountsContext> options) : base(options) { }
        public DbSet<Bank_Account> Bank_Accounts { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<TransactionModel> Transactions {get; set;}
    }
}