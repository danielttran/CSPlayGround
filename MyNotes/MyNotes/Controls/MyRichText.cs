using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.UserControls
{
    public class MyRichText : RichTextBox
    {
        public MyRichText() : base()
        {
            AllowDrop = true;
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.None;
        }
    }
}
