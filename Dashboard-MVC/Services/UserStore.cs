using System.Collections.Generic;
using Dashboard_MVC.Models;  

namespace Dashboard_MVC.Services
{
    public static class UserStore
    {
        // Static in-memory list
        public static List<UserViewModel> Users { get; set; } = new List<UserViewModel>();

        public static void AddUser(UserViewModel user)
        {
            var newUser = new UserViewModel
            {
                Uuid = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };

            Users.Add(newUser); 
        }

        public static void UpdateUser(UserViewModel userU)
        {
            var user = Users.FirstOrDefault(u => u.Uuid == userU.Uuid);
            if (user != null)
            {
                user.Name = userU.Name;
                user.Email = userU.Email;
                user.Role = userU.Role;
            }
        }


        public static List<UserViewModel> GetAllUser(){
            return Users;
        }


        public static UserViewModel GetUserByUuid(string uuid)
        {
            return Users.FirstOrDefault(u => u.Uuid == uuid);
        }
        
    }
}
