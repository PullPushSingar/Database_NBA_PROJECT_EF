using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static NBA_GAMES_SCHEDULE.Models.UserMessage;

namespace NBA_GAMES_SCHEDULE.Models
{
    public partial class MVCDBcontext : DbContext
    {
        public MVCDBcontext()
        {
        }

        public DbSet<UserMessage> UserMessages { get; set; }

        public MVCDBcontext(DbContextOptions<MVCDBcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-HR5LKTM;Database=NBA_Player_Stats;Trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId)
                    .ValueGeneratedNever()
                    .HasColumnName("TeamID");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Coach).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

   

            });


            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PlayerID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);


            });

 
            modelBuilder.Entity<Match>(entity =>
            {


                entity.Property(e => e.MatchId)
                    .ValueGeneratedOnAdd() 
                    .HasColumnName("MatchID");

                entity.Property(e => e.Date)
                    .HasColumnType("date") 
                    .HasColumnName("Date"); 

                entity.Property(e => e.Time)
                    .HasColumnType("time") 
                    .HasColumnName("Time"); 

                entity.Property(e => e.Location)
                    .HasMaxLength(100) 
                    .HasColumnName("Location"); 

                entity.Property(e => e.HomeTeamId)
                    .HasColumnName("HomeTeamId"); 

                entity.Property(e => e.AwayTeamId)
                    .HasColumnName("AwayTeamId");

                entity.HasOne(m => m.HomeTeam)
                    .WithMany(t => t.HomeMatches) 
                    .HasForeignKey(m => m.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne(m => m.AwayTeam)
                    .WithMany(t => t.AwayMatches) 
                    .HasForeignKey(m => m.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict); 
            });













    


            OnModelCreatingPartial(modelBuilder);
           
            }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
