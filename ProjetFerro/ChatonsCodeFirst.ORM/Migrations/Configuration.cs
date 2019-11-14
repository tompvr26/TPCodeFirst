namespace ChatonsCodeFirst.ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChatonsCodeFirst.ORM.ContextBDD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ChatonsCodeFirst.ORM.ContextBDD context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Categorie.AddOrUpdate(new Categorie()
            {
                Id = 1,
                Nom = "Mignons",
                Description = "Les chatons les plus mignons"
            });
        }
    }
}
