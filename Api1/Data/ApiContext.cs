using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Api1.Models;

namespace Api1.Data
{
    public class ApiContext : DbContext
    {
     public DbSet<Product> Products { get; set; } 
     public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
        {

        }               
    }
}