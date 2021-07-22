using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mangement_System.Data;
using Mangement_System.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GraduationProject.Data.Models
{
    public class DbInitializer
    {
        static ApplicationDbContext dbcontext;
        public static void Seed(IServiceProvider serviceProvider)
        {

            var rand = new Random();
            dbcontext =
                serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!dbcontext.Users.Any())
            {

                
                dbcontext.Users.Add(
                    new User { 
                        FirstName="admin",
                        LastName="admin",
                        Email="admin@gmail.com",
                        Password="admin",
                        CreationTime=DateTime.Now,
                        UserName="admin",
                    }
                    );
                dbcontext.SaveChanges();
            }


        }
    }
}
