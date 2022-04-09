using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.System.Users.Requests;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MarvicSolution.Utilities.Exceptions;
using MarvicSolution.Services.System.Helpers;
using Microsoft.AspNetCore.Http;
using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.Enums;

namespace MarvicSolution.Services.System.Users.Services
{
    public class User_Service : IUser_Service
    {
        private readonly MarvicDbContext _context;
        private readonly Jwt_Service _jwtService;

        public User_Service(MarvicDbContext context, Jwt_Service jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public string Authenticate(Login_Request rq)
        {
            // Kiem tra tai khoan
            var user = GetUserbyUserName(rq.UserName);
            if (user == null)
                return "Invalid account";
            // Thiet lap thong tin cho user da login
            UserLogin.SetInfo(user);
            // Kiem tra mat khau
            if (!BCrypt.Net.BCrypt.Verify(rq.Password, user.Password))
                return "Invalid credential";
            // Tao token theo JWT
            var jwt = _jwtService.GenerateToken(user.Id);

            return jwt;
        }

        //public App_User GetUserbyUserName(Login_Request rq)
        //{
        //    var user = _context.App_Users.FirstOrDefault(u => u.UserName == rq.UserName);

        //    if (user == null)
        //        throw new MarvicException($"Cannot find user with username: {rq.UserName}");

        //    return user;
        //}

        public App_User GetUserbyUserName(string userName)
        {
            var user = _context.App_Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
                throw new MarvicException($"Cannot find user with username: {userName}");

            return user;
        }

        public async Task<bool> Register(Register_Request rq)
        {
            try
            {
                var user = new App_User()
                {
                    Id = Guid.NewGuid(),
                    FullName = rq.FullName,
                    UserName = rq.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(rq.Password),
                    IsDeleted = DATA.Enums.EnumStatus.False
                };

                _context.App_Users.Add(user);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Guid> Create(Create_User_Request rq)
        {
            try
            {
                var user = new App_User()
                {
                    Id = Guid.NewGuid(),
                    FullName = rq.FullName,
                    UserName = rq.UserName,
                    Email = rq.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(rq.Password),
                    JobTitle = rq.JobTitle,
                    Department = rq.Department,
                    Organization = rq.Organization,
                    PhoneNumber = rq.PhoneNumber,
                    IsDeleted = DATA.Enums.EnumStatus.False
                };

                _context.App_Users.Add(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<App_User> GetUserbyId(Guid Id)
        {
            var user = await _context.App_Users.FindAsync(Id);

            if (user == null)
                throw new MarvicException($"Cannot find user with Id: {Id}");

            return user;
        }

        public Guid Update(Update_User_Request rq)
        {
            try
            {
                var user = _context.App_Users.Find(rq.Id);
                if (user == null)
                    throw new MarvicException($"Cannot find the user with id: {rq.Id}");
                user.FullName = rq.FullName;
                user.UserName = rq.UserName;
                user.Password = BCrypt.Net.BCrypt.HashPassword(rq.Password);
                user.Email = rq.Email;
                user.JobTitle = rq.JobTitle;
                user.Department = rq.Department;
                user.Organization = rq.Organization;
                user.PhoneNumber = rq.PhoneNumber;

                _context.SaveChangesAsync();
                return rq.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public Guid UpdatePassword(RecoveryPassword_Request rq)
        {
            try
            {
                var user = GetUserbyUserName(rq.UserName);
                user.Password = BCrypt.Net.BCrypt.HashPassword(rq.NewPassword);
                _context.SaveChanges();
                return user.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public Guid RecoveryPassword(RecoveryPassword_Request rq)
        {
            try
            {
                var user = GetUserbyUserName(rq.UserName);
                var hasUser = user != null ? true : false;
                var validEmail = user.Email.Equals(rq.Email) ? true : false;
                if (hasUser && validEmail)
                {
                    UpdatePassword(rq);
                    return user.Id;
                }
                return Guid.Empty;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public Guid Delete(Guid Id)
        {
            try
            {
                var user = _context.App_Users.Find(Id);
                user.IsDeleted = EnumStatus.True;
                _context.SaveChanges();
                return user.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }




    }
}
