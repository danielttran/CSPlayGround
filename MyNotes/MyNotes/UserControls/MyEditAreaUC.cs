using DataAccess.Models;
using MyNotes.Events;
using System.Text;

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

            textObj.TextChanged += TextObj_TextChanged;

            EditAreaPanel.Controls.Clear();
            EditAreaPanel.Controls.Add(textObj);

            return Task.FromResult(0);
        }

        private void TextObj_TextChanged(object? sender, EventArgs e)
        {
            var rt = sender as RichTextBox;
            if (rt != null)
            {
                var dataModel = new DataModel();

                if (int.TryParse(Mediator.Instance.NodeId, out int tree_Id))
                {
                    dataModel.Tree_Id = tree_Id;
                    dataModel.Data = Encoding.UTF8.GetBytes(rt.Text);
                    dataModel.Type = 1;
                }
                Mediator.Instance.Data.SaveData(dataModel).ContinueWith(ret =>
                {
                    var q = ret;
                });
            }
        }
    }
}
