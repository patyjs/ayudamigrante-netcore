using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseMySQL("server=localhost; port=3306; database=Superintendent-DEBUG; user=root; password=doodlebundle");
#else
            optionsBuilder.UseMySQL("server=localhost; port=3306; database=Superintendent-PROD; user=root; password=Ragnarok1");
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<IOTDevice>().ToTable("IOTDevice");
            // modelBuilder.Entity<IOTDevice>().HasIndex(x => x.MacAddress).IsUnique();
            // SeedIOTDevice(modelBuilder);
            // 
            // modelBuilder.Entity<IOTDevice>().ToTable("IOTDevice");
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
