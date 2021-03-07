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
        LinguisticVariable dSpeed;
        LinguisticVariable dAltitude;
        LinguisticVariable dWind;


        public Form1()
        {
            InitializeComponent();
        }

        public AddMembers()
        {
            MembershipFunctionCollection wind = new MembershipFunctionCollection();
            wind.Add(new MembershipFunction("WEAK", 0.0, 0.0, 5.0, 10.0));
            wind.Add(new MembershipFunction("MEDIUM", 8.0, 8.0, 15.0, 18.0));
            wind.Add(new MembershipFunction("STRONG", 15.0, 15.0, 25.0, 29.0));


            MembershipFunctionCollection altitude = new MembershipFunctionCollection();
            altitude.Add(new MembershipFunction("LOW", 0.0, 0.0, 12000.0, 15000.0));
            altitude.Add(new MembershipFunction("OK", 13000.0, 13000.0, 25000.0, 35000.0));
            altitude.Add(new MembershipFunction("HIGH", 33000.0, 33000.0, 45000.0, 50000.0));

            MembershipFunctionCollection speed = new MembershipFunctionCollection();
            speed.Add(new MembershipFunction("SLOW", 0.0, 0.0, 12000.0, 15000.0));
            speed.Add(new MembershipFunction("FINE", 13000.0, 13000.0, 25000.0, 35000.0));
            speed.Add(new MembershipFunction("FAST", 33000.0, 33000.0, 45000.0, 50000.0));
        }

    }
}
