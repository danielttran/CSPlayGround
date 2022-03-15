using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.UserData
{
    public class UserData
    {

        private readonly ISqliteDataAccess _db;

        public UserData()
        {
            _db = new SqliteDataAccess("Data Source=data.db3;");
        }

        /*
         *  Tree Related Queries
         */

        public Task<IEnumerable<TreeModel>> GetTreeModel()
        {
            string query = "SELECT * FROM Tree ORDER BY Parent_Id ASC";
            return _db.LoadData<TreeModel, dynamic>(query, new { });
        }

        public Task SaveTreeModel(TreeModel data)
        {
            string query = @"INSERT INTO Tree (Id, Name, Parent_Id) VALUES (@Id, @Name, @Parent_Id) ON CONFLICT(Id) DO UPDATE SET Name = @Name";
            return _db.SaveData<TreeModel>(query, data);
        }




        /*
         *  Node Related Queries
         */
        
        public Task<IEnumerable<DataModel>> GetDataModel(string Tree_Id)
        {
            string query = "SELECT * FROM Data WHERE Tree_Id = @Tree_Id";
            return _db.LoadData<DataModel, dynamic>(query, new { Tree_Id });
        }

        public Task SaveDataModel(DataModel data)
        {
            string query = "INSERT INTO Data (Tree_Id, data, Type) VALUES (@Tree_Id, @Data, @Type) ON CONFLICT(Tree_Id) DO UPDATE SET Data = @Data, Type = @Type";
            return _db.SaveData<DataModel>(query, data);
        }
    }
}
