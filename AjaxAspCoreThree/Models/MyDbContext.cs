﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxAspCoreThree.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<QuestionData> QuestionData { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
