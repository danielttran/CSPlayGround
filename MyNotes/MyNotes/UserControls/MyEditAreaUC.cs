using DataAccess.Models;
using DataAccess.UserData;
using MyNotes.Events;
using System.Text;

namespace MyNotes.UserControls
{
    public partial class MyEditAreaUC : UserControl
    {

        /// <summary>
        /// 
        /// </summary>
        public MyEditAreaUC() : base()
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
            if (e is NodeIdChanged nodeIds)
            {
                DisplayNodeContent(nodeIds.PreviousNodeId, nodeIds.NewNodeId);
            }
        }

        private void DisplayNodeContent(string previousSelectedNodeId, string newSelectedNodeId)
        {
            if (string.IsNullOrEmpty(previousSelectedNodeId) == false)
            {
                if (Mediator.Instance.TextChanged)
                {
                    var textContent = string.Empty;
                    // Find text
                    var controls = EditAreaPanel.Controls.Find(previousSelectedNodeId, true);
                    foreach (var control in controls)
                    {
                        if (control is RichTextBox box)
                        {
                            textContent = box.Rtf;
                            break;
                        }
                    }

                    // Save old node id content
                    using var dataModel = new DataModel();
                    if (int.TryParse(previousSelectedNodeId, out int tree_Id))
                    {
                        dataModel.Tree_Id = tree_Id;
                        dataModel.Data = textContent;
                        dataModel.Type = 1;
                    }
                    Data.SaveData(dataModel);
                }
            }

            if (string.IsNullOrEmpty(newSelectedNodeId) == false)
            {
                // display newly selected node
                Data.GetData(newSelectedNodeId).ContinueWith(dataTask =>
                {
                    EditAreaPanel.Invoke(delegate 
                    {
                        EditAreaPanel.Controls.Clear();

                        var richTextbox = new RichTextBox
                        {
                            Name = newSelectedNodeId,
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None,

                        };

                        richTextbox.Rtf = dataTask?.Result.FirstOrDefault()?.Data;
                        richTextbox.TextChanged += richTextBox_TextChanged;
                        
                        EditAreaPanel.Controls.Add(richTextbox);    
                    });
                });
            }

            Mediator.Instance.TextChanged = false;
        }


        private void richTextBox_TextChanged(object? sender, EventArgs e)
        {
            Mediator.Instance.TextChanged = true;
        }
    }
}