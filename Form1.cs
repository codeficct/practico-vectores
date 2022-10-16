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
        Vector objVector1, objVector2, objVector3;
        private Button currentButton;
        private Button partsButton;
        int currentExercise = 0;
        int currentPart = 1;
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

                selectExercise(currentValue);
            }
        }

        public void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.White;
                isDisable = false;
            }
        }

        public void ActivateBtnParts(Object senderBtn)
        {
            btnFirst.BackColor = Color.White;
            btnSecond.BackColor = Color.White;
            if (senderBtn != null)
            {
                selectExercise(currentExercise);
                DisableBtn();
                partsButton = (Button)senderBtn;
                partsButton.BackColor = Color.LightBlue;
            }
        }

        public void DisableBtn()
        {
            if (partsButton != null)
            {
                partsButton.BackColor = Color.White;
                isDisable = false;
            }
        }

        private void errorHandler(string message)
        {
            MessageBox.Show(message, "Datos incorrectos o faltantes.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Ejercicio 1.1";
            button2.Text = "Ejercicio 1.2";
            button3.Text = "Ejercicio 1.3";
            button4.Text = "Ejercicio 1.4";
            button5.Text = "Ejercicio 1.5";
            button6.Text = "Ejercicio 1.6";
            button7.Text = "Ejercicio 1.7";
            button8.Text = "Ejercicio 1.8";
            button9.Text = "Ejercicio 1.9";
            button10.Text = "Ejercicio 1.10";

            labelQuestion2.ResetText();
            labelQuestion3.ResetText();
            labelQuestion4.ResetText();

            buttonRun.Enabled = false;
            buttonSet.Enabled = false;
            buttonGet.Enabled = false;

            btnFirst.BackColor = Color.LightBlue;

            objVector1 = new Vector();
            objVector2 = new Vector();
            objVector3 = new Vector();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result1.Clear(); Result2.Clear();
            textInput1.Clear(); textInput2.Clear(); textInput3.Clear();
            textInterValue.Clear(); textInputMin.Clear(); textInputMax.Clear();
        }

        private void InputsToSetRandom(bool only = false)
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

            if (only)
            {
                textInterValue.Visible = false;
                labelInterValue.Visible = false;
                textInputMin.Visible = false;
                labelInterMin.Visible = false;
                textInputMax.Visible = false;
                labelInterMax.Visible = false;
            }
        }

        private void InputsToSetRandom2()
        {
            labelInterValue.Visible = true;
            textInterValue.Visible = true;
            labelInterValue.Text = "Cantidad 2";

            textInputMin.Visible = true;
            labelInterMin.Visible = true;
            labelInterMin.Text = "Min 2";

            textInputMax.Visible = true;
            labelInterMax.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, 1);
            textInterValue.Visible = false;
            labelInterValue.Visible = false;
            textInputMin.Visible = false;
            labelInterMin.Visible = false;
            textInputMax.Visible = false;
            labelInterMax.Visible = false;
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

        private void download()
        {
            if (((currentExercise == 8) || (currentExercise == 9)) && currentPart == 1)
                Result2.Text = objVector1.getData() + "   " + objVector3.getData();
            else
                Result2.Text = objVector1.getData();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            download();
        }

        private void selectExercise(int exercise)
        {
            switch (exercise)
            {
                case 1:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "1. Cargar ne elementos el vector con la fórmula: b^0 ; b^1 ; b^2;…";
                        labelQuestion2.Text = "   Si ne=4 y b=3 => 3^0; 3^1; 3^2; 3^3;… V{1,3,9,27}";
                        labelQuestion3.Text = "   Si ne=8 y b=2 => 2^0; 2^1; 2^2; 2^3;… V{1,2,4,8,16,32,64,128}";

                        labelInput1.Text = "Num. Elementos (ne)";
                        labelInput1.Visible = true;
                        textInput1.Visible = true;

                        labelInput2.Visible = true;
                        labelInput2.Text = "  base (b)";
                        textInput2.Visible = true;

                        labelInput3.Visible = false;
                        textInput3.Visible = false;
                    }
                    else
                    {
                        labelQuestion1.Text = "1. Eliminar los elementos NO PRIMOS del vector";
                        labelQuestion2.Text = "   V={1,2,3,4,5,6,7,8,9} => V={2,3,5,7}";
                        labelQuestion3.Text = "";
                        labelQuestion4.Text = "";
                        InputsToSetRandom(true);
                    }
                    break;
                case 2:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "2. Acumular con elementos del vector. V{2,3,6,4,1,7}";
                        labelQuestion2.Text = "   y recordando Fibonacci: 0,1,1,2,3,5,8,13… ";
                        labelQuestion3.Text = "   F=2/0! – 3/1! + 6/1! – 4/2! + 1/3! – 7/5!";
                        labelQuestion4.Text = "";
                        InputsToSetRandom(true);
                    }
                    else
                    {
                        labelQuestion1.Text = "2. Ordenar los elementos de posiciones múltiplos de m.";
                        labelQuestion2.Text = "   Si m=3 V={2,3, 4, 6,7, 3, 6,6, 1, 4,5, 6, 7,8}";
                        labelQuestion3.Text = "   =>     V={2,3, 1, 6,7, 3, 6,6, 4, 4,5, 6, 7,8}";
                        labelQuestion4.Text = "";
                        InputsToSetRandom(true);
                        labelInterValue.Visible = true;
                        textInterValue.Visible = true;
                        labelInterValue.Text = "Multiplo";
                    }
                    break;
                case 3:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "3. Contar elementos que se encuentren en posiciones que sean sus";
                        labelQuestion2.Text = "   submúltiplos, Si V{3,1,9,5,12,12,6,7}";
                        labelQuestion3.Text = "   Posiciones 1,2,3,4, 5, 6 , 7,8 => 3 ; porque 1 es submult de 3, 3 de 9, 6 de 12";
                        labelQuestion4.Text = "";
                        InputsToSetRandom(true);
                    }
                    else
                    {
                        labelQuestion1.Text = "3. Ordenar en sentido de “espiral interno”";
                        labelQuestion2.Text = "   V={3,2,1,6,5,4,9,7,8,10}  =>  V={1,3,5,7,9,10,8,6,4,2}";
                        labelQuestion3.ResetText();
                        labelQuestion4.ResetText();
                        InputsToSetRandom(true);
                    }
                    break;
                case 4:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "4. Encontrar la media de las posiciones con la formula “mágica”.";
                        labelQuestion2.Text = "   Vi+(i-1)*r sea Vi=5 y r=3 (r: sinónimo de multiplicador)";
                        labelQuestion3.Text = "   V{5,4,6,9,8,4,5,7,2, 5, 4, 2, 6, 3} => media=22/4=5,5";
                        labelQuestion4.Text = "   1,2,3,4,5,6,7,8,9,10,11,12,13,14 <= índices.";
                        InputsToSetRandom(true);
                    }
                    else
                    {
                        labelQuestion1.Text = "4. Contar elementos diferentes entre el rango a y b, aplicando cortes de control; si ";
                        labelQuestion2.Text = "   a=3 y b=10";
                        labelQuestion3.Text = "   V={1,2,5,2,3,4,2,4,4,5,5,5,6,7} Resultado => 4";
                        labelQuestion4.ResetText();
                        InputsToSetRandom(true);

                        textInterValue.Visible = false;
                        labelInterValue.Visible = false;

                        textInputMin.Visible = true;
                        labelInterMin.Visible = true;
                        labelInterMin.Text = "Seg. 'a'";

                        textInputMax.Visible = true;
                        labelInterMax.Visible = true;
                        labelInterMax.Text = "Seg. 'b'";
                    }
                    break;
                case 5:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "5. Seleccionar los elementos primos y no primos.";
                        labelQuestion2.Text = "   V{1,2,3,4,5,6,7,8,9,10}";
                        labelQuestion3.Text = "   El resultado es: R1{V{2,3,5,7} “primos” y R2{V{1,4,6,8,9} “no primos”";
                        labelQuestion4.ResetText();
                        InputsToSetRandom(true);
                    }
                    else
                    {
                        labelQuestion1.Text = "5. Encontrar el elemento menos repetido en el segmento a y b; si a=3 y b=10";
                        labelQuestion2.Text = "   V = { 1,2,5,2,4,4,3,4,2,5,5,5,6,7 }";
                        labelQuestion3.Text = "   Resultado => ele = 3 y frec = 1";
                        labelQuestion4.ResetText();
                        InputsToSetRandom(true);

                        textInterValue.Visible = false;
                        labelInterValue.Visible = false;

                        textInputMin.Visible = true;
                        labelInterMin.Visible = true;
                        labelInterMin.Text = "Seg. 'a'";

                        textInputMax.Visible = true;
                        labelInterMax.Visible = true;
                        labelInterMax.Text = "Seg. 'b'";
                    }
                    break;
                case 6:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "6. Invertir los elementos del vector del rango a y b. Sea a=3 y b=7";
                        labelQuestion2.Text = "   V{1,2,3,4,5,6,7,8,9} => V{1,2,7,6,5,4,3,8,9}";
                        labelQuestion3.Text = "   a=3 y b=7 a y b son posiciones.";
                        labelQuestion4.ResetText();
                        InputsToSetRandom();
                        textInterValue.Visible = false;
                        labelInterValue.Visible = false;

                        textInputMin.Visible = true;
                        labelInterMin.Visible = true;
                        labelInterMin.Text = "Seg. 'a'";

                        textInputMax.Visible = true;
                        labelInterMax.Visible = true;
                        labelInterMax.Text = "Seg. 'b'";
                    }
                    else
                    {
                        labelQuestion1.Text = "6. Encontrar la frecuencia de distribución de elementos del segmento entre a y b; si";
                        labelQuestion2.Text = "   a=3 y b=10";
                        labelQuestion3.Text = "   V={1,2,2,5,3,4,5,4,2,4,5,5,6,7} =>Resultado e{ V={2,3,4,5} }";
                        labelQuestion4.Text = "                                               f{ V={2,1,3,2} }";
                        InputsToSetRandom(true);

                        textInterValue.Visible = false;
                        labelInterValue.Visible = false;

                        textInputMin.Visible = true;
                        labelInterMin.Visible = true;
                        labelInterMin.Text = "Seg. 'a'";

                        textInputMax.Visible = true;
                        labelInterMax.Visible = true;
                        labelInterMax.Text = "Seg. 'b'";
                    }
                    break;
                case 7:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "7. Verificar si todo los elementos son únicos, ósea que no tienen repeticiones.";
                        labelQuestion2.Text = "   V{3,7,13,2,5} el resultado es: TRUE";
                        labelQuestion3.Text = "   V{2,7,3,5,6,4,5,8,3,3} el resultados es: FALSE";
                        labelQuestion4.ResetText();
                        InputsToSetRandom(true);
                    }
                    else
                    {
                        labelQuestion1.Text = "7. Encontrar elemento y frecuencia de los ELEMENTOS DE FIBONACCI.";
                        labelQuestion2.Text = "   Sea: V={4,3,2,9,1,2,3,4,5,4,5,6} Resultado => e{ V={1,2,3,5} }";
                        labelQuestion3.Text = "                                                 f{ V={1,2,1,2} }";
                        labelQuestion4.ResetText();
                        InputsToSetRandom(true);
                    }
                    break;
                case 8:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "8. Encontrar la intersección de elementos (Teoría de conjuntos).";
                        labelQuestion2.Text = "   V{4,7,6,1,8,2} y V2{V{5,7,9,4,1}";
                        labelQuestion3.Text = "   El resultado es: V3{ V{ 4,7,1}";
                        labelQuestion4.ResetText();
                        InputsToSetRandom();
                        InputsToSetRandom2();
                    }
                    else
                    {
                        labelQuestion1.Text = "8. Segmentar el Vector en primos y no primos ordenados descendentemente del";
                        labelQuestion2.Text = "   segmento a y b. Si a=4 y b=12";
                        labelQuestion3.Text = "   V={10,7,10,5,4,6,7,8,4,5,7,2,10,23,10,2}";
                        labelQuestion4.ResetText();
                        InputsToSetRandom(true);

                        textInterValue.Visible = false;
                        labelInterValue.Visible = false;

                        textInputMin.Visible = true;
                        labelInterMin.Visible = true;
                        labelInterMin.Text = "Seg. 'a'";

                        textInputMax.Visible = true;
                        labelInterMax.Visible = true;
                        labelInterMax.Text = "Seg. 'b'";
                    }
                    break;
                case 9:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "9. Encontrar la unión de elementos (Teoría de conjuntos)";
                        labelQuestion2.Text = "   V{4,7,6,1,8,2} y V2{V=5,7,9,4,1}";
                        labelQuestion3.Text = "   El resultado es: V3{ 4,7,6,1,8,2,5,9}";
                        labelQuestion4.Text = "   En el resultado no puede haber elementos repetidos.";
                        InputsToSetRandom();
                        InputsToSetRandom2();
                    }
                    else
                    {
                        labelQuestion1.Text = "9. Segmentar el Vector en capicúas y no capicúas, donde el 1er segmento este";
                        labelQuestion2.Text = "   ordenado ascendentemente y el 2do descendentemente.";
                        labelQuestion3.Text = "   V={555,44,60,71,81,44,555,71,20,44}";
                        labelQuestion4.Text = "   el resultado es V={44,44,44,555,555,81,71,71,60,20}";
                        InputsToSetRandom(true);
                    }
                    break;
                case 10:
                    if (currentPart == 1)
                    {
                        labelQuestion1.Text = "10. Verificar si el segmento a y b esta ordenado; si a=3 y b=10";
                        labelQuestion2.Text = "    V{7,2,2,2,3,4,4,4,5,5,3,6,7} Resultado => TRUE";
                        labelQuestion3.Text = "    V{7,2,2,2,3,|2,4,2,5,5,3,6,7} Resultado => FALSE";
                        labelQuestion4.ResetText();
                        InputsToSetRandom();
                        textInterValue.Visible = false;
                        labelInterValue.Visible = false;

                        textInputMin.Visible = true;
                        labelInterMin.Visible = true;
                        labelInterMin.Text = "Seg. 'a'";

                        textInputMax.Visible = true;
                        labelInterMax.Visible = true;
                        labelInterMax.Text = "Seg. 'b'";
                    }
                    else
                    {
                        labelQuestion1.Text = "10. Intercalar primos y no primos ordenados y mientras sea posible en el rango a y b";
                        labelQuestion2.Text = "    V={10,11,5,6,7,8,4,5,13,20,12} a=2 b=9";
                        labelQuestion3.Text = "    el resultado es: V={10,5,4,5,6,7,8,11,13,20,12}";
                        labelQuestion4.ResetText();
                        InputsToSetRandom(true);
                        textInterValue.Visible = false;
                        labelInterValue.Visible = false;

                        textInputMin.Visible = true;
                        labelInterMin.Visible = true;
                        labelInterMin.Text = "Seg. 'a'";

                        textInputMax.Visible = true;
                        labelInterMax.Visible = true;
                        labelInterMax.Text = "Seg. 'b'";
                    }
                    break;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPart = 1;
            ActivateBtnParts(sender);
            button1.Text = "Ejercicio 1.1";
            button2.Text = "Ejercicio 1.2";
            button3.Text = "Ejercicio 1.3";
            button4.Text = "Ejercicio 1.4";
            button5.Text = "Ejercicio 1.5";
            button6.Text = "Ejercicio 1.6";
            button7.Text = "Ejercicio 1.7";
            button8.Text = "Ejercicio 1.8";
            button9.Text = "Ejercicio 1.9";
            button10.Text = "Ejercicio 1.10";
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            currentPart = 2;
            ActivateBtnParts(sender);
            button1.Text = "Ejercicio 2.1";
            button2.Text = "Ejercicio 2.2";
            button3.Text = "Ejercicio 2.3";
            button4.Text = "Ejercicio 2.4";
            button5.Text = "Ejercicio 2.5";
            button6.Text = "Ejercicio 2.6";
            button7.Text = "Ejercicio 2.7";
            button8.Text = "Ejercicio 2.8";
            button9.Text = "Ejercicio 2.9";
            button10.Text = "Ejercicio 2.10";
        }

        private void informaciónDelEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Nombre: Luis Gabriel Janco Alvarez\nMateria: Programación 1\nGrupo: INF120 SB\nRegistro: 220104875";
            MessageBox.Show(message, "Información del Estudiante", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (textInput1.Text == "") throw new ArgumentException("Introduce la cantidad de elementos a mostrar (ne).");
                int value = int.Parse(textInput1.Text);
                if (currentExercise == 1 && currentPart == 1)
                {
                    if (textInput2.Text == "") throw new ArgumentException("Introduce un numero como base (b).");
                    int numBase = int.Parse(textInput2.Text);
                    objVector1.setDataManually(value, numBase);
                }
                else
                {
                    if (textInput2.Text == "") throw new ArgumentException("Introduce un rango (Min).");
                    if (textInput3.Text == "") throw new ArgumentException("Introduce un rango (Max).");
                    int min = int.Parse(textInput2.Text);
                    int max = int.Parse(textInput3.Text);
                    objVector1.setData(value, min, max);
                    if (((currentExercise == 8) || (currentExercise == 9)) && currentPart == 1)
                    {
                        int value2 = int.Parse(textInterValue.Text);
                        int min2 = int.Parse(textInputMin.Text);
                        int max2 = int.Parse(textInputMax.Text);
                        objVector3.setData(value2, min2, max2);
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
                        if (currentPart == 1)
                        {
                            int amount = int.Parse(textInput1.Text);
                            int numBase = int.Parse(textInput2.Text);
                            Result1.Text = objVector1.getArrNumber(amount, numBase);
                        }
                        else
                            Result1.Text = objVector1.RemoveNoPrimes();
                        break;
                    case 2:
                        if (currentPart == 1)
                            Result1.Text = objVector1.accumulateElements();
                        else
                        {
                            objVector1.orderElementsWithMultiple(int.Parse(textInterValue.Text));
                            Result1.Text = objVector1.getData();
                        }
                        break;
                    case 3:
                        if (currentPart == 1)
                            Result1.Text = objVector1.countSubMultiples().ToString();
                        else
                        {
                            objVector1.OrderInternalSpiral();
                            Result1.Text = objVector1.getData();
                        }
                        break;
                    case 4:
                        if (currentPart == 1)
                            Result1.Text = objVector1.findTheMean().ToString();
                        else
                            Result1.Text = objVector1.CountDifferentItems(int.Parse(textInputMin.Text), int.Parse(textInputMax.Text)).ToString();
                        break;
                    case 5:
                        if (currentPart == 1)
                            Result1.Text = objVector1.selectPrimesAndNotPrimes();
                        else
                            Result1.Text = objVector1.LeastRepeatedElement(int.Parse(textInputMin.Text), int.Parse(textInputMax.Text));
                        break;
                    case 6:
                        if (currentPart == 1)
                        {
                            objVector1.investNumberInRange(int.Parse(textInputMin.Text), int.Parse(textInputMax.Text));
                            Result1.Text = objVector1.getData();
                        }
                        else
                        {
                            Result1.Text = objVector1.DistributionFrequency(int.Parse(textInputMin.Text), int.Parse(textInputMax.Text));
                        }
                        break;
                    case 7:
                        if (currentPart == 1)
                        {
                            bool unique = objVector1.IsUnique();
                            if (unique) Result1.Text = unique.ToString() + " : Todos los elementos son unicos!";
                            else Result1.Text = unique.ToString() + " : Algunos elementos se repiten.";
                        }
                        else
                        {
                            Result1.Text = objVector1.ElementFrecuenceOnFibonacci();
                        }
                        break;
                    case 8:
                        if (currentPart == 1)
                            Result1.Text = objVector1.FindOfIntersection(ref objVector3);
                        else
                        {
                            objVector1.SegmentPrimesAndNonPrimes(int.Parse(textInputMin.Text), int.Parse(textInputMax.Text), ref objVector2);
                            Result1.Text = objVector2.getData();
                        }
                        break;
                    case 9:
                        if (currentPart == 1)
                            Result1.Text = objVector1.FindTheUnion(ref objVector3);
                        else
                        {
                            objVector1.SegmentPalindrome(ref objVector2);
                            Result1.Text = objVector2.getData();
                        }
                        break;
                    case 10:
                        if (currentPart == 1)
                            Result1.Text = objVector1.IsOrderInSegment(int.Parse(textInputMin.Text), int.Parse(textInputMax.Text), ref objVector3).ToString();
                        else
                        {
                            objVector1.interleavePrimes(int.Parse(textInputMin.Text), int.Parse(textInputMax.Text), ref objVector2);
                            Result1.Text = objVector2.getData();
                        }
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
