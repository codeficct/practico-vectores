using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticoDeVectores
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        int currentExercise = 0;
        bool isDisable = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void ActivateButton(Object senderBtn, int currentValue)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentButton = (Button)senderBtn;
                currentButton.BackColor = Color.LightGreen;
                // buttonRun.Enabled = true;
                // labelRun.Text = "Ejercicio " + currentValue.ToString();
            }
        }

        public void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.White;
                // labelParam1.Visible = false;
                // textBoxParam1.Visible = false;
                // textBoxMax.Enabled = true;
                // textBoxMin.Enabled = true;
                isDisable = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Ejercicio 1";
            button2.Text = "Ejercicio 2";
            button3.Text = "Ejercicio 3";
            button4.Text = "Ejercicio 4";
            button5.Text = "Ejercicio 5";
            button6.Text = "Ejercicio 6";
            button7.Text = "Ejercicio 7";
            button8.Text = "Ejercicio 8";
            button9.Text = "Ejercicio 9";
            button10.Text = "Ejercicio 10";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 1);
            labelQuestion.Text = "1. Cargar ne elementos el vector con la fórmula: b^0 ; b^1 ; b^2;…";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 10);
        }
    }
}
