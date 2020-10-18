using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoProtection_2
{
    public partial class Form1 : Form
    {

        private int _columnNumber;
        private int _repeatNumber;
        private List<int> _key;
        private string _valueToEncrypt;

        private List<List<char>> _matrix;

        public Form1()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            InitializeComponent();
        }

        private void encryptButton_MouseClick(object sender, MouseEventArgs e)
        {
            _valueToEncrypt = valueToEncryptBox.Text;

            // check column number
            if (!CheckColumnNumberBox())
                return;

            // check repeat number
            if (!CheckRepeatNumber())
                return;

            // check key
            if (!CheckKeyBox())
                return;

            var result = EncryptValue();
            encryptedValueBox.Text = result;
        }

        private bool CheckColumnNumberBox()
        {
            int value = 0;
            if (!Int32.TryParse(columnNumberBox.Text, out value))
            {
                MessageBox.Show("Incorrect column number inputed");
                return false;
            }
            _columnNumber = value;
            return true;
        }

        private bool CheckKeyBox()
        {
            string value = keyBox.Text;
            if(value.Any(item => Char.IsLetter(item)))
            {
                MessageBox.Show("Incorrect key inputed, cannot contain symbols");
                return false;
            }
            _key = value.Select(item => Int32.Parse(item.ToString())).ToList();

            // check if incorrect key inputed
            if(value.ToArray().Distinct().Count() != _columnNumber)
            {
                MessageBox.Show("Incorrect key length");
                return false;
            }
            for(int i = 1; i <= value.Length; i++)
            {
                if (!value.Contains(i.ToString()))
                {
                    MessageBox.Show("Incorrect key inputed");
                    return false;
                }
            }

            return true;
        }

        private bool CheckRepeatNumber()
        {
            int value = 0;
            if(!Int32.TryParse(repeatNumberBox.Text, out value))
            {
                MessageBox.Show("Incorrect repeat number inputed");
                return false;
            }
            _repeatNumber = value;
            return true;
        }

        /// <summary>
        /// Encrypt values
        /// </summary>
        /// <returns></returns>
        private string EncryptValue()
        {
            string result = "";
            List<List<char>> tempMatrix = new List<List<char>>();
            List<char> tempVector = new List<char>();
            for(int i = 0; i < _valueToEncrypt.Length; i++)
            {
                tempVector.Add(_valueToEncrypt[i]);
                if ((i + 1) % _columnNumber == 0)
                {
                    tempMatrix.Add(new List<char>(tempVector));
                    tempVector.Clear();
                }
            }

            if (tempVector.Count > 0)
            {
                for (int i = tempVector.Count; i < _columnNumber; i++)
                    tempVector.Add(' ');
                tempMatrix.Add(new List<char>(tempVector));
            }

            result = ShuffleMatrix(tempMatrix, _key);

            return result;
        }

        /// <summary>
        /// Shuffle matrix by key
        /// </summary>
        /// <param name="inputMatrix"></param>
        /// <returns></returns>
        private string ShuffleMatrix(List<List<char>> inputMatrix, List<int> keys)
        {
            string resultValue = "";
            var tempIndex = keys.Select(item => --item).ToList();
            var result = new List<List<char>>();
            result.AddRange(inputMatrix.Select(item => new List<char>()));
            for(int i = 0; i < tempIndex.Count; i++)
            {
                for(int j = 0; j < inputMatrix.Count; j++)
                {
                    char? tempValue = null;
                    try
                    {
                        tempValue = inputMatrix[j][tempIndex[i]];
                    }
                    catch (Exception) { }
                    if (tempValue.HasValue)
                    {
                        resultValue += tempValue;
                        result[j].Add(tempValue.Value);
                    }
                }
            }

            return resultValue;
        }
    }
}
