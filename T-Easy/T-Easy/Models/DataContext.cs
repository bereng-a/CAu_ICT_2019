using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace T_Easy.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Destination> Destination { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Travel> Travel { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=rds-mariadb-teasy.cjfzscpznbxa.ap-northeast-2.rds.amazonaws.com;port=3306;user=eden;password=toto42sh;database=teasy");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City", "teasy");

                entity.HasIndex(e => e.CountryId)
                    .HasName("Cities_fk0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cities_fk0");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "teasy");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.ToTable("Destination", "teasy");

                entity.HasIndex(e => e.CityId)
                    .HasName("Destinations_fk1");

                entity.HasIndex(e => e.TravelId)
                    .HasName("Destinations_fk0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.Property(e => e.TravelId)
                    .HasColumnName("travel_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Destination)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Destinations_fk1");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.Destination)
                    .HasForeignKey(d => d.TravelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Destinations_fk0");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document", "teasy");

                entity.HasIndex(e => e.EventId)
                    .HasName("Documents_fk3");

                entity.HasIndex(e => e.TravelId)
                    .HasName("Documents_fk0");

                entity.HasIndex(e => e.TypeId)
                    .HasName("Documents_fk2");

                entity.HasIndex(e => e.UserId)
                    .HasName("Documents_fk1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TravelId)
                    .HasColumnName("travel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("Documents_fk3");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.TravelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Documents_fk0");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Documents_fk2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Documents_fk1");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("Document_type", "teasy");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "teasy");

                entity.HasIndex(e => e.DestinationId)
                    .HasName("Events_fk1");

                entity.HasIndex(e => e.TypeId)
                    .HasName("Events_fk0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationId)
                    .HasColumnName("destination_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Events_fk1");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Events_fk0");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("Event_type", "teasy");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction", "teasy");

                entity.HasIndex(e => e.EventId)
                    .HasName("Transactions_fk0");

                entity.HasIndex(e => e.UserId)
                    .HasName("Transactions_fk1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transactions_fk0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transactions_fk1");
            });

            modelBuilder.Entity<Travel>(entity =>
            {
                entity.ToTable("Travel", "teasy");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.SharingCode)
                    .IsRequired()
                    .HasColumnName("sharing_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "teasy");

                entity.HasIndex(e => e.TravelId)
                    .HasName("Users_fk0");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FamilyName)
                    .IsRequired()
                    .HasColumnName("family_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TravelId)
                    .HasColumnName("travel_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TravelId)
                    .HasConstraintName("Users_fk0");
            });
        }
    }
}
