using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotFuzzy;

namespace FuzzyLogic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LinguisticVariable water = new LinguisticVariable("Water");
            water.MembershipFunctionCollection.Add(new MembershipFunction("Cold", 0, 0, 20, 40));
            water.MembershipFunctionCollection.Add(new MembershipFunction("Tepid", 30, 50, 50, 70));
            water.MembershipFunctionCollection.Add(new MembershipFunction("Hot", 50, 80, 100, 100));

            LinguisticVariable power = new LinguisticVariable("Power");
            power.MembershipFunctionCollection.Add(new MembershipFunction("Low", 0, 25, 25, 50));
            power.MembershipFunctionCollection.Add(new MembershipFunction("High", 25, 50, 50, 75));

            FuzzyEngine fuzzyEngine = new FuzzyEngine();
            fuzzyEngine.LinguisticVariableCollection.Add(water);
            fuzzyEngine.LinguisticVariableCollection.Add(power);
            fuzzyEngine.Consequent = "Power";
            fuzzyEngine.FuzzyRuleCollection.Add(new FuzzyRule("IF (Water IS Cold) OR (Water IS Tepid) THEN Power IS High"));
            fuzzyEngine.FuzzyRuleCollection.Add(new FuzzyRule("IF (Water IS Hot) THEN Power IS Low"));

            water.InputValue = 60;

            try
            {
                MessageBox.Show(fuzzyEngine.Defuzzify().ToString());
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }
    }
}
