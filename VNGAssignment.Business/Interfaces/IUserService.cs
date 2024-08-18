using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.DataAccessor.Entities;

namespace VNGAssignment.Business.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersNotUpdatePwdSixMonth();
        Task<bool> UpdateStatus(User user, string status);
    }
}
