using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace ExpCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BigInteger exp;
            BigInteger.TryParse(textBox1.Text, out exp);
            textBox3.Text = "" + CalculateExp.GetExperienceFromLevel(exp);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BigInteger exp;
            BigInteger.TryParse(textBox2.Text, out exp);
            BigInteger expToLevel = CalculateExp.GetLevelFromExperience(exp);
            BigInteger remainder = exp - CalculateExp.GetExperienceFromLevel(expToLevel);
            Debug.WriteLine(remainder);
            textBox4.Text = "" + expToLevel;
            textBox5.Text = "" + CalculateExp.getExpUntilNextLevel(exp, expToLevel+1);
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
