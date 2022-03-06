using Syncfusion;
using Syncfusion.Presentation;
using System.Diagnostics;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private List<string> fileList;

        public List<string> FileList
        {
            get 
            {
                if(fileList == null)
                    fileList = new List<string>();
                return fileList; 
            }
            set { fileList = value; }
        }


        private void listView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                
                foreach(var file in files)
                {
                    FileList.Add(file);
                }

                RefreshList();
            }
        }

        private void RefreshList()
        {
            listView.Clear();
            foreach (var file in FileList)
            {
                listView.Items.Add(file);
            }
        }

        

        private void clearBtn_Click(object sender, EventArgs e)
        {
            FileList.Clear();
            RefreshList();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            using (var ppOut = Presentation.Create())
            {
                int i = 0;
                try
                {
                    IPresentation firstPpt = null;
                    foreach (var file in FileList)
                    {
                        using (var ppIn = Presentation.Open(file))
                        {
                            for (i = 0; i < ppIn.Slides.Count; i++)
                            {
                                if (ppIn.Slides[i] == null)
                                    continue;

                                ISlide slide = ppIn.Slides[i].Clone();
                                ppOut.Slides.Add(slide);
                            }
                            ppIn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                

                var FilePath = GetSaveFilePath();
                ppOut.Save(FilePath);
                ppOut.Close();
                // open
                new Process
                {
                    StartInfo = new ProcessStartInfo(FilePath)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
                
        }

        private string GetSaveFilePath()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PPTX Image|*.pptx";
            saveFileDialog1.Title = "Save power point file";
            saveFileDialog1.ShowDialog();

            return saveFileDialog1.FileName;
        }
    }
}