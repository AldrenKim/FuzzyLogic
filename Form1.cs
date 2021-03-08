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
                fuzz = new FuzzyEngine();
                AddMembers();
                SetRules();
            newForm = new OutputForm();
            double res = fuzz.Defuzzify();
            if (res < 4.0)
                outputImage = Properties.Resources.dont;
            else if (res < 7.0)
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
            wind = new MembershipFunctionCollection();
            wind.Add(new MembershipFunction("WEAK", 0.0, 7.0, 7.0, 10.0));
            wind.Add(new MembershipFunction("MEDIUM", 8.0, 15.0, 15.0, 18.0));
            wind.Add(new MembershipFunction("STRONG", 16.0, 25.0, 25.0, 29.0));
            dWind = new LinguisticVariable("Wind", wind);

            altitude = new MembershipFunctionCollection();
            altitude.Add(new MembershipFunction("LOW", 0.0,12000.0, 12000.0, 15000.0));
            altitude.Add(new MembershipFunction("OK", 13000.0, 25000.0, 25000.0, 35000.0));
            altitude.Add(new MembershipFunction("HIGH", 33000.0, 40000.0, 40000.0, 45000.0));
            dAltitude = new LinguisticVariable("Altitude", altitude);

            speed = new MembershipFunctionCollection();
            speed.Add(new MembershipFunction("SLOW", 0.0, 75.0, 75.0, 115.0));
            speed.Add(new MembershipFunction("FINE", 100.0, 180.0, 180.0, 230.0));
            speed.Add(new MembershipFunction("FAST", 215.0, 260.0, 260.0, 300.0));
            dSpeed = new LinguisticVariable("Speed", speed);

            land = new MembershipFunctionCollection();
            land.Add(new MembershipFunction("UNABLE", 0.0, 2.0, 2.0, 4.0));
            land.Add(new MembershipFunction("COULD", 3.0, 5.0, 5.0, 7.0));
            land.Add(new MembershipFunction("SHOULD", 6.0, 9.0, 9.0, 10.0));
            dLand = new LinguisticVariable("Land", land);

        }

        public void SetRules()
        {
            fuzz.LinguisticVariableCollection.Add(dWind);
            fuzz.LinguisticVariableCollection.Add(dAltitude);
            fuzz.LinguisticVariableCollection.Add(dSpeed);
            fuzz.LinguisticVariableCollection.Add(dLand);
            fuzz.Consequent = "Land";
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS LOW) AND (Speed IS SLOW) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS LOW) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS LOW) AND (Speed IS FAST) THEN Land IS UNABLE"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS OK) AND (Speed IS SLOW) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS OK) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS OK) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS HIGH) AND (Speed IS SLOW) THEN Land IS UNABLE"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS HIGH) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS WEAK) AND (Altitude IS HIGH) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS LOW) AND (Speed IS SLOW) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS LOW) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS LOW) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS OK) AND (Speed IS SLOW) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS OK) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS OK) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS HIGH) AND (Speed IS SLOW) THEN Land IS UNABLE"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS HIGH) AND (Speed IS FINE) THEN Land IS SHOULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS MEDIUM) AND (Altitude IS HIGH) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS LOW) AND (Speed IS SLOW) THEN Land IS UNABLE"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS LOW) AND (Speed IS FINE) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS LOW) AND (Speed IS FAST) THEN Land IS COULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS OK) AND (Speed IS SLOW) THEN Land IS UNABLE"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS OK) AND (Speed IS FINE) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS OK) AND (Speed IS FAST) THEN Land IS SHOULD"));

            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS HIGH) AND (Speed IS SLOW) THEN Land IS UNABLE"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS HIGH) AND (Speed IS FINE) THEN Land IS COULD"));
            fuzz.FuzzyRuleCollection.Add(new FuzzyRule("IF (Wind IS STRONG) AND (Altitude IS HIGH) AND (Speed IS FAST) THEN Land IS SHOULD"));


            GetData();
        }


        public void GetData()
        {
            dWind.InputValue = Convert.ToDouble(numericUpDown2.Value);
            dWind.Fuzzify("MEDIUM");
            /*if (dWind.InputValue < 10.0)
                dWind.Fuzzify("WEAK");
            else if (dWind.InputValue < 18.0)
                dWind.Fuzzify("MEDIUM");
            else
                dWind.Fuzzify("STRONG");*/


            dAltitude.InputValue = Convert.ToDouble(numericUpDown1.Value);
            dAltitude.Fuzzify("HIGH");
            /*if (dAltitude.InputValue < 15000.0)
                dAltitude.Fuzzify("LOW");
            else if (dAltitude.InputValue < 35000.0)
                dAltitude.Fuzzify("OK");
            else
                dAltitude.Fuzzify("HIGH");*/

            dSpeed.InputValue = Convert.ToDouble(numericUpDown3.Value);
            dSpeed.Fuzzify("FINE");
            /*if (dSpeed.InputValue < 115.0)
                dSpeed.Fuzzify("SLOW");
            else if (dSpeed.InputValue < 230.0)
                dSpeed.Fuzzify("FINE");
            else
                dSpeed.Fuzzify("FAST");*/
        }
    }
}
