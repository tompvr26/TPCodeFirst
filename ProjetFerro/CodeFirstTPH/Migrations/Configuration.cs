namespace CodeFirstTPH.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstTPH.ContextBDD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstTPH.ContextBDD context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Mammiferes.AddOrUpdate(new Mammifere
            {
                ID = 1,
                ADesDents = true,
                AquatiqueStrict = true,
                Espece = "Sapiens",
                Genre = "Homo",
                Femelle = true,
                Male = false,
            });
            context.Oiseaux.AddOrUpdate(new Oiseau
            {
                ID = 2,
                Espece = "Rissa",
                Genre = "Trydactyla",
                Femelle = true,
                Male = false,
                DateDeNaissance = DateTime.Now,
                SaitVoler = true
            });
        }
    }
}
