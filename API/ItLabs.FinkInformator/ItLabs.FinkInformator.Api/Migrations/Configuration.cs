namespace ItLabs.FinkInformator.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ItLabs.FinkInformator.Api.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ItLabs.FinkInformator.Api.Models.SchoolContext context)
        {
            
        }
    }
}
