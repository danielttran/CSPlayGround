namespace MyNotes
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();

            myTree.OnNodeClicked += MyTree_OnNodeClicked;
        }

        private void MyTree_OnNodeClicked(object? sender, TreeNodeMouseClickEventArgs e)
        {
            var nodeId = e?.Node?.Name;

            myEdit.DisplayNodeContent(nodeId);
        }


    }
}