using System.Collections.Generic;

using Dashboard_MVC.Models;  
using Dashboard_MVC.Enums;  
using Dashboard_MVC.Services.Interfaces;


namespace Dashboard_MVC.Services
{
    public class UserService : IUserService
    {
        // Static in-memory list
        public static List<UserViewModel> Users { get; set; } = new List<UserViewModel>();

        
        public List<UserViewModel> GetAllUser(){
            return Users;
        }


        public UserViewModel? GetUserByUuid(string uuid)
        {
            return Users.FirstOrDefault(u => u.Uuid == uuid);
        }
        

        public void AddUser(UserViewModel user)
        {
            var newUser = new UserViewModel
            {
                Uuid = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Status = UserStatus.Active
            };

            Users.Add(newUser); 
        }

        public void UpdateUser(UserViewModel userU)
        {
            var user = Users.FirstOrDefault(u => u.Uuid == userU.Uuid);
            if (user != null)
            {
                user.Name = userU.Name;
                user.Email = userU.Email;
                user.Role = userU.Role;
            }
            else {
                throw new Exception ("User Not Found !");
            }
        }

        public void ChangeUserStatus(string uuid)
        {
            var user = Users.FirstOrDefault(u => u.Uuid == uuid);
            if (user != null) {
                if (user.Status == Active){
                    user.Status = UserStatus.InActive;
                }
                else {
                    user.Status = UserStatus.Active;
                }
            }
            else {
                throw new Exception ("User Not Found !");
            }
        }


    }
}
