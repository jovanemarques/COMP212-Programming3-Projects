using System;
using System.Windows;
using System.Windows.Controls;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void DelPress(string value);
        private delegate float DelBinaryOperation(float op1, float op2);
        private delegate float DelUnaryOperation(float op);
        private DelBinaryOperation delBinaryOperation;
        private DelUnaryOperation delUnaryOperation;
        private string digits;
        private float? operand1 = null;
        private string operation;
        private bool cleanAfterOperation = false;
        public MainWindow()
        {
            InitializeComponent();
            txtDisplay.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DelPress delPress = null;
            switch (((Button)sender).Content)
            {
                case "Clear":
                    clearAll();
                    break;
                case ".":
                    delPress = value =>
                    {
                        if (txtDisplay.Text.IndexOf(value) == -1 && !txtDisplay.Text.Equals(""))
                        {
                            txtDisplay.Text += value;
                        }
                    };
                    break;
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    delPress = PressDigit;
                    break;
                case "x²":
                case "1/x":
                    delPress = PressUnaryOperator;
                    break;
                case "←":
                    delPress = value => txtDisplay.Text = !txtDisplay.Text.Equals("") ? txtDisplay.Text.Remove(txtDisplay.Text.Length - 1) : "";
                    break;
                case "+":
                case "-":
                case "×":
                case "÷":
                case "=":
                    delPress = PressBinaryOperator;
                    break;
                default:
                    txtDisplay.Text = "Error: Button not configured.";
                    break;
            }
            if (delPress != null)
            {
                delPress(((Button)sender).Content.ToString());
            }
        }

        private void clearAll()
        {
            txtDisplay.Text = "";
            clearVariables();
        }
        private void clearVariables()
        {
            operand1 = null;
            digits = operation = null;
        }

        private void PressDigit(string value)
        {
            if (cleanAfterOperation)
            {
                txtDisplay.Text = "";
                cleanAfterOperation = false;
            }
            txtDisplay.Text += value;
        }
        private void PressUnaryOperator(string operation)
        {
            switch (operation)
            {
                case "1/x":
                    delUnaryOperation = (op) => 1 / op;
                    break;
                case "x²":
                    delUnaryOperation = (op) => op * op;
                    break;
                default:
                    break;
            }
            if (!txtDisplay.Text.Equals(""))
            {
                txtDisplay.Text = delUnaryOperation(float.Parse(txtDisplay.Text)).ToString();
                cleanAfterOperation = true;
            }
        }
        private void PressBinaryOperator(string value)
        {
            if (!txtDisplay.Text.Equals(""))
            {
                if (operation == null && !value.Equals("="))
                {
                    operation = value;
                }
                switch (operation)
                {
                    case "=":
                        break;
                    case "+":
                        if (operand1 != null && !txtDisplay.Text.Equals(""))
                        {
                            operand1 = operand1 + float.Parse(txtDisplay.Text);
                        }
                        else
                        {
                            operand1 = float.Parse(txtDisplay.Text);
                        }
                        break;
                    case "-":
                        if (operand1 != null && !txtDisplay.Text.Equals(""))
                        {
                            operand1 = operand1 - float.Parse(txtDisplay.Text);
                        }
                        else
                        {
                            operand1 = float.Parse(txtDisplay.Text);
                        }
                        break;
                    case "×":
                        if (operand1 != null && !txtDisplay.Text.Equals(""))
                        {
                            operand1 = operand1 * float.Parse(txtDisplay.Text);
                        }
                        else
                        {
                            operand1 = float.Parse(txtDisplay.Text);
                        }
                        break;
                    case "÷":
                        if (operand1 != null && !txtDisplay.Text.Equals(""))
                        {
                            if (!txtDisplay.Text.Equals("0"))
                            {
                                operand1 = operand1 / float.Parse(txtDisplay.Text);
                            }
                            else
                            {
                                txtDisplay.Text = "÷ by 0 Error";
                                clearVariables();
                                return;
                            }
                        }
                        else
                        {
                            operand1 = float.Parse(txtDisplay.Text);
                        }
                        break;
                    default:
                        txtDisplay.Text = "Operation not implemented.";
                        break;
                }
                if (value.Equals("="))
                {
                    txtDisplay.Text = operand1.ToString();
                    clearVariables();
                }
                else
                {
                    operation = value;
                }
                cleanAfterOperation = true;
            }
        }
    }
}
