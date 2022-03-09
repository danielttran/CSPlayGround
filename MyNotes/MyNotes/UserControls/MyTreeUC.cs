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
            var table = Mediator.Instance.Data.GetTreeData().ContinueWith((ret) =>
            {
                InitializeTree(ret.Result);
            });
        }

        private void InitializeTree(IEnumerable<TreeModel> result)
        {
            foreach (var treeModel in result)
            {
                AppendNodeToTree(ref treeView, treeModel);
            }

            treeView.ExpandAll();
            treeView.NodeMouseClick += TreeView_NodeMouseClick;
        }

        private void TreeView_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            Mediator.Instance.NodeId = e.Node.Name;
            if (e.Button == MouseButtons.Left)
            {
                // display item

            }
            else
            {
                // show context menu
            }
        }

        private void AppendNodeToTree(ref MyTreeView tree, TreeModel node)
        {
            if (tree == null)
                return;

            tree.BeginUpdate();
            if (node.Parent_Id == 0)
            {
                // root node
                tree.Nodes.Add(node.Id.ToString(), node.Name);
            }
            else
            {
                var parent = FindParentNode(node.Parent_Id.ToString(), tree.Nodes[0]);
                if (parent != null)
                {
                    parent.Nodes.Add(node.Id.ToString(), node.Name);
                }
            }
            tree.EndUpdate();
        }

        private TreeNode? FindParentNode(string parentId, TreeNode rootNode)
        {
            if (string.IsNullOrEmpty(parentId))
            {
                throw new ArgumentException($"'{nameof(parentId)}' cannot be null or empty.", nameof(parentId));
            }

            if (rootNode is null)
            {
                throw new ArgumentNullException(nameof(rootNode));
            }

            if (rootNode.Name == parentId)
                return rootNode;

            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Name == parentId)
                    return node;

                var next = FindParentNode(parentId, node);
                if (next != null)
                    return next;
            }
            return null;
        }
    }
}
