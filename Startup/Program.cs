﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Persistence;
using PersistenceRepository;
using System.Linq;
using System.Collections.Generic;
using PersistenceModel;

namespace Startup
{
    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory
                = LoggerFactory.Create(builder => { builder.AddConsole(); });

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("Sqlserver");
            Console.WriteLine(connectionString);
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseSqlServer(connectionString)
                   //.EnableSensitiveDataLogging()
                   .UseLoggerFactory(MyLoggerFactory)
                   //.UseLoggerFactory(loggerFactory) //Optional, this logs SQL generated by EF Core to the Console
                   .Options;

            var masterfacility = new List<Facility>(){
                new Facility{ 
                    Name = "Badminton Court",
                    MemberCost = 60,
                    GustCost = 25,
                    Initialoutlay = 8000,
                    MonthlyMaintenance = 100
                },
                new Facility{ 
                    Name = "Table Tennis",
                    MemberCost = 50,
                    GustCost = 15,
                    Initialoutlay = 5000,
                    MonthlyMaintenance = 100
                },
                new Facility{ 
                    Name = "Massage Room",
                    MemberCost = 180,
                    GustCost = 25,
                    Initialoutlay = 18000,
                    MonthlyMaintenance = 500
                },
                new Facility{ 
                    Name = "Squash Court",
                    MemberCost = 600,
                    GustCost = 25,
                    Initialoutlay = 10000,
                    MonthlyMaintenance = 400
                },
                new Facility{ 
                    Name = "Snooker Table",
                    MemberCost = 50,
                    GustCost = 25,
                    Initialoutlay = 3000,
                    MonthlyMaintenance = 100
                },
                new Facility{ 
                    Name = "Pool Table",
                    MemberCost = 90,
                    GustCost = 25,
                    Initialoutlay = 5000,
                    MonthlyMaintenance = 100
                }
            };
            using(var unitOfWork = new UnitOfWork(new ApplicationDbContext(options)))
            {                
                // Insert facility
                //unitOfWork.Facilies.Insert(masterfacility);
                //unitOfWork.Commit();

                Console.WriteLine($"Facility Count: {unitOfWork.Facilies.Get().Count()}");                
                Console.WriteLine($"Members Count: {unitOfWork.Members.Get().Count()}");
                Console.WriteLine($"Booking Count: {unitOfWork.Booking.Get().Count()}");
                // Display Facility
                Displayfacility(unitOfWork.Facilies.Get());
            }

        }

        private static void Displayfacility(IEnumerable<Facility> facilities)
        {
            Console.WriteLine($"facid \t Name \t\t Membercost \t Guestcost \t Initialoutlay \t Monthlymaintenance");
            foreach (var facility in facilities)
            {
                Console.WriteLine($"{facility.FacId} \t {facility.Name} \t\t {facility.MemberCost} \t {facility.GustCost} \t {facility.Initialoutlay} \t {facility.MonthlyMaintenance}");
            }
        }
    }
}
