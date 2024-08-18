using VNGAssignment.Business.Interfaces;
using VNGAssignment.Business.Models;
using VNGAssignment.DataAccessor.Data;

namespace VNGAssignment.BackgroundJobs.Jobs
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public Worker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var _userService = scope.ServiceProvider.GetService<IUserService>();
                    var _emailService = scope.ServiceProvider.GetService<IEmailService>();

                    var sixMonthsAgo = DateTime.Now.AddMonths(-6);

                    var users = await _userService.GetUsersNotUpdatePwdSixMonth();

                    if (users is not null)
                    {
                        foreach (var u in users)
                        {
                            await _userService.UpdateStatus(u, "REQUIRE_CHANGE_PWD");
                            var emailOptions = new MailData()
                            {
                                ReceiverEmail = u.Email,
                                Title = "CHANGE PASSWORD",
                                Body = "Your password hasn't been updated for more than six months. Please update your password."
                            };
                            await _emailService.SendMailAsync(emailOptions);
                        }
                    }
                }
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
