namespace MyNotes.Forms
{
    public partial class GetUserInputDialog : Form
    {

        public GetUserInputDialog(string title)
        {
            InitializeComponent();
            Text = title;
        }

        public string UserInput
        {
            get { return textBox.Text; }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
