using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Business.Models;

namespace VNGAssignment.Business.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendMailAsync(MailData mailData);
    }
}
