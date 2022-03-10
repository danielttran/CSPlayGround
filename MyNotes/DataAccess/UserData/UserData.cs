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

        public Task<IEnumerable<DataModel>> GetData(string nodeId)
        {
            string query = "SELECT * FROM Data WHERE Id = @nodeId";
            return _db.LoadData<DataModel, dynamic>(query, new { nodeId });
        }

        public Task SaveData(DataModel data)
        {
            string query = "insert into Data (Tree_Id, Data, Type) Values (@Tree_Id,@Data,@Type)";
            return _db.SaveData<DataModel>(query, data);
        }
    }
}
