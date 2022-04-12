
using DataAccess.UserData;

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

        private void vacuumDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.Vacuum();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save current node data to database
            
        }
    }
}