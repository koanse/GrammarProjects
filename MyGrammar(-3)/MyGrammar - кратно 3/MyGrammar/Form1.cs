using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGrammar
{
    public partial class Form1 : Form
    {
        string[] text;
        string ts;
        public Form1()
        {
            InitializeComponent();
           
            ts="1008";
        }
        private void вЫходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void генерацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Grammar g = new Grammar();
            g.Generation(ts);


            for (int i = 0; i < g.tseps.Length; i++)
            {
                Tsep tsep = g.tseps[i];
                string[] tmp = new string[] {i.ToString(), tsep.s1, tsep.s2,
                    string.Format("{0}. {1}->{2}", tsep.rule + 1, g.rules[tsep.rule].left, g.rules[tsep.rule].right)};
                listView1.Items.Add(new ListViewItem(tmp));
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            
                string b = "B";
                string c = "E";
                ts = b + toolStripTextBox1.Text + c;
              
                
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнила Корнеева Т.А., АС-06");
        }
        
    }
}