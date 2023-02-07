using GrantHornerReading;

namespace Gui
{
    public partial class Form1 : Form
    {
        GrantHornerSystem ghs = new GrantHornerSystem(10);
        public Form1()
        {
            InitializeComponent();
            PopulateDropdown();
        }

        private void PopulateDropdown()
        {
            var list1 = ghs.lists[0];
            foreach (var item in list1)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = 0;

            var list2 = ghs.lists[1];
            foreach (var item in list2)
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.SelectedIndex = 0;

            var list3 = ghs.lists[2];
            foreach (var item in list3)
            {
                comboBox3.Items.Add(item);
            }
            comboBox3.SelectedIndex = 0;

            var list4 = ghs.lists[3];
            foreach (var item in list4)
            {
                comboBox4.Items.Add(item);
            }
            comboBox4.SelectedIndex = 0;

            var list5 = ghs.lists[4];
            foreach (var item in list5)
            {
                comboBox5.Items.Add(item);
            }
            comboBox5.SelectedIndex = 0;

            var list6 = ghs.lists[5];
            foreach (var item in list6)
            {
                comboBox6.Items.Add(item);
            }
            comboBox6.SelectedIndex = 0;

            var list7 = ghs.lists[6];
            foreach (var item in list7)
            {
                comboBox7.Items.Add(item);
            }
            comboBox7.SelectedIndex = 0;

            var list8 = ghs.lists[7];
            foreach (var item in list8)
            {
                comboBox8.Items.Add(item);
            }
            comboBox8.SelectedIndex = 0;

            var list9 = ghs.lists[8];
            foreach (var item in list9)
            {
                comboBox9.Items.Add(item);
            }
            comboBox9.SelectedIndex = 0;

            var list10 = ghs.lists[9];
            foreach (var item in list10)
            {
                comboBox10.Items.Add(item);
            }
            comboBox10.SelectedIndex = 0;

        }

        // rotate list 
        private List<string> rotateList(List<string> inList, int newIndex0)
        {
            int length = inList.Count;
            List<string> result = new List<string>(length);
            result.AddRange(inList.GetRange(newIndex0, length - newIndex0));
            result.AddRange(inList.GetRange(0, newIndex0));

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RotateLists();

            ghs.PrintChapters(36524);
        }

        private void RotateLists()
        {
            // rotate 10 lists.
            int index1 = comboBox1.SelectedIndex;
            ghs.lists[0] = rotateList(ghs.lists[0], index1);

            int index2 = comboBox2.SelectedIndex;
            ghs.lists[1] = rotateList(ghs.lists[1], index2);

            int index3 = comboBox3.SelectedIndex;
            ghs.lists[2] = rotateList(ghs.lists[2], index3);

            int index4 = comboBox4.SelectedIndex;
            ghs.lists[3] = rotateList(ghs.lists[3], index4);

            int index5 = comboBox5.SelectedIndex;
            ghs.lists[4] = rotateList(ghs.lists[4], index5);

            int index6 = comboBox6.SelectedIndex;
            ghs.lists[5] = rotateList(ghs.lists[5], index6);

            int index7 = comboBox7.SelectedIndex;
            ghs.lists[6] = rotateList(ghs.lists[6], index7);

            int index8 = comboBox8.SelectedIndex;
            ghs.lists[7] = rotateList(ghs.lists[7], index8);

            int index9 = comboBox9.SelectedIndex;
            ghs.lists[8] = rotateList(ghs.lists[8], index9);

            int index10 = comboBox10.SelectedIndex;
            ghs.lists[9] = rotateList(ghs.lists[9], index10);
        }
    }
}