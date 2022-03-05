using DataAccess.Models;
using DataAccess.UserData;

namespace MyNotes.UserControls
{
    public partial class MyTreeUC : UserControl
    {
        public MyTreeUC()
        {
            InitializeComponent();
            InitTreeView();
        }

        private void InitTreeView()
        {
            //myTreeView.BeginUpdate();
            //myTreeView.Nodes.Add("Parent");
            //myTreeView.Nodes[0].Nodes.Add("Child 1");
            //myTreeView.Nodes[0].Nodes.Add("Child 2");
            //myTreeView.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            //myTreeView.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            //myTreeView.EndUpdate();


            var data = new UserData();
            var table = data.GetTreeData().ContinueWith((ret) =>
            {
                InitTree(ret.Result);
            });
        }

        private void InitTree(IEnumerable<TreeModel> result)
        {
            foreach(var treeModel in result)
            {
                AddNodeToTree(treeModel);
            }
        }

        private void AddNodeToTree(TreeModel ret)
        {
            if(ret.Parent_Id == 0)
            {
                // head
                myTreeView.Nodes.Add(ret.Id.ToString(), ret.Name);
            }
            else
            {
                if(myTreeView.Nodes.ContainsKey(ret.Parent_Id.ToString()) == false)
                {
                    myTreeView.Nodes.Add(ret.Parent_Id.ToString(), string.Empty);
                    myTreeView.Nodes[myTreeView.Nodes.IndexOfKey(ret.Parent_Id.ToString())].Nodes.Add(ret.Parent_Id.ToString(), ret.Name);
                }
                else
                {
                    //myTreeView.Nodes[myTreeView.Nodes.IndexOfKey(ret.Parent_Id.ToString())].Nodes[myTreeView.Nodes.IndexOfKey(ret.Id.ToString())].Text = ret.Name;
                }
            }
        }
    }
}
