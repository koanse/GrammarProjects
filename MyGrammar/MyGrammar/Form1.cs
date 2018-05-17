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
        int degree;
        public Form1()
        {
            InitializeComponent();
            degree = 10;
        }
        private void вЫходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void генерацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Grammar g = new Grammar();
            g.Generation(degree);
            for(int i = 0; i < g.steps.Length; i++)
            {
                Step step = g.steps[i];
                string[] tmp = new string[] {i.ToString(), step.s1, step.s2, step.rule.ToString(),
                    g.rules[step.rule].left, g.rules[step.rule].right,
                    g.rules[step.rule].comment };
                listView1.Items.Add(new ListViewItem(tmp));
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                degree = int.Parse(toolStripTextBox1.Text);
                if (degree < 0) throw new Exception();
            }
            catch
            {
                degree = 10;
                toolStripTextBox1.Text = "10";
            }
        }
    }
}