using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ImportContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hamster>().HasData(ImportFromCsv.CSVToList());
            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, Name = "Arrived" },
                new Activity { Id = 2, Name = "Exercise" },
                new Activity { Id = 3, Name = "Cage" },
                new Activity { Id = 4, Name = "Left" });
            modelBuilder.Entity<AreaType>().HasData(
                new AreaType { Id = 1, Name = "Cage" },
                new AreaType { Id = 2, Name = "Exercise" });
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Available" },
                new Status { Id = 2, Name = "Unavailable" });
            modelBuilder.Entity<Area>().HasData(
                new Area { Id = 1, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 2, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 3, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 4, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 5, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 6, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 7, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 8, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 9, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 10, AreaTypeId = 1, StatusId = 1, Capacity = 3 },
                new Area { Id = 11, AreaTypeId = 2, StatusId = 1, Capacity = 6 }
                );
        }
    }
}
