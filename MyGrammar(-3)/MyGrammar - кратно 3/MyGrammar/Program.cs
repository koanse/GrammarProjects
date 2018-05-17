using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace MyGrammar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Grammar
    {
        public string s;
        public Rule[] rules;
        public Grammar()
        {
            rules = new Rule[25];
            rules[0] = new Rule("S", "B0IE", "");

            rules[1] = new Rule("0I", "3", "");
            rules[2] = new Rule("1I", "4", "");
            rules[3] = new Rule("2I", "5", "");
            rules[4] = new Rule("3I", "6", "");
            rules[5] = new Rule("4I", "7", "");
            rules[6] = new Rule("5I", "8", "");
            rules[7] = new Rule("6I", "9", "");
            rules[8] = new Rule("7I", "C0", "");
            rules[9] = new Rule("8I", "C1", "");
            rules[10] = new Rule("9I", "C2", "");

            rules[11] = new Rule("0C", "1", "");
            rules[12] = new Rule("1C", "2", "");
            rules[13] = new Rule("2C", "3", "");
            rules[14] = new Rule("3C", "4", "");
            rules[15] = new Rule("4C", "5", "");
            rules[16] = new Rule("5C", "6", "");
            rules[17] = new Rule("6C", "7", "");
            rules[18] = new Rule("7C", "8", "");
            rules[19] = new Rule("8C", "9", "");
            rules[20] = new Rule("9C", "C0", "");

            rules[21] = new Rule("BC", "B1", "");
            rules[22] = new Rule("E", "IE", "");

            rules[23] = new Rule("B", "", "");
            rules[24] = new Rule("E", "", "");

        }
        int ApplyRule(int min)
        {
            for (int i = min; i < rules.Length; i++)
            {
                Rule r = rules[i];
                string tmp = s.Replace(r.left, r.right);
                if (tmp != s)
                {
                    s = tmp;
                    return i;
                }

            }
            return -1;
        }
        public string Generation(string ts)
        {
            ArrayList tmpTseps = new ArrayList();
            s = "S";

            while (ts != s)
            {
                string oldS = s;
                int i = ApplyRule(0);
                if (i < 0) break;
                tmpTseps.Add(new Tsep(i, oldS, s));
            }
            while (ts == s)
            {
                string oldS = s;
                int i = ApplyRule(23);
                if (i < 0) break;
                tmpTseps.Add(new Tsep(i, oldS, s));
            }
            while (ts != s)
            {
                string oldS = s;
                int i = ApplyRule(24);
                if (i < 0) break;
                tmpTseps.Add(new Tsep(i, oldS, s));
            }
            tseps = (Tsep[])tmpTseps.ToArray(typeof(Tsep));
            MessageBox.Show("Сгенерирована цепочка:" + s, "Генерация закончена",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            return s;
        }
        public Tsep[] tseps;
    }
    public class Rule
    {
        public string left;
        public string right;
        public string comment;
        public Rule(string l, string r, string c)
        {
            left = l;
            right = r;
            comment = c;
        }
    }
    public class Tsep
    {
        public int rule;
        public string s1, s2;
        public Tsep(int r, string str1, string str2)
        {
            rule = r;
            s1 = str1;
            s2 = str2;
        }
    }
}