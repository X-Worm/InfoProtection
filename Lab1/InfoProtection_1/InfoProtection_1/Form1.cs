using InfoProtection_1.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoProtection_1
{
    public partial class ProgTitle : Form
    {

        private List<KeyValuePair<int, char>> ukraineAlphabet = new List<KeyValuePair<int, char>>();
        private int encryptionStepValue;
        private int alphabetCount;

        private List<EncyptData> encryptProcessGrid = new List<EncyptData>();

        public ProgTitle()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
            ukraineAlphabet = new AlphabetHelper().GetUkraineAlphabet();

            // get step of encryption
            encryptionStepValue = Int32.Parse(encryptionStep.Text);
            alphabetCount = ukraineAlphabet.Count();
            //resultGrid.DataSource = encryptProcessGrid;

        }

        private void processEncryption_MouseClick(object sender, MouseEventArgs e)
        {
            // take inputed string
            var inputedString = textToEncrypt.Text;

            encryptResult.Text = GetEncryptedValue(inputedString);
            
        }

        private string GetEncryptedValue(string value)
        {
            string upperValue = value.ToUpperInvariant();

            // get int keys
            var intValues = new List<int>();
            foreach(var symbol in upperValue)
            {
                intValues.Add(ukraineAlphabet.FirstOrDefault(item => item.Value == symbol).Key);
            }

            // shiftValues
            var shiftedValues = new List<int>();
            intValues.ForEach(symbolKey =>
            {
                if (symbolKey != 0)
                    shiftedValues.Add((symbolKey + encryptionStepValue) % alphabetCount);
                else
                    shiftedValues.Add(0);
            });

            // new alphabet values
            var encryptedValues = new List<char>();
            shiftedValues.ForEach(shiftedValue =>
            {
                if (shiftedValue == 0)
                    encryptedValues.Add(' ');
                else
                    encryptedValues.Add(ukraineAlphabet.FirstOrDefault(item => item.Key == shiftedValue).Value);
            });

            // get encrypted text
            var encryptedText = String.Join("", encryptedValues);

            // get data for grid
            for(int i = 0; i < value.Length; i++)
            {
                encryptProcessGrid.Add(new EncyptData
                {
                    OriginalSymbol = upperValue[i],
                    OriginalValue = intValues[i],
                    NewSymbol = encryptedText[i],
                    NewValue = shiftedValues[i]
                });
            }
            var bindingList = new BindingList<EncyptData>(encryptProcessGrid);
            var source = new BindingSource(bindingList, null);
            resultGrid.DataSource = source;

            return encryptedText;
        }
    }

    public class EncyptData
    {
        public char OriginalSymbol { get; set; }
        public int OriginalValue { get; set; }
        public int NewValue { get; set; }
        public char NewSymbol { get; set; }
    }
}
