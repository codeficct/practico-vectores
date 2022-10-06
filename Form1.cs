using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticoDeVectores
{
    public partial class Form1 : Form
    {
        Vector objVector1, objVector2;
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
                buttonRun.Enabled = true;
                currentExercise = currentValue;
                buttonRun.Text = $"Ejecutar {currentValue}";

                buttonSet.Enabled = true;
                buttonGet.Enabled = true;
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

        private void errorHandler(string message)
        {
            MessageBox.Show(message, "Datos incorrectos o faltantes.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            labelQuestion2.ResetText();
            labelQuestion3.ResetText();
            labelQuestion4.ResetText();

            buttonRun.Enabled = false;
            buttonSet.Enabled = false;
            buttonGet.Enabled = false;

            objVector1 = new Vector();
            objVector2 = new Vector();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result1.Clear();
            Result2.Clear();
            textInput1.Clear();
            textInput2.Clear();
            textInput3.Clear();
        }

        private void InputsToSetRandom()
        {
            labelInput1.Visible = true;
            labelInput1.Text = "Cantidad";
            textInput1.Visible = true;

            labelInput2.Visible = true;
            labelInput2.Text = "Min";
            textInput2.Visible = true;

            labelInput3.Visible = true;
            labelInput3.Text = "Max";
            textInput3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 1);
            labelQuestion1.Text = "1. Cargar ne elementos el vector con la fórmula: b^0 ; b^1 ; b^2;…";
            labelQuestion2.Text = "Si ne=4 y b=3 => 3^0; 3^1; 3^2; 3^3;… V{1,3,9,27}";
            labelQuestion3.Text = "Si ne=8 y b=2 => 2^0; 2^1; 2^2; 2^3;… V{1,2,4,8,16,32,64,128}";

            labelInput1.Text = "Num. Elementos (ne)";
            labelInput1.Visible = true;
            textInput1.Visible = true;

            labelInput2.Visible = true;
            labelInput2.Text = "  base (b)";
            textInput2.Visible = true;

            labelInput3.Visible = false;
            textInput3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 2);
            labelQuestion1.Text = "2. Acumular con elementos del vector. V{2,3,6,4,1,7}";
            labelQuestion2.Text = "y recordando Fibonacci: 0,1,1,2,3,5,8,13… ";
            labelQuestion3.Text = "F=2/0! – 3/1! + 6/1! – 4/2! + 1/3! – 7/5!";

            InputsToSetRandom();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 3);
            labelQuestion1.Text = "3. Contar elementos que se encuentren en posiciones que sean sus";
            labelQuestion2.Text = "submúltiplos, Si V{3,1,9,5,12,12,6,7}";
            labelQuestion3.Text = "Posiciones 1,2,3,4, 5, 6 , 7,8 => 3 ; porque 1 es submult de 3, 3 de 9, 6 de 12";

            InputsToSetRandom();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 4);
            labelQuestion1.Text = "4. Encontrar la media de las posiciones con la formula “mágica”.";
            labelQuestion2.Text = "Vi+(i-1)*r sea Vi=5 y r=3 (r: sinónimo de multiplicador)";
            labelQuestion3.Text = "V{5,4,6,9,8,4,5,7,2, 5, 4, 2, 6, 3} => media=22/4=5,5";
            labelQuestion4.Text = "1,2,3,4,5,6,7,8,9,10,11,12,13,14 <= índices.";

            InputsToSetRandom();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 5);
            labelQuestion1.Text = "5. Seleccionar los elementos primos y no primos.";
            labelQuestion2.Text = "V{1,2,3,4,5,6,7,8,9,10}";
            labelQuestion3.Text = "El resultado es: R1{V{2,3,5,7} “primos” y R2{V{1,4,6,8,9} “no primos”";
            labelQuestion4.ResetText();

            InputsToSetRandom();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 6);
            labelQuestion1.Text = "6. Invertir los elementos del vector del rango a y b. Sea a=3 y b=7";
            labelQuestion2.Text = "V{1,2,3,4,5,6,7,8,9} => V{1,2,7,6,5,4,3,8,9}";
            labelQuestion3.Text = "a=3 y b=7 a y b son posiciones.";
            labelQuestion4.ResetText();

            InputsToSetRandom();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 7);
            labelQuestion1.Text = "7. Verificar si todo los elementos son únicos, ósea que no tienen repeticiones.";
            labelQuestion2.Text = "V{3,7,13,2,5,} el resultado es: TRUE";
            labelQuestion3.Text = "V{2,7,3,5,6,4,5,8,3,3} el resultados es: FALSE";
            labelQuestion4.ResetText();

            InputsToSetRandom();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 8);
            labelQuestion1.Text = "8. Encontrar la intersección de elementos (Teoría de conjuntos).";
            labelQuestion2.Text = "V{4,7,6,1,8,2} y V2{V{5,7,9,4,1}";
            labelQuestion3.Text = "El resultado es: V3{ V{ 4,7,1}";
            labelQuestion4.ResetText();

            InputsToSetRandom();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 9);
            labelQuestion1.Text = "9. Encontrar la unión de elementos (Teoría de conjuntos)";
            labelQuestion2.Text = "V{4,7,6,1,8,2} y V2{V=5,7,9,4,1}";
            labelQuestion3.Text = "El resultado es: V3{ 4,7,6,1,8,2,5,9}";
            labelQuestion4.Text = "En el resultado no puede haber elementos repetidos.";

            InputsToSetRandom();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 10);
            labelQuestion1.Text = "10. Verificar si el segmento a y b esta ordenado; si a=3 y b=10";
            labelQuestion2.Text = "V{7,2,2,2,3,4,4,4,5,5,3,6,7} Resultado => TRUE";
            labelQuestion3.Text = "V{7,2,2,2,3,|2,4,2,5,5,3,6,7} Resultado => FALSE";
            labelQuestion4.ResetText();

            InputsToSetRandom();
        }

        private void download()
        {
            Result2.Text = objVector1.getData();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            download();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath("uagrm.ico"));
            notifyIcon1.Text = "";
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Práctico de Vectores - Cargar";
            notifyIcon1.BalloonTipText = "Cargado Exitosamente";
            notifyIcon1.ShowBalloonTip(10);
            try
            {
                if (textInput1.Text == "") throw new ArgumentException("Introduce la cantidad de elementos a mostrar (ne).");
                int value = int.Parse(textInput1.Text);
                if (currentExercise == 1)
                {
                    if (textInput2.Text == "") throw new ArgumentException("Introduce un numero como base (b).");
                    int numBase = int.Parse(textInput2.Text);
                    objVector1.setDataManually(value, numBase);
                }
                else
                {
                    int min = int.Parse(textInput2.Text);
                    int max = int.Parse(textInput3.Text);
                    if (textInput2.Text == "") throw new ArgumentException("Introduce un rango (Min).");
                    if (textInput3.Text == "") throw new ArgumentException("Introduce un rango (Max).");
                    objVector1.setData(value, min, max);
                    if (currentExercise == 8)
                    {
                        objVector2.setData(value, min, max);
                    }
                }
            }
            catch (Exception error)
            {
                errorHandler(error.Message);
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (objVector1.showNumber() == 0) throw new ArgumentException("Primero debes Cargar los Datos.");
                download();
                switch (currentExercise)
                {
                    case 1:
                        int amount = int.Parse(textInput1.Text);
                        int numBase = int.Parse(textInput2.Text);
                        Result1.Text = objVector1.getArrNumber(amount, numBase);
                        break;
                    case 2:
                        Result1.Text = objVector1.accumulateElements();
                        break;
                    case 3:
                        Result1.Text = objVector1.countSubMultiples().ToString();
                        break;
                    case 4:
                        Result1.Text = objVector1.findTheMean().ToString();
                        break;
                    case 5:
                        Result1.Text = objVector1.selectPrimesAndNotPrimes();
                        break;
                    case 6:
                        objVector1.investNumberInRange();
                        Result1.Text = objVector1.getData();
                        break;
                    case 7:
                        bool unique = objVector1.IsUnique();
                        if (unique) Result1.Text = unique.ToString() + " : Todos los elementos son unicos!";
                        else Result1.Text = unique.ToString() + " : Algunos elementos se repiten.";
                        break;
                    case 8:
                        Result1.Text = objVector1.FindOfIntersection(ref objVector2);
                        break;
                }
            }
            catch (Exception error)
            {
                errorHandler(error.Message);
            }
        }
    }
}
