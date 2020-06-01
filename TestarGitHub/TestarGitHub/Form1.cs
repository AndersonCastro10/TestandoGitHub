using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TestarGitHub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add('a', false);
            checkedListBox1.Items.Add('b', false);
            checkedListBox1.Items.Add('c', false);
            checkedListBox1.Items.Add('d', false);
            checkedListBox1.Items.Add('e', false);
            checkedListBox1.Items.Add('f', false);
            checkedListBox1.Items.Add('g', false);
            checkedListBox1.Items.Add('h', false);
            checkedListBox1.Items.Add('i', false);
            checkedListBox1.Items.Add('j', false);


        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = true;
            comboBox1.Enabled = false;
            //checkedListBox1.Focus();
        }

        private void checkedListBox1_MouseLeave(object sender, EventArgs e)
        {
            //checkedListBox1.Visible = false;
            //comboBox1.Enabled = true;
            //PreencherComboBox();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            if (checkedListBox1.Visible)
            {
                checkedListBox1.Visible = false;
                comboBox1.Enabled = true;
                PreencherComboBox();
            }
        }

        // quando marcar a check list box, preencher combobox
        private void PreencherComboBox()
        {
            comboBox1.Text = "";

            foreach (var item in checkedListBox1.CheckedItems)
            {
                comboBox1.Text += item.ToString() + ",";
            }

            if (comboBox1.Text.Length > 0)
            {
                comboBox1.Text = comboBox1.Text.Substring(0, comboBox1.Text.Length - 1);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012,0);
        }
    }
}
