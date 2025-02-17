// IUserDAO.cs (Interface - Defines the contract for data access)
public interface IUserDAO
{
    User GetUserById(int id);
    List<User> GetAllUsers();
    void CreateUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id);
}