using Microsoft.VisualBasic.Logging;
using Syncfusion;
using Syncfusion.Presentation;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PowerPoint
{
    public partial class PowerPointHelperForm : Form
    {
        public PowerPointHelperForm()
        {
            InitializeComponent();
        }
        public PowerPointHelperForm(string title)
        {
            InitializeComponent();
            this.Text = title;

            // recover if any
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PPHelper.txt";
            if (File.Exists(path))
            {
                var content = File.ReadAllText(path);
                if (string.IsNullOrEmpty(content) == false)
                {
                    foreach (var fileName in content.Split('\n'))
                    {
                        if (string.IsNullOrEmpty(fileName) == false)
                        {
                            FileList.Add(fileName.Trim('\r'));
                        }
                    }
                    RefreshList();
                }
            }
        }


        private List<string> fileList;

        public List<string> FileList
        {
            get
            {
                if (fileList == null)
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

                foreach (var file in files)
                {
                    if (string.IsNullOrEmpty(file) == false)
                    {
                        FileList.Add(file);
                    }
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

            if (string.IsNullOrEmpty(currentSelection) == false)
            {
                var item = listView.FindItemWithText(currentSelection);
                if (listView.Items.Count > 0 && item != null)
                {
                    listView.Items[item.Index].Selected = true;
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            FileList.Clear();
            RefreshList();
        }

        // Tab #1 Join PPT files
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (FileList.Count == 0)
                return;

            using (var ppOut = Presentation.Create())
            {
                int i = 0;
                foreach (var slide in ppOut.Slides)
                {
                    slide.SlideSize.Type = SlideSizeType.Custom;
                }
                try
                {
                    foreach (var file in FileList)
                    {
                        if (File.Exists(file) == false)
                            continue;

                        using (var ppIn = Presentation.Open(file))
                        {
                            bool addKeepSource = true;
                            for (i = 0; i < ppIn.Slides.Count; i++)
                            {
                                if (ppIn.Slides[i] == null)
                                    continue;

                                ISlide slide = ppIn.Slides[i].Clone();

                                try
                                {
                                    if (addKeepSource == true)
                                    {
                                        ppOut.Slides.Add(slide, PasteOptions.SourceFormatting, ppIn);
                                    }
                                    else
                                    {
                                        ppOut.Slides.Add(slide);
                                    }
                                }
                                catch
                                {
                                    addKeepSource = false;
                                    ppOut.Slides.Add(slide);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var exeption = ex.Message;
                }

                SavePPFile(ppOut);
            }
        }

        private void SavePPFile(IPresentation ppOut)
        {
            try
            {
                var FilePath = GetSaveFilePath();
                if (string.IsNullOrEmpty(FilePath) == false)
                {
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
            catch (Exception ex)
            {
                var err = ex.ToString();
            }
            finally
            {
                // also save the filelist to a tempt location in case of crash
                // we can recover from, like notepad++
                var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PPHelper.txt";
                File.WriteAllText(path, string.Empty);
                File.WriteAllText(path, string.Join(Environment.NewLine, FileList));
            }
        }


        private static string GetSaveFilePath()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PPTX Image|*.pptx";
            saveFileDialog1.Title = "Save power point file";
            saveFileDialog1.ShowDialog();

            return saveFileDialog1.FileName;
        }

        string currentSelection = "";

        private void MoveUpBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSelection) == false)
            {
                var index = FileList.IndexOf(currentSelection);
                if (index > 0)
                {
                    var temp = FileList[index - 1];
                    FileList[index] = temp;
                    FileList[index - 1] = currentSelection;
                }
            }

            RefreshList();
        }

        private void MoveDownBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSelection) == false)
            {
                var index = FileList.IndexOf(currentSelection);
                if (index < FileList.Count - 1)
                {
                    var temp = FileList[index + 1];
                    FileList[index] = temp;
                    FileList[index + 1] = currentSelection;
                }
            }

            RefreshList();
        }

        private void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSelection) == false)
            {
                FileList.Remove(currentSelection);
                RefreshList();
            }
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            currentSelection = e.Item.Text;
        }

        //*********************************************************************************************************************************************************

        // Tab #2 Create PPT file
        private void clearTextBtn_Click(object sender, EventArgs e)
        {
            ppContentTb.Text = String.Empty;
        }

        private void SavePpBtn_Click(object sender, EventArgs e)
        {
            using (var ppOut = Presentation.Create())
            {
                var pptContent = ppContentTb.Text;
                var ppParagraph = pptContent.Split("\n\n\n");
                int margin = 2;
                bool BoldAllText = boldFontCb.Checked;
                bool RemoveAllSpace = noSpaceAndNewLineCb.Checked;

                foreach (var p in ppParagraph)
                {
                    // dimension
                    ISlide slide = ppOut.Slides.Add(SlideLayoutType.Blank);
                    slide.SlideSize.Type = SlideSizeType.Custom;
                    slide.SlideSize.Width = slide.SlideSize.Height * 16 / 10;

                    // color
                    slide.Background.Fill.FillType = FillType.Solid;
                    ISolidFill fill = slide.Background.Fill.SolidFill;


                    fill.Color = ColorObject.FromArgb(tab2BackgroundColor.A,
                                                      tab2BackgroundColor.R,
                                                      tab2BackgroundColor.G,
                                                      tab2BackgroundColor.B);

                    IShape textbox = slide.AddTextBox(margin,
                                                      margin,
                                                      slide.SlideSize.Width - margin,
                                                      slide.SlideSize.Height - margin);

                    IParagraph paragraph = textbox.TextBody.AddParagraph();

                    ITextPart textPart = paragraph.AddTextPart();
                    var text = p.Trim('\n');
                    if (RemoveAllSpace)
                    {
                        text = text.Replace("\n", " ");
                        text = Regex.Replace(text, @"\s+", " ");
                    }

                    textPart.Text = text;
                    textPart.Font.FontName = fontNameTb.Text;
                    if (float.TryParse(fontSizeTb.Text, out float fontSize))
                    {
                        textPart.Font.FontSize = fontSize;
                    }

                    textPart.Font.Bold = BoldAllText;

                    IFont font = textPart.Font;
                    font.Color = ColorObject.FromArgb(tab2TextColor.A,
                                                      tab2TextColor.R,
                                                      tab2TextColor.G,
                                                      tab2TextColor.B);
                }

                SavePPFile(ppOut);
            }
        }

        private Color _tab2BackgroundColor = Color.Black;
        public Color tab2BackgroundColor
        {
            get
            {
                return _tab2BackgroundColor;
            }
            set
            {
                _tab2BackgroundColor = value;
                tab2UpdatePpText();
            }
        }

        private Color _tab2TextColor = Color.White;
        public Color tab2TextColor
        {
            get
            {
                return _tab2TextColor;
            }

            set
            {
                _tab2TextColor = value;
                tab2UpdatePpText();
            }
        }

        private void selectFontColorBtn_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            tab2TextColor = colorDialog.Color;
        }

        private void selectBackgroundColorBtn_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            tab2BackgroundColor = colorDialog.Color;
        }

        private void tab2UpdatePpText()
        {
            ppContentTb.SelectAll();
            ppContentTb.SelectionColor = tab2TextColor;

            ppContentTb.BackColor = tab2BackgroundColor;
        }


    }
}