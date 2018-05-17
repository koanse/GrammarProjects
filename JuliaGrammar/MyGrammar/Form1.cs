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
        int denominator = 10;
        int difference = 10;
        public Form1()
        {
            InitializeComponent();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void generationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Grammar g = new Grammar();
            g.Generation(difference, denominator);
            for(int i = 0; i < g.steps.Length; i++)
            {
                Step step = g.steps[i];
                int ruleNum = step.rule + 1;
                string[] tmp = new string[] {i.ToString(), step.s1, step.s2, ruleNum.ToString(),
                    g.rules[step.rule].left, g.rules[step.rule].right,
                    g.rules[step.rule].comment };
                listView1.Items.Add(new ListViewItem(tmp));
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                difference = int.Parse(toolStripTextBox1.Text);
                if (difference < 0) throw new Exception();
            }
            catch
            {
                difference = 10;
                toolStripTextBox1.Text = "10";
            }
        }
        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                denominator = int.Parse(toolStripTextBox2.Text);
                if (denominator < 0) throw new Exception();
            }
            catch
            {
                denominator = 10;
                toolStripTextBox2.Text = "10";
            }
        }
    }
}