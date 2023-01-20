﻿using IonCareer.Application.Seeders;
using IonCareer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IonCareer.Infrastructure.Persistence.Seeders
{
    public static class IonCareerDataSeeder
    {

        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedWeatherData(modelBuilder);
            SeedRoleData(modelBuilder);
        }

        private static void SeedWeatherData(ModelBuilder modelBuilder)
        {
            foreach (var weather in WeatherTypeSeeder.GetData())
            {
                modelBuilder.Entity<WeatherData>().HasData(weather);
            }
        }

        private static void SeedRoleData(ModelBuilder modelBuilder)
        {
            foreach (var role in RoleSeeder.GetRoles())
            {
                modelBuilder.Entity<Role>().HasData(role);
            }
        }
    }
}
