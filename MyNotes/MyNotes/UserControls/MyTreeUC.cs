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
                if (data == null)
                    data = new UserData();
                return data;
            }
            set { data = value; }
        }

        public MyTreeUC()
        {
            SuspendLayout();

            InitializeComponent();
            InitializeTreeView();
            InitializeContentMenu();

            ResumeLayout();
        }

        private void InitializeTreeView()
        {
            var table = Data.GetTreeData().ContinueWith((ret) =>
            {
                InitializeTree(ret.Result);
            });
        }

        private void InitializeContentMenu()
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            List<ToolStripMenuItem> items = CreateMenuItems();
            foreach (var menuItem in items)
            {
                menuStrip.Items.Add(menuItem);
                menuItem.Click += new EventHandler(MenuItem_Click);
            }
            ContextMenuStrip = menuStrip;
        }

        private List<ToolStripMenuItem> CreateMenuItems()
        {

            var MenuItems = new List<ToolStripMenuItem>();
            MenuItems.Add(CreateToolStripMenuItem("Add Child", "AddChildNode"));
            MenuItems.Add(CreateToolStripMenuItem("Delete", "DeleteNode"));
            MenuItems.Add(CreateToolStripMenuItem("Rename", "RenameNode"));

            return MenuItems;
        }

        private ToolStripMenuItem CreateToolStripMenuItem(string text, string name)
        {
            var toolStripMenuItem = new ToolStripMenuItem
            {
                Text = text,
                Name = name

            };
            return toolStripMenuItem;
        }


        void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripItem;

            switch (menuItem?.Name)
            {
                case "AddChildNode":
                    // TODO
                    // Add new empty child node here
                    break;
                case "DeleteNode":
                    break;
                case "RenameNode":
                    break;
                default:
                    break;
            }
        }

        private void InitializeTree(IEnumerable<TreeModel> result)
        {
            treeView.BeginUpdate();
            foreach (var treeModel in result)
            {
                AppendNodeToTree(ref treeView, treeModel);
            }

            treeView.ExpandAll();
            treeView.EndUpdate();

            treeView.NodeMouseClick += TreeView_NodeMouseClick;
        }

        private void TreeView_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            treeView.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Left)
            {
                // only load node if it's a left click
                Mediator.Instance.IsLeftClick = true;
            }
            else
            {
                Mediator.Instance.IsLeftClick = false;
            }
            Mediator.Instance.NodeId = e.Node.Name;
        }

        private void AppendNodeToTree(ref MyTreeView tree, TreeModel node)
        {
            if (tree == null)
                return;

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
