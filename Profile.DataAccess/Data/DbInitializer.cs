using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Profile.Model.Infrastructure;
using Profile.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Profile.DataAccess.Constants.Data;

namespace Profile.DataAccess.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            ProfileDbContext _context = serviceProvider.GetRequiredService<ProfileDbContext>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<ApplicationUser> _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //uncomment this ONLY for testing purposes
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();


            //migrate the db schema
            _context.Database.Migrate();

            //adding custom roles
            string[] roleNames = ProfilerRoles.GetRoles.ToArray();

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {

                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }


            //create default users
            //check if there is the default users exist
            Dictionary<string, string> defaultUsers = new Dictionary<string, string>()
            {
                { DefaultAdminEmail, DefaultAdminPassword },               
                { DefaultTrainerEmail, DefaultTrainerPassword },
                { DefaultStudentEmail, DefaultStudentPassword },
                { DefaultHrEmail, DefaultHrPassword}
            };

            foreach (KeyValuePair<string, string> du in defaultUsers)
            {
                var existingUser = await _userManager.FindByEmailAsync(du.Key);

                //create one if doesn't exist
                if (existingUser == null)
                {
                    var user = new ApplicationUser { UserName = du.Key, Email = du.Key };
                    var result = await _userManager.CreateAsync(user, du.Value);

                    if (result.Succeeded)
                    {
                        //assign the roles
                        var currentUser = await _userManager.FindByNameAsync(user.UserName);

                        UserInfo userInfo = new UserInfo();

                        switch (du.Key)
                        {
                            case DefaultAdminEmail:
                                await _userManager.AddToRoleAsync(currentUser, ProfilerRoles.Admin);

                                userInfo.UserId = currentUser.Id;
                                userInfo.Email = DefaultAdminEmail;
                                userInfo.EnName = "Admin";
                                userInfo.EnSurname = "von Profile";
                                userInfo.Phone = "375256666666";
                                userInfo.RuName = "Администратор";
                                userInfo.RuSurname = "Профайлера";

                                try
                                {
                                    _context.UserInfo.Add(userInfo);
                                    currentUser.UserInfo = userInfo;
                                    _context.SaveChanges();
                                }
                                catch
                                {
                                    throw new Exception($"Failed to save the user {du.Key}.");
                                }
                                break;                          

                            case DefaultTrainerEmail:
                                await _userManager.AddToRoleAsync(currentUser, ProfilerRoles.Trainer);

                                userInfo.UserId = currentUser.Id;
                                userInfo.Email = DefaultTrainerEmail;
                                userInfo.EnName = "Trainer";
                                userInfo.EnSurname = "McTrainer";
                                userInfo.Phone = "375258888888";
                                userInfo.RuName = "Тренер";
                                userInfo.RuSurname = "Тренерович";

                                try
                                {
                                    _context.UserInfo.Add(userInfo);
                                    currentUser.UserInfo = userInfo;
                                    _context.SaveChanges();
                                }
                                catch
                                {
                                    throw new Exception($"Failed to save the user {du.Key}.");
                                }
                                break;

                            case DefaultStudentEmail:
                                await _userManager.AddToRoleAsync(currentUser, ProfilerRoles.Student);
                                ApplicationUser trainer = await _userManager.FindByEmailAsync(DefaultTrainerEmail);

                                userInfo.UserId = currentUser.Id;
                                userInfo.Email = DefaultStudentEmail;
                                userInfo.EnName = "Ivan";
                                userInfo.EnSurname = "Ivanov";
                                userInfo.DateOfBirth = new DateTime(1992, 12, 23);
                                userInfo.Phone = "375257777777";
                                userInfo.RuName = "Иван";
                                userInfo.RuSurname = "Иванов";

                                try
                                {
                                    _context.UserInfo.Add(userInfo);
                                    currentUser.UserInfo = userInfo;
                                    _context.SaveChanges();
                                }
                                catch
                                {
                                    throw new Exception($"Failed to save the user {du.Key}.");
                                }

                                UserInfo userInfoCreated = await _context.UserInfo.FirstOrDefaultAsync(ui => ui.Email == DefaultStudentEmail);

                                //create new student
                                //and bind it to the created trainer
                                Student student = new Student();
                                student.UserInfoId = userInfoCreated.Id;
                                student.TrainerId = trainer.Id;
                                student.DateOfGraduation = new DateTime(2017, 12, 23);

                                _context.Students.Add(student);

                                StudentStream studentStream = new StudentStream();
                                studentStream.Student = student;
                                studentStream.Stream = _context.Streams.FirstOrDefault(s => s.StreamShortName == "ND");

                                _context.StudentStreams.Add(studentStream);
                                _context.SaveChanges();

                                break;

                            case DefaultHrEmail:
                                await _userManager.AddToRoleAsync(currentUser, ProfilerRoles.HR);

                                userInfo.UserId = currentUser.Id;
                                userInfo.Email = DefaultHrEmail;
                                userInfo.EnName = "Hr";
                                userInfo.EnSurname = "Olga hr";
                                userInfo.Phone = "375254444444";
                                userInfo.RuName = "Менеджер";
                                userInfo.RuSurname = "Студентов";

                                try
                                {
                                    _context.UserInfo.Add(userInfo);
                                    currentUser.UserInfo = userInfo;
                                    _context.SaveChanges();
                                }
                                catch
                                {
                                    throw new Exception($"Failed to save the user {du.Key}.");
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception($"Failed to create a user using {du.Key}.");
                    }
                }
            }
        }
    }
}
