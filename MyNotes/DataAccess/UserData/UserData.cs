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
            string query = @"INSERT INTO Tree (Name, Parent_Id) VALUES (@Name, @Parent_Id) ON CONFLICT(Id) DO UPDATE SET Name = @Name";
            return _db.SaveData<TreeModel>(query, data);
        }

        public void Vacuum()
        {
            _db.SaveData("VACUUM;", new { });
        }

        /// <summary>
        /// Deleting node and all its children
        /// in Tree and Data table
        /// </summary>
        /// <param name="Tree_Id"></param>
        /// <returns></returns>
        public void DeleteTreeNode(int Tree_Id)
        {
            // all tree Id to delete
            var query = $@"WITH name_tree as 
                        (
	                        SELECT Id, Parent_Id, name
	                        FROM Tree
	                        WHERE Id = {Tree_Id}
	                        UNION ALL
	                        SELECT t.Id, t.Parent_Id, t.Name
	                        FROM Tree t
		                        JOIN name_tree p ON p.Id = t.Parent_Id
                        )
                        SELECT Id FROM name_tree";

            _db.LoadData<int, dynamic>(query, new { Tree_Id }).ContinueWith((list) =>
            {

                var TreeIdsToDelete = string.Join(",", list.Result);
                if (string.IsNullOrEmpty(TreeIdsToDelete) == false)
                {
                    _db.SaveData<int>($"DELETE FROM Tree WHERE Id IN ({TreeIdsToDelete})", new int { });
                    _db.SaveData<int>($"DELETE FROM Data WHERE Tree_Id ({TreeIdsToDelete})", new int { });
                }
            });
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
