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
        LinguisticVariable dSpeed, dAltitude, dWind, dLand;
        MembershipFunctionCollection wind, altitude, speed, land;
        FuzzyEngine fuzz;
        OutputForm newForm;
        public static Image outputImage;

        private void button1_Click(object sender, EventArgs e)
        {
            AddMembers();
            SetRules();
            newForm = new OutputForm();
            double res = fuzz.Defuzzify();
            Console.WriteLine(res);
            if (res < 1.0)
                outputImage = Properties.Resources.dont;
            else if (res < 1.7)
                outputImage = Properties.Resources.could;
            else
                outputImage = Properties.Resources.go;
            newForm.ShowImage(outputImage);
            newForm.Show();           
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void AddMembers()
        {
            fuzz = new FuzzyEngine();
            wind = new MembershipFunctionCollection();
            wind.Add(new MembershipFunction("OPPOSITE", -2.0, -0.5, -0.5, 0));
            wind.Add(new MembershipFunction("NEUTRAL", -0.1,0.9,0.9,1.1));
            wind.Add(new MembershipFunction("PARALLEL", 1.0,1.5,1.5,1.9));
            dWind = new LinguisticVariable("Wind", wind);

            altitude = new MembershipFunctionCollection();
            altitude.Add(new MembershipFunction("LOW", 0.0,1.0, 1.0, 2.3));
            altitude.Add(new MembershipFunction("OK", 2.0, 3.0, 3.0, 3.7));
            altitude.Add(new MembershipFunction("HIGH", 3.5, 4.3, 4.3, 4.9));
            dAltitude = new LinguisticVariable("Altitude", altitude);

            speed = new MembershipFunctionCollection();
            speed.Add(new MembershipFunction("SLOW", 0.0, 1.8,2.5,3.0));
            speed.Add(new MembershipFunction("FINE", 2.9,4.2,5.5,6.0));
            speed.Add(new MembershipFunction("FAST", 5.8,6.5,8.1,9.0));
            dSpeed = new LinguisticVariable("Speed", speed);

            land = new MembershipFunctionCollection();
            land.Add(new MembershipFunction("UNABLE", 0.0, 0.5, 0.5, 1.0));
            land.Add(new MembershipFunction("COULD", 0.8, 1.3, 1.5, 1.7));
            land.Add(new MembershipFunction("SHOULD", 1.6, 2.3, 2.5, 3.0));
            dLand = new LinguisticVariable("Land", land);

        }

        public void SetRules()
        {
            fuzz.LinguisticVariableCollection.Add(dWind);
            fuzz.LinguisticVariableCollection.Add(dAltitude);
            fuzz.LinguisticVariableCollection.Add(dSpeed);
            fuzz.LinguisticVariableCollection.Add(dLand);
            fuzz.Consequent = "Land";
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS LOW) AND (Speed IS SLOW) THEN Land IS UNABLE"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS LOW) AND (Speed IS FINE) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS LOW) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS OK) AND (Speed IS SLOW) THEN Land IS UNABLE"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS OK) AND (Speed IS FINE) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS OK) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS HIGH) AND (Speed IS SLOW) THEN Land IS UNABLE"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS HIGH) AND (Speed IS FINE) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS OPPOSITE) AND (Altitude IS HIGH) AND (Speed IS FAST) THEN Land IS COULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS LOW) AND (Speed IS SLOW) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS LOW) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS LOW) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS OK) AND (Speed IS SLOW) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS OK) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS OK) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS HIGH) AND (Speed IS SLOW) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS HIGH) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS NEUTRAL) AND (Altitude IS HIGH) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS LOW) AND (Speed IS SLOW) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS LOW) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS LOW) AND (Speed IS FAST) THEN Land IS COULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS OK) AND (Speed IS SLOW) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS OK) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS OK) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS HIGH) AND (Speed IS SLOW) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS HIGH) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS PARALLEL) AND (Altitude IS HIGH) AND (Speed IS FAST) THEN Land IS SHOULD"));


            GetData();
        }


        public void GetData()
        {
            dWind.InputValue = Convert.ToDouble(textBox2.Text);
            //dWind.Fuzzify("NEUTRAL");


            dAltitude.InputValue = Convert.ToDouble(textBox1.Text);
            //dAltitude.Fuzzify("OK");

            dSpeed.InputValue = Convert.ToDouble(textBox3.Text);
            //dSpeed.Fuzzify("FINE");
        }
    }
}
