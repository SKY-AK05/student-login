using Student.Models;
using Student.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Services
{
   
        public class AuthService
        {
            private readonly UserRepository _userRepo;

            public AuthService()
            {
                _userRepo = new UserRepository();
            }

            public User ValidateUser(string username, string password)
            {
                var user = _userRepo.GetUser(username, password);

                if (user == null)
                    return null;

                
                return user;
            }
        }
    }
