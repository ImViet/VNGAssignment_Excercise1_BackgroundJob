using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Business.Interfaces;
using VNGAssignment.DataAccessor.Data;
using VNGAssignment.DataAccessor.Entities;

namespace VNGAssignment.Business.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersNotUpdatePwdSixMonth()
        {
            var month = DateTime.Now.AddMonths(-6);
            return await _context.Users.Where(x => x.LastUpdatePwd < month).AsNoTracking().ToListAsync();
        }

        public async Task<bool> UpdateStatus(User user, string status)
        {
            var u = _context.Users.First(x => x.Id == user.Id);
            u.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
