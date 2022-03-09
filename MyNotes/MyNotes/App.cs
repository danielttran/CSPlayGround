
namespace MyNotes
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
            Mediator.Instance.NodeIdChanged += Instance_NodeIdChanged;
        }

        private string nodeId;
        public string NodeId
        {
            get
            {
                return nodeId;
            }
            set
            {
                nodeId = value;
                Mediator.Instance.NodeId = nodeId;
            }
        }

        private void Instance_NodeIdChanged(object? sender, EventArgs e)
        {
            //Main app probably doesn't need to do anything?
        }

    }
}