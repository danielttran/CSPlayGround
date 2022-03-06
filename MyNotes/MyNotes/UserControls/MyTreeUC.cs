using DataAccess.Models;
using DataAccess.UserData;

namespace MyNotes.UserControls
{
    public partial class MyTreeUC : UserControl
    {
        private UserData data;

        public UserData Data
        {
            get 
            {
                if(data == null)
                    data = new UserData();
                return data; 
            }
            set { data = value; }
        }

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


            var table = Data.GetTreeData().ContinueWith((ret) =>
            {
                InitTree(ret.Result);
            });
        }

        private void InitTree(IEnumerable<TreeModel> result)
        {
            foreach (var treeModel in result)
            {
                if(treeModel.Parent_Id == 0)
                {
                    // root
                    myTreeView.Nodes.Add(treeModel.Id.ToString(), treeModel.Name);
                }
                else
                {
                    AppendNodeToTree(treeModel);
                }
            }
        }

        private void AppendNodeToTree(TreeModel node)
        {
            var parent = FindParentNode(node.Parent_Id.ToString(), myTreeView.Nodes[0]);
            if (parent != null)
            {
                parent.Nodes.Add(node.Id.ToString(), node.Name);
            }
        }

        private TreeNode FindParentNode(string parentId, TreeNode rootNode)
        {
            if(rootNode.Name == parentId)
                return rootNode;

            foreach(TreeNode node in rootNode.Nodes)
            {
                if(node.Name == parentId)
                    return node;

                var next = FindParentNode(parentId, node);
                if (next != null)
                    return next;
            }
            return null;
        }
    }
}
