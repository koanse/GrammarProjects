using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace MyGrammar
{
    static class Program
    {
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
            rules = new Rule[21];
            rules[0] = new Rule("S", "F1DP", "");
            rules[1] = new Rule("D", "1D", "");
            rules[2] = new Rule("D", "1X/X1", "");
            rules[3] = new Rule("X/X", "1X/X1", "");
            
            rules[4] = new Rule("X/X", "YP/S", "");
            rules[5] = new Rule("1Y", "Y1", "");
            rules[6] = new Rule("FY", "FZ", "");
            rules[7] = new Rule("Z111", "1Z", "");
            rules[8] = new Rule("ZP", "TP", "");
            rules[9] = new Rule("Z1P", "AP1", "");
            rules[10] = new Rule("Z11P", "AP2", "");
            
            rules[11] = new Rule("1TP", "A1P0", "");
            rules[12] = new Rule("1A", "A1", "");
            rules[13] = new Rule("FA", "FZ", "");
            rules[14] = new Rule("FTP", "M", "");

            rules[15] = new Rule("M0", "0M", "");
            rules[16] = new Rule("M1", "1M", "");
            rules[17] = new Rule("M2", "2M", "");
            
            rules[18] = new Rule("M/S", "/SZ", "");
            rules[19] = new Rule("SA", "SZ", "");
            rules[20] = new Rule("STP", "", "");
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
        public string Generation(int difference, int denominator)
        {
            ArrayList tmpSteps = new ArrayList();
            s = "S";
            for(int i = 0; i < difference; i++)
            {
                string oldS = s;
                int ruleNum = ApplyRule(0);
                tmpSteps.Add(new Step(ruleNum, oldS, s));
            }
            for (int i = 0; i < denominator; i++)
            {
                string oldS = s;
                int ruleNum = ApplyRule(2);
                tmpSteps.Add(new Step(ruleNum, oldS, s));
            }
            while (true)
            {
                string oldS = s;
                int ruleNum = ApplyRule(4);
                if (ruleNum < 0) break;
                tmpSteps.Add(new Step(ruleNum, oldS, s));
            }
            steps = (Step[])tmpSteps.ToArray(typeof(Step));
            return s;
        }
        public Step[] steps;
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
    public class Step
    {
        public int rule;
        public string s1, s2;
        public Step(int r, string str1, string str2)
        {
            rule = r;
            s1 = str1;
            s2 = str2;
        }
    }
}