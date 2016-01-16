using FlightNode.DataCollection.Infrastructure.Customization;

namespace FlightNode.DataCollection.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.OleDb;
    public sealed class Configuration : DbMigrationsConfiguration<FlightNode.DataCollection.Infrastructure.Persistence.DataCollectionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(FlightNode.DataCollection.Infrastructure.Persistence.DataCollectionContext context)
        {
            
        }
    }
}