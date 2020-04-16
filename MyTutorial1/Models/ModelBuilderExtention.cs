using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.Models
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder   modelBuilder) {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "Amer",
                        Department = Dept.SWE,
                        Email = "Aamer@gmail.com"
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "Mego",
                        Department = Dept.SWE,
                        Email = "Mego@gmail.com"
                    }
                );
        }
    }
}
