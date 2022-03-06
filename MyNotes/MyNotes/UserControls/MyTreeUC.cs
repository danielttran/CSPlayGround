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

        public event EventHandler<TreeNodeMouseClickEventArgs> OnNodeClicked;

        public MyTreeUC()
        {
            InitializeComponent();
            InitTreeView();
        }

        private void InitTreeView()
        {
            var table = Data.GetTreeData().ContinueWith((ret) =>
            {
                myTreeView.BeginUpdate();
                InitTree(ret.Result);
                myTreeView.EndUpdate();
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

            myTreeView.ExpandAll();

            myTreeView.NodeMouseClick += MyTreeView_NodeMouseClick1;
        }

        private void MyTreeView_NodeMouseClick1(object? sender, TreeNodeMouseClickEventArgs e)
        {
            OnNodeClicked(this, e);
        }

        private void AppendNodeToTree(TreeModel node)
        {
            var parent = FindParentNode(node.Parent_Id.ToString(), myTreeView.Nodes[0]); // only have 1 root
            if (parent != null)
            {
                parent.Nodes.Add(node.Id.ToString(), node.Name);
            }
        }

        private TreeNode? FindParentNode(string parentId, TreeNode rootNode)
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
