using System;
using System.IO;
using System.Windows.Forms;

namespace PennyLane
{
    public partial class FormPennyLane : Form
    {
        public FormPennyLane()
        {
            InitializeComponent();
        }

        int dollars;
        int halfDollars;
        int quarters;
        int dimes;
        int nickels;
        int pennies;

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\penny.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    CalculateCoinsCount(line);
                    Display();
                    TxtResult.Text += "---------------------------------" + Environment.NewLine;
                }
            }
        }

        private void CalculateCoinsCount(string input)
        {
            string sum = "";
            int amount;
            int remaining = 0;
            string character;

            for (int i = 1; i < input.Length; i++)
            {
                character = (input.Substring(i, 1));

                if (character != ".")
                {
                    sum += character;
                }
            }

            amount = Convert.ToInt32(sum);

            dollars = amount / 100;
            amount = amount % 100;

            halfDollars = amount / 50;
            amount = amount % 50;

            quarters = amount / 25;
            amount = amount % 25;

            dimes = amount / 10;
            amount %= 10;

            nickels = amount / 5;
            amount %= 5;

            pennies = amount / 1;
            amount %= 1;
        }

        private void Display()
        {
            if (dollars > 0)
            {
                if (dollars == 1)
                    TxtResult.Text += dollars + " dollar" + Environment.NewLine;
                else
                    TxtResult.Text += dollars + " dollars" + Environment.NewLine;
            }

            if (halfDollars > 0)
            {
                TxtResult.Text += halfDollars + " half-dollars" + Environment.NewLine;
            }

            if (quarters > 0)
            {
                if (quarters == 1)
                    TxtResult.Text += quarters + " quarter" + Environment.NewLine;
                else
                    TxtResult.Text += quarters + " quarters" + Environment.NewLine;
            }

            if (dimes > 0)
            {
                if (dimes == 1)
                    TxtResult.Text += dimes + " dime" + Environment.NewLine;
                else
                    TxtResult.Text += dimes + " dimes" + Environment.NewLine;
            }

            if (nickels > 0)
            {
                if (nickels == 1)
                    TxtResult.Text += nickels + " nickel" + Environment.NewLine;
                else
                    TxtResult.Text += nickels + " nickels" + Environment.NewLine;
            }

            if (pennies > 0)
            {
                if (pennies == 1)
                    TxtResult.Text += pennies + " penny" + Environment.NewLine;
                else
                    TxtResult.Text += pennies + " pennies" + Environment.NewLine;
            }
        }
    }
}
