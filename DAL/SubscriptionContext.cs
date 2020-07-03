using LandingPageSignup.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LandingPageSignup.DAL
{
    public class SubscriptionContext : DbContext
    {
        public SubscriptionContext() : base("SubscriptionContext")
        {
        }

        public DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}