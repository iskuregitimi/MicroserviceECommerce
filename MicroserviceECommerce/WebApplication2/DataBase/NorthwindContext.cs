﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DataBase
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
                  : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
