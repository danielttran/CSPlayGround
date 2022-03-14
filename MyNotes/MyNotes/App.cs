
namespace MyNotes
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
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