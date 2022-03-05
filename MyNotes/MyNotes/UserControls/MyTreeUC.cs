using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotes.UserControls
{
    public partial class MyTreeUC : UserControl
    {
        public MyTreeUC()
        {
            InitializeComponent();

            myTreeView.BeginUpdate();
            myTreeView.Nodes.Add("Parent");
            myTreeView.Nodes[0].Nodes.Add("Child 1");
            myTreeView.Nodes[0].Nodes.Add("Child 2");
            myTreeView.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            myTreeView.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            myTreeView.EndUpdate();
        }
    }
}
