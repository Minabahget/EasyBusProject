﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EasyBusProject.ViewModels;
using EasyBusProject.Models;

namespace EasyBus.Models
{
    public class MainDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public MainDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<UserSchedule> UserSchedules{ get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.PickUp)
                .WithMany(s => s.TripsAsPickUp)
                .HasForeignKey(t => t.PickUpID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.DropOff)
                .WithMany(s => s.TripsAsDropOff)
                .HasForeignKey(t => t.DropOffID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            //modelBuilder.Entity<UserSchedule>().HasKey(us => new { us.UserId, us.ScheduleId });
            //modelBuilder.Entity<UserSchedule>()
            //    .HasOne(us => us.User)
            //    .WithMany(u => u.UserSchedules)
            //    .HasForeignKey(us => us.UserId);
            //modelBuilder.Entity<UserSchedule>()
            //    .HasOne(us => us.Schedule)
            //    .WithMany(s => s.UserSchedules)
            //    .HasForeignKey(us => us.ScheduleId);

            //modelBuilder.Entity<UserSchedule>()
            //.HasKey(us => new { us.UserId, us.ScheduleId });


            modelBuilder.Entity<Station>().HasData(
                new Station { Id = 1, Name = "Alexandria", City = "Alexandria" },
                new Station { Id = 2, Name = "Beheira", City = "Beheira" },
                new Station { Id = 3, Name = "Bani Suef", City = "Bani Suef" },
                new Station { Id = 4, Name = "Cairo", City = "Cairo" },
                new Station { Id = 5, Name = "Damietta", City = "Damietta" },
                new Station { Id = 6, Name = "Fayoum", City = "Fayoum" },
                new Station { Id = 7, Name = "Giza", City = "Giza" },
                new Station { Id = 8, Name = "Monofiya", City = "Monofiya" },
                new Station { Id = 9, Name = "Port Said", City = "Port Said" },
                new Station { Id = 10, Name = "Tanta", City = "Tanta" }
            );

            modelBuilder.Entity<Bus>().HasData(
                new Bus { Id = 1, Seats = SeatCount.Small, Category = Category.Economy, Model = "Mercedes" },
                new Bus { Id = 2, Seats = SeatCount.Medium, Category = Category.Premium, Model = "Higer" },
                new Bus { Id = 3, Seats = SeatCount.Large, Category = Category.Standard, Model = "BYD" },
                new Bus { Id = 4, Seats = SeatCount.Small, Category = Category.Economy, Model = "MCV" },
                new Bus { Id = 5, Seats = SeatCount.Medium, Category = Category.Premium, Model = "Solaris" },
                new Bus { Id = 6, Seats = SeatCount.Large, Category = Category.Standard, Model = "MCV" },
                new Bus { Id = 7, Seats = SeatCount.Small, Category = Category.Economy, Model = "Toyota" },
                new Bus { Id = 8, Seats = SeatCount.Medium, Category = Category.Premium, Model = "MCV" },
                new Bus { Id = 9, Seats = SeatCount.Large, Category = Category.Standard, Model = "Scania" },
                new Bus { Id = 10, Seats = SeatCount.Small, Category = Category.Economy, Model = "Volvo" },
                new Bus { Id = 11, Seats = SeatCount.Medium, Category = Category.Premium, Model = "MCV" }
            );

            modelBuilder.Entity<Trip>().HasData(
                new Trip { Id = 1, Name ="A", AvailableDays = [WeekDays.Sunday, WeekDays.Monday, WeekDays.Tuesday, WeekDays.Wednesday, WeekDays.Thursday, WeekDays.Friday, WeekDays.Saturday], BusId=1, Time= new TimeOnly(2, 0), Price=200, Duration = 1, PickUpID =1, DropOffID=2 },
                new Trip { Id = 2, Name = "B", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 300, Duration = 2, PickUpID = 2, DropOffID = 3 },
                new Trip { Id = 3, Name = "C", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 400, Duration = 1, PickUpID = 3, DropOffID = 4 },
                new Trip { Id = 4, Name = "D", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 500, Duration = 2, PickUpID = 4, DropOffID = 5 },
                new Trip { Id = 5, Name = "E", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 100, Duration = 1, PickUpID = 5, DropOffID = 6 },
                new Trip { Id = 6, Name = "F", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 200, Duration = 2, PickUpID = 6, DropOffID = 7 },
                new Trip { Id = 7, Name = "G", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 300, Duration = 1, PickUpID = 7, DropOffID = 8 },
                new Trip { Id = 8, Name = "H", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 400, Duration = 2, PickUpID = 8, DropOffID = 9 },
                new Trip { Id = 9, Name = "I", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 500, Duration = 1, PickUpID = 9, DropOffID = 10 },
                new Trip { Id = 10, Name = "J", AvailableDays = [WeekDays.Sunday, WeekDays.Monday], BusId = 1, Time = new TimeOnly(2, 0), Price = 600, Duration = 2, PickUpID = 10, DropOffID = 9 }
            );

        }
        public DbSet<EasyBusProject.ViewModels.RegisterUserVM> RegisterUserVM { get; set; } = default!;
        public DbSet<EasyBusProject.ViewModels.LoginUserVM> LoginUserVM { get; set; } = default!;
        public DbSet<EasyBusProject.ViewModels.DetailsOfReservedTripVM> DetailsOfReservedTripVM { get; set; } = default!;

    }
}
