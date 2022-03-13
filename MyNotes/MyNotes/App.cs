
namespace MyNotes
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();

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

        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            ResumeLayout();
        }

    }
}