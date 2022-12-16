namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(f => f.FirstName,
                new Model.Friend { FirstName = "Błażej", LastName = "Domagała" },
                new Model.Friend { FirstName = "Andreas", LastName = "Boehler" },
                new Model.Friend { FirstName = "Julia", LastName = "Huber" },
                new Model.Friend { FirstName = "Chrissi", LastName = "Boehler" }
                );
        }
    }
}
