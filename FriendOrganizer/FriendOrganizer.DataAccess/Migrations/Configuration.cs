namespace FriendOrganizer.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizerDbContext context)
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
