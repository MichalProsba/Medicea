﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicea.DatabaseSQLite
{
    public class DatabaseSQLiteContext : DbContext
    {
        public DbSet<Symptom> Symptoms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite("Data Source = Database.db");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public DatabaseSQLiteContext()
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        public override void Dispose()
        {
            Database.CloseConnection();
            base.Dispose();
        }
    }
}
