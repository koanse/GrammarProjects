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
            rules = new Rule[21];
            rules[0] = new Rule("S", "FK111L", "первое правило");
            rules[1] = new Rule("K1", "1111K", "увеличение на число три цепочки при перемещении нетерминала K вправо");
                        
            rules[2] = new Rule("KL", "XL", "дошли до правого края цепочки и закончили генерацию единиц");
            rules[3] = new Rule("1X", "X1", "перемещение нетерминала X влево");
            rules[4] = new Rule("FX", "FY", "начинаем преобразование сгенерированных единиц в десятичное число");
            rules[5] = new Rule("FK", "FY", "начинаем преобразование сгенерированных единиц в десятичное число");
            rules[6] = new Rule("Y1111111111", "1Y", "заменяем десять единиц одной и перемещаем нетерминал Y");
            
            rules[7] = new Rule("YL", "ZL0", "если остаток от деления равен 0, пишем очередную цифру числа: 0");

            rules[8] = new Rule("Y1L", "ZL1", "если остаток от деления равен 1, пишем очередную цифру числа: 1");
            rules[9] = new Rule("Y11L", "ZL2", "если остаток от деления равен 2, пишем очередную цифру числа: 2");
            rules[10] = new Rule("Y111L", "ZL3", "если остаток от деления равен 3, пишем очередную цифру числа: 3");
            rules[11] = new Rule("Y1111L", "ZL4", "если остаток от деления равен 4, пишем очередную цифру числа: 4");
            rules[12] = new Rule("Y11111L", "ZL5", "если остаток от деления равен 5, пишем очередную цифру числа: 5");
            rules[13] = new Rule("Y111111L", "ZL6", "если остаток от деления равен 6, пишем очередную цифру числа: 6");
            rules[14] = new Rule("Y1111111L", "ZL7", "если остаток от деления равен 7, пишем очередную цифру числа: 7");
            rules[15] = new Rule("Y11111111L", "ZL8", "если остаток от деления равен 8, пишем очередную цифру числа: 8");
            rules[16] = new Rule("Y111111111L", "ZL9", "если остаток от деления равен 9, пишем очередную цифру числа: 9");

            rules[17] = new Rule("1Z", "P1", "начинаем перемещение нетерминала P влево");
            rules[18] = new Rule("1P", "P1", "перемещение нетерминала P влево");
            rules[19] = new Rule("FP", "FY", "начинаем деление на 10");

            rules[20] = new Rule("FZL", "", "если деление закончено, уничтожаем вспомогательные нетерминалы");
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
        public string Generation(int degree)
        {
            ArrayList tmpSteps = new ArrayList();
            s = "S";
            while (s.Length != 3 * degree + 3)
            {
                string oldS = s;
                int i = ApplyRule(0);
                tmpSteps.Add(new Step(i, oldS, s));
            }

            while (true)
            {
                string oldS = s;
                int i = ApplyRule(2);
                if (i < 0) break;
                tmpSteps.Add(new Step(i, oldS, s));
            }
            steps = (Step[])tmpSteps.ToArray(typeof(Step));
            MessageBox.Show("Сгенерирована цепочка:" + s, "Генерация закончена",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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