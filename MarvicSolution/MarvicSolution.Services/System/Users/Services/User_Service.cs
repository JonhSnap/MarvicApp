﻿using MarvicSolution.DATA.EF;
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
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MarvicSolution.Services.System.Users.View_Model;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using Microsoft.Extensions.Logging;

namespace MarvicSolution.Services.System.Users.Services
{
    public class User_Service : IUser_Service
    {
        private readonly MarvicDbContext _context;
        private readonly Jwt_Service _jwtService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<User_Service> _logger;

        public User_Service(MarvicDbContext context, Jwt_Service jwtService, IWebHostEnvironment webHostEnvironment, ILogger<User_Service> logger)
        {
            _context = context;
            _jwtService = jwtService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        public string GetJwt(Login_Request rq, App_User user)
        {
            try
            {
                // Kiem tra mat khau
                if (!BCrypt.Net.BCrypt.Verify(rq.Password, user.Password))
                    return "Password does not exsist";
                // Tao token theo JWT
                var jwt = _jwtService.GenerateToken(user.Id);

                return jwt;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: Authenticate. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public bool Register(Register_Request rq)
        {
            try
            {
                var user = new App_User()
                {
                    Id = Guid.NewGuid(),
                    FullName = rq.FullName,
                    UserName = rq.UserName,
                    Email = rq.Email,
                    PhoneNumber = rq.PhoneNumber,
                    Password = BCrypt.Net.BCrypt.HashPassword(rq.Password),
                    IsDeleted = EnumStatus.False
                };

                _context.App_Users.Add(user);
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: Register. Marvic Error: {e}");
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
                _logger.LogInformation($"Controller: User. Method: UpdatePassword. Marvic Error: {e}");
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
                _logger.LogInformation($"Controller: User. Method: RecoveryPassword. Marvic Error: {e}");
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
                _logger.LogInformation($"Controller: User. Method: Create. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
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
                user.Email = rq.Email;
                user.Avatar = rq.Avatar;
                user.JobTitle = rq.JobTitle;
                user.Department = rq.Department;
                user.Organization = rq.Organization;
                user.PhoneNumber = rq.PhoneNumber;
                user.IsFirstLogin = (EnumStatus)rq.IsFirstLogin;
                _context.SaveChanges();
                return rq.Id;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: Update. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public void UploadAvatar(Guid idUser, IFormFile file)
        {
            try
            {
                var user = GetUserbyId(idUser);
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "upload files\\Avatar");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                    file.CopyTo(stream);
                user.Avatar = uniqueFileName;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: UploadAvatar. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public bool DeleteUserAvatar(Guid idUser, string fileName)
        {
            try
            {
                var user = GetUserbyId(idUser);
                user.Avatar = string.Empty;
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: DeleteUserAvatar. Marvic Error: {e}");
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
                _logger.LogInformation($"Controller: User. Method: Delete. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public App_User GetUserbyUserName(string userName)
        {
            try
            {
                return _context.App_Users.SingleOrDefault(i => i.UserName.Equals(userName));
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: GetUserbyUserName. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public User_ViewModel GetUserbyUserNameVM(string userName, RequestVM rqVM)
        {
            try
            {
                return _context.App_Users.Where(x => x.UserName.Equals(userName)).Select(i => new User_ViewModel()
                {
                    Id = i.Id,
                    Avatar = i.Avatar,
                    Avatar_Path = i.Avatar.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/Avatar/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, i.Avatar),
                    Department = i.Department,
                    Email = i.Email,
                    FullName = i.FullName,
                    JobTitle = i.JobTitle,
                    Organization = i.Organization,
                    PhoneNumber = i.PhoneNumber,
                    UserName = i.UserName
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: GetUserbyUserNameVM. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public User_ViewModel GetUserbyIdVM(Guid Id, RequestVM rqVM)
        {
            try
            {
                return _context.App_Users.Where(u => u.Id.Equals(Id)).Select(u => new User_ViewModel()
                {
                    Id = u.Id,
                    Avatar = u.Avatar,
                    Avatar_Path = u.Avatar.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/Avatar/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, u.Avatar),
                    Department = u.Department,
                    Email = u.Email,
                    FullName = u.FullName,
                    JobTitle = u.JobTitle,
                    Organization = u.Organization,
                    PhoneNumber = u.PhoneNumber,
                    UserName = u.UserName,
                    Scores = u.Scores,
                    IsFirstLogin = u.IsFirstLogin
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: GetUserbyIdVM. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public App_User GetUserbyId(Guid Id)
        {
            try
            {
                return _context.App_Users.SingleOrDefault(i => i.Id.Equals(Id));
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: User. Method: GetUserbyId. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public List<User_ViewModel> GetAllMember(Guid idProject, RequestVM rqVM)
        {
            var members = (from mem in _context.Members
                         join u in _context.App_Users on mem.Id_User equals u.Id
                         where mem.Id_Project.Equals(idProject)
                               && u.IsDeleted.Equals(EnumStatus.False)
                         select new User_ViewModel()
                         {
                             Id = u.Id,
                             Avatar = u.Avatar,
                             Avatar_Path = u.Avatar.Equals(string.Empty) ? string.Empty : string.Format("{0}://{1}{2}/upload files/Avatar/{3}", rqVM.Shceme, rqVM.Host, rqVM.PathBase, u.Avatar),
                             Department = u.Department,
                             Email = u.Email,
                             FullName = u.FullName,
                             JobTitle = u.JobTitle,
                             Organization = u.Organization,
                             PhoneNumber = u.PhoneNumber,
                             UserName = u.UserName
                         }).ToList();
            return members;
        }
    }
}
