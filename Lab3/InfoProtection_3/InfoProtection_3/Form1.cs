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

namespace InfoProtection_3
{
    public partial class Form1 : Form
    {

        private string _fileName;
        private BmpProcessor _bmpProcessor;

        public Form1()
        {
            InitializeComponent();
            _bmpProcessor = new BmpProcessor();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(inputText.Text))
                {
                    MessageBox.Show("Не введено текст");
                    return;
                }

                // open disalog to choose file
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    _fileName = openFile.FileName;

                    // get file
                    var fileStream = new FileStream(_fileName, FileMode.Open);
                    var bPic = new Bitmap(fileStream);

                    // start encryption
                    var newFile = _bmpProcessor.EncodeStart(inputText.Text, bPic);

                    // save file
                    string fileToSave = "";
                    if(saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileToSave = saveFileDialog.FileName;
                    }

                    FileStream wFile;
                    try
                    {
                        wFile = new FileStream(fileToSave, FileMode.Create); //открываем поток на запись результатов
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Помилка при відкритті файлу на запис");
                        return;
                    }

                    newFile.Save(wFile, System.Drawing.Imaging.ImageFormat.Bmp);
                    wFile.Close(); //закрываем поток

                    MessageBox.Show("Файл успішно збережено");

                }
                else
                {
                    throw new Exception("Помилка при відкритті файлу");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Сталась помилка: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fileStream = null;
            try
            {
                // open disalog to choose file
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    _fileName = openFile.FileName;

                    // get file
                    fileStream = new FileStream(_fileName, FileMode.Open);
                    var bPic = new Bitmap(fileStream);

                    // decrypt text
                    var text = _bmpProcessor.Decrypt(bPic);
                    inputText.Text = text;
                    MessageBox.Show($"Message: {inputText.Text}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталась помилка: " + ex.Message);
            }
            if(fileStream != null)
            {
                fileStream.Close();
            }
        }
    }
}
