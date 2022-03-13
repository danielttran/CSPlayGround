using DataAccess.Models;
using DataAccess.UserData;
using MyNotes.Events;
using System.Diagnostics;

namespace MyNotes.UserControls
{
    public partial class MyEditAreaUC : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public MyEditAreaUC()
        {
            InitializeComponent();

            Mediator.Instance.NodeIdChanged -= Instance_NodeIdChanged;
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
            else
            {
                Debug.Assert(false);
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
                        if (control is MyRichText box)
                        {
                            textContent = box.Rtf;
                            break;
                        }
                    }

                    // Save old node id content
                    using var nodeData = new DataModel();
                    if (int.TryParse(previousSelectedNodeId, out int tree_Id))
                    {
                        nodeData.Tree_Id = tree_Id;
                        nodeData.Data = textContent;
                        nodeData.Type = 1;
                    }

                    Mediator.Instance.TextChanged = false;
                    Data.SaveData(nodeData);
                }
            }

            if (string.IsNullOrEmpty(newSelectedNodeId) == false)
            {
                // display newly selected node
                EditAreaPanel.SuspendLayout();
                Data.GetData(newSelectedNodeId).ContinueWith(dataTask =>
                {
                    EditAreaPanel.Invoke(delegate
                    {
                        
                        var timer = new Stopwatch();
                        timer.Start();

                        EditAreaPanel.Controls.Clear();
                        GC.Collect();

                        var richTextbox = new MyRichText();
                        richTextbox.SuspendLayout();

                        richTextbox.Name = newSelectedNodeId;

                        try
                        {
                            richTextbox.Rtf = dataTask?.Result.FirstOrDefault()?.Data;
                        }
                        catch
                        {
                            richTextbox.Rtf = null;
                        }
                        richTextbox.ResumeLayout();

                        richTextbox.TextChanged += RichTextBox_TextChanged;

                        EditAreaPanel.Controls.Add(richTextbox);

                        EditAreaPanel.ResumeLayout();

                        timer.Stop();
                        var totalTime = timer.ElapsedMilliseconds;
                        int q = 10;
                    });
                });
            }
        }

        private void RichTextBox_TextChanged(object? sender, EventArgs e)
        {
            Mediator.Instance.TextChanged = true;
        }
    }
}