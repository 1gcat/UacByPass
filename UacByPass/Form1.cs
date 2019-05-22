using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UacByPass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "ComputerDefaults":
                    Methods.ComputerDefaultsExe(true, textBox1.Text);
                    break;
                default:
                    MessageBox.Show("选择错误");
                    break;
            }
            

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Methods.ComputerDefaultsExe(false, "");
            
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            textBox1.Text = path;
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
