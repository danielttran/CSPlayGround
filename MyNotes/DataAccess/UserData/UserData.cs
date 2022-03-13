using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserData
{
    public class UserData
    {

        private readonly ISqliteDataAccess _db;

        public UserData()
        {
            _db = new SqliteDataAccess("Data Source=data.db3;");

        }

        public Task<IEnumerable<TreeModel>> GetTreeData()
        {
            string query = "SELECT * FROM Tree ORDER BY Parent_Id ASC";
            return _db.LoadData<TreeModel, dynamic>(query, new { });
        }

        public Task<IEnumerable<DataModel>> GetData(string Tree_Id)
        {
            string query = "SELECT * FROM Data WHERE Tree_Id = @Tree_Id";
            return _db.LoadData<DataModel, dynamic>(query, new { Tree_Id });
        }

        public Task SaveData(DataModel data)
        {
            string query = "INSERT INTO Data (Tree_Id, data, Type) VALUES (@Tree_Id, @Data, @Type) ON CONFLICT(Tree_Id) DO Update set Data = @Data, Type = @Type";
            return _db.SaveData<DataModel>(query, data);
        }
    }
}
