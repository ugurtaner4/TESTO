﻿using ExpenseApp.Data;
using ExpenseApp.Business.DTOs;
using ExpenseApp.Business.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Business.Helpers
{
   public class UserHelper
    {
        EntityManager<User> userManager = new EntityManager<User>();
        public UserDTO GetUser(string userName,string pass)
        {
            return userManager.First(t => t.UserName == userName && t.Password == pass).ToUserDto();
        }
        public List<UserDTO> GetUser()
        {
            var users = userManager.List();
            return users.Where(t => t.IsDeleted == false ).ToList().ToUserDTOList();
        }
        public UserDTO GetUser(int id)
        {
            var users = userManager.First(t=>t.Id==id);
            return users.ToUserDto();
        }
        public void InsertUsers(UserDTO userdto)
        {
            userManager.Add(userdto.ToUser());
        }
        public void DeleteUsers(int id)
        {
            var users = GetUser(id).ToUser();
            users.IsDeleted =true;
            userManager.Update(users);

        }
    }
}
