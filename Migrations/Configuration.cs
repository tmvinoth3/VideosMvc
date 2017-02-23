namespace Videos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Videos.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Videos.Models.videoDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Videos.Models.videoDB context)
        {
            context.videos.AddOrUpdate(v => v.title,
                new videos() { title = "mvc", length = 120 },
                new videos() { title = "linq", length = 120 });
            context.SaveChanges();
        }
    }
}
