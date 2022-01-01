using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers()
    {
        return _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll",
                                                new { });
    }

    public async Task<UserModel?> GetUser(int id)
    {
        var result = await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get",
                                                            new { Id = id });
        return result.FirstOrDefault();
    }

    public Task InsertUser(UserModel user)
    {
        return _db.SaveData("dbo.spUser_Insert",
                            new { user.FirstName, user.LastName });
    }

    public Task UpdateUser(UserModel user)
    {
        return _db.SaveData("dbo.spUser_Update",
                            new { user });
    }

    public Task DeleteUser(int id)
    {
        return _db.SaveData("dbo.spUser_Delete", new { Id = id });
    }

}
