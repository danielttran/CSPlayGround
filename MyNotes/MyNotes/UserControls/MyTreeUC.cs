using DataAccess.Models;
using DataAccess.UserData;
using MyNotes.Forms;

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
            var table = Data.GetTreeModel().ContinueWith((ret) =>
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
            MenuItems.Add(CreateToolStripMenuItem("Rename", "RenameNode"));
            MenuItems.Add(CreateToolStripMenuItem("Delete", "DeleteNode"));

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
            if (int.TryParse(Mediator.Instance.NodeId, out int currentNode))
            {
                switch (menuItem?.Name)
                {
                    case "AddChildNode":
                        AddChildNode(currentNode);
                        break;
                    case "RenameNode":
                        RenameNode(currentNode);
                        break;
                    case "DeleteNode":
                        DeleteNode(currentNode);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // empty tree
                AddRootNode();
            }
            RefreshTree();
        }

        private void DeleteNode(int currentNode)
        {
            Data.DeleteTreeNode(currentNode);
        }

        private void RenameNode(int currentNode)
        {
            var nodeName = GetUserInput("Please enter node name");
            if (string.IsNullOrEmpty(nodeName))
                return;

            var treeModel = new TreeModel
            {
                Name = nodeName,
                Id = currentNode
            };
            Data.SaveTreeModel(treeModel);
        }

        private void AddChildNode(int currentNode)
        {
            var nodeName = GetUserInput("Please enter note name");
            if (string.IsNullOrEmpty(nodeName))
                return;

            var treeModel = new TreeModel
            {
                Name = nodeName,
                Parent_Id = currentNode
            };
            Data.SaveTreeModel(treeModel);
        }

        private void AddRootNode()
        {
            var nodeName = GetUserInput("Please enter root note name");
            if (string.IsNullOrEmpty(nodeName))
                nodeName = "Root";

            var treeModel = new TreeModel
            {
                Name = nodeName,
                Parent_Id = 0
            };
            Data.SaveTreeModel(treeModel);

        }

        private string GetUserInput(string title)
        {
            var msgDialog = new GetUserInputDialog(title);
            if (msgDialog.ShowDialog(this) == DialogResult.OK)
            {
                return msgDialog.UserInput;
            }
            return string.Empty;
        }

        private void RefreshTree()
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            var table = Data.GetTreeModel().ContinueWith((ret) =>
            {
                treeView.Invoke(delegate
                {
                    InitializeTree(ret.Result);
                });
            });
            treeView.EndUpdate();
        }

        private void InitializeTree(IEnumerable<TreeModel> result)
        {
            foreach (var treeModel in result)
            {
                AppendNodeToTree(ref treeView, treeModel);
            }

            if (result?.Count() == 0)
            {
                AddRootNode();
                RefreshTree();
            }

            treeView.ExpandAll();
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

            if (node.Parent_Id == 0 || node.Parent_Id == null)
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

        ~MyTreeUC()
        {
            Data.Vacuum();
        }
    }
}
