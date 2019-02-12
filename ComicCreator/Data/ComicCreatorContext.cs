using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ComicCreator.Models
{
    public class ComicCreatorContext : DbContext
    {
        public ComicCreatorContext (DbContextOptions<ComicCreatorContext> options)
            : base(options)
        {
        }

        public DbSet<Title> Titles { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Panel> Panels { get; set; }
        public DbSet<PanelText> PanelTexts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add custom schema for music DB
            modelBuilder.HasDefaultSchema("MU");
        }

    }
}
