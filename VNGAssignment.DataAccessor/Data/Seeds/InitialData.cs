using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.DataAccessor.Entities;

namespace VNGAssignment.DataAccessor.Data.Seeds
{
    public static class InitialData
    {
        public static async Task SeedAsync (AppDbContext context)
        {
            if(!context.Users.Any())
            {
                await context.Users.AddRangeAsync(new List<User>()
                {
                    new User(){ Id = 1, Email = "dqviet.work@gmail.com", Status = "Working", LastUpdatePwd = new DateTime(2024, 01, 01)},
                    new User(){ Id = 2, Email = "test1.work@gmail.com", Status = "Working", LastUpdatePwd = new DateTime(2024, 01, 01)},
                    new User(){ Id = 3, Email = "test2.work@gmail.com", Status = "Working", LastUpdatePwd = new DateTime(2024, 01, 01)}
                });
                await context.SaveChangesAsync();
            }    
        }
    }
}
