using Microsoft.EntityFrameworkCore;
using Models.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Context : DbContext
    {
        // .NET CLI
        // dotnet ef migrations add [Nombre de migracion]
        // dotnet ef database update

        // public virtual DbSet<ObjectClass> Object { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<UserRol> UserRols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"server={Environment.GetEnvironmentVariable("DATABASE_HOST")};port={Environment.GetEnvironmentVariable("DATABASE_PORT")}; database=ayudamigrante-DEBUG; user={Environment.GetEnvironmentVariable("DATABASE_ACCOUNT")}; password={Environment.GetEnvironmentVariable("DATABASE_PASSWRD")}",  new MySqlServerVersion(new Version(5, 7, 32)));

// #if DEBUG
//             optionsBuilder.UseMySql($"server={Environment.GetEnvironmentVariable("DATABASE_HOST")}; port={Environment.GetEnvironmentVariable("DATABASE_PORT")}; database=ayudamigrante-DEBUG; user={Environment.GetEnvironmentVariable("DATABASE_ACCOUNT")}; password={Environment.GetEnvironmentVariable("DATABASE_PASSWRD")}", ServerVersion.AutoDetect($"server={Environment.GetEnvironmentVariable("DATABASE_HOST")}; port={Environment.GetEnvironmentVariable("DATABASE_PORT")}; database=ayudamigrante-DEBUG; user={Environment.GetEnvironmentVariable("DATABASE_ACCOUNT")}; password={Environment.GetEnvironmentVariable("DATABASE_PASSWRD")}"), null);
// #else
//             optionsBuilder.UseMySQL($"server={Environment.GetEnvironmentVariable("DATABASE_HOST")}; port={Environment.GetEnvironmentVariable("DATABASE_PORT")}; database=ayudamigrante-PROD; user={Environment.GetEnvironmentVariable("DATABASE_ACCOUNT")}; password={Environment.GetEnvironmentVariable("DATABASE_PASSWRD")}", ServerVersion.AutoDetect($"server={Environment.GetEnvironmentVariable("DATABASE_HOST")}; port={Environment.GetEnvironmentVariable("DATABASE_PORT")}; database=ayudamigrante-PROD; user={Environment.GetEnvironmentVariable("DATABASE_ACCOUNT")}; password={Environment.GetEnvironmentVariable("DATABASE_PASSWRD")}"), null);
// #endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Account>().HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<Comment>().ToTable("Comment");

            modelBuilder.Entity<Post>().ToTable("Post").HasMany(x => x.Likes);
            modelBuilder.Entity<Post>().ToTable("Post").HasMany(x => x.Comments);

            modelBuilder.Entity<Profile>().ToTable("Profile");
            modelBuilder.Entity<Session>().ToTable("Session");
            modelBuilder.Entity<UserRol>().ToTable("UserRol");

            SeedUserRols(modelBuilder);
            SeedAccount(modelBuilder);

            // modelBuilder.Entity<IOTDevice>().ToTable("IOTDevice");
            // modelBuilder.Entity<IOTDevice>().HasIndex(x => x.MacAddress).IsUnique();
            // SeedIOTDevice(modelBuilder);
            // 
            // modelBuilder.Entity<IOTDevice>().ToTable("IOTDevice");
        }

        private void SeedAccount(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    IDAccount = "38B9F907-5961-4589-90E8-9EC020B7D40D",
                    Email = "angel.g.j.reyes@gmail.com",
                    PasswordHash = Codebehind.Security.SHA256Hash("Angel100"),
                    IDUserRol = "38B9F907-5961-4589-90E8-9EC020B7D40D",
                    CreatedAt = DateTime.UtcNow,
                    IsVerified = true,
                    RequirePasswordReset = false
                }
            );
        }

        private void SeedUserRols(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserRol>().HasData(
                new UserRol {
                    IDUserRol = "38B9F907-5961-4589-90E8-9EC020B7D40D",
                    UserLevel = 10,
                    UserRolName = "Voluntario",
                    UserRolPermisions = "Permiso a interactuar como voluntario en la plataformaº"
                },
                new UserRol {
                    IDUserRol = "74F61449-AFA3-4D38-BBDE-4CE2600732D6",
                    UserLevel = 0,
                    UserRolName = "Migrante",
                    UserRolPermisions = "Permiso a interactuar como migrante en la plataformaº"
                }
            );
        }

        // private void SeedIOTDevice(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<IOTDevice>().HasData(
        //         new IOTDevice { IDDevice = "38B9F907-5961-4589-90E8-9EC020B7D40D", MacAddress = "47-1D-44-CB-BF-05", IPAddress = "192.168.31.99", DataType = "float", DeviceType = "water_level_sensor", DeviceName = "Sensor Nivel de Agua", DeviceStatus = "Online", MeasurementUnit = "%", FirmwareVersion = "1.0.1" },
        //         new IOTDevice { IDDevice = "74F61449-AFA3-4D38-BBDE-4CE2600732D6", MacAddress = "01-2F-7A-93-A3-46", IPAddress = "192.168.31.100", DataType = "float", DeviceType = "water_level_sensor", DeviceName = "Sensor Nivel de Agua", DeviceStatus = "Online", MeasurementUnit = "%", FirmwareVersion = "1.0.1" }
        //     );
        // }
    }
}
