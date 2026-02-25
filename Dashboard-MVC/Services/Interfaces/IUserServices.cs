namespace Dashboard_MVC.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserViewModel user);

        UserViewModel? GetUserByUuid(string uuid);

        List<UserViewModel> GetAllUser();

        void UpdateUser(UserViewModel user);
        
        public void ChangeUserStatus(string uuid);
    }
}