using DataAccess.Models;
using DataAccess.UserData;
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

        private void Instance_NodeIdChanged(object? sender, EventArgs e)
        {
            var nodeIds = e as NodeIdChanged;
            if (nodeIds != null)
            {
                DisplayNodeContent(nodeIds.PreviousNodeId, nodeIds.NewNodeId);
            } 
        }

        private void DisplayNodeContent(string previousNodeId, string newNodeId)
        {
            if (string.IsNullOrEmpty(previousNodeId) == false)
            {
                if (Mediator.Instance.TextChanged)
                {
                    var textContent = string.Empty;
                    // Find text
                    var controls = EditAreaPanel.Controls.Find(previousNodeId, true);
                    foreach (var control in controls)
                    {
                        if (control is RichTextBox)
                        {
                            textContent  = ((RichTextBox)control).Rtf;
                            break;
                        }
                    }

                    // Save old node id content
                    var dataModel = new DataModel();

                    if (int.TryParse(previousNodeId, out int tree_Id))
                    {
                        dataModel.Tree_Id = tree_Id;
                        dataModel.Data = textContent;
                        dataModel.Type = 1;
                    }
                    Data.SaveData(dataModel);
                }
            }

            if (string.IsNullOrEmpty(newNodeId) == false)
            {
                // display newly selected node
                var dataTask = Data.GetData(newNodeId);
                var textObj = new RichTextBox
                {
                    Name = newNodeId,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None
                };
                textObj.TextChanged += TextObj_TextChanged;
                EditAreaPanel.Controls.Clear();

                var txt = dataTask.Result.FirstOrDefault()?.Data;
                textObj.Rtf = txt;
                EditAreaPanel.Controls.Add(textObj);
            }

            Mediator.Instance.TextChanged = false;
        }

        private void TextObj_TextChanged(object? sender, EventArgs e)
        {
            Mediator.Instance.TextChanged = true;

        }
    }
}