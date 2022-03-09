using MyNotes.Events;

namespace MyNotes.UserControls
{
    public partial class MyEditAreaUC : UserControl
    {
        public MyEditAreaUC()
        {
            InitializeComponent();
            Mediator.Instance.NodeIdChanged += Instance_NodeIdChanged;

        }

        private void Instance_NodeIdChanged(object? sender, EventArgs e)
        {
            var nodeIds = e as NodeIdChanged;
            DisplayNodeContent(nodeIds.NewNodeId);
        }

        private Task<int> DisplayNodeContent(string nodeId)
        {
            var textObj = new RichTextBox();
            textObj.Dock = DockStyle.Fill;
            textObj.Visible = true;
            textObj.BorderStyle = BorderStyle.None;

            Mediator.Instance.Data.GetData(nodeId).ContinueWith(x =>
            {
                var q = x.Result;
            });

            EditAreaPanel.Controls.Clear();
            EditAreaPanel.Controls.Add(textObj);

            return Task.FromResult(0);
        }
    }
}
