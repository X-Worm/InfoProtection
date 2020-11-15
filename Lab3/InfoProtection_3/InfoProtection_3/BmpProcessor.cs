﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProtection_3
{
    public class BmpProcessor
    {

        private BitArray ByteToBit(byte src)
        {
            BitArray bitArray = new BitArray(8);
            bool st = false;
            for(int i = 0; i < 8; i++)
            {
                if((src >> i & 1) == 1)
                {
                    st = true;
                } else
                {
                    st = false;
                }
                bitArray[i] = st;
            }
            return bitArray;
        }

        private byte BitToByte(BitArray src)
        {
            byte num = 0;
            for(int i = 0; i < src.Count; i++)
            {
                if(src[i] == true)
                {
                    num += (byte)Math.Pow(2, i);
                }
            }
            return num;
        }

        private bool IsEncryption(Bitmap src)
        {
            byte[] rez = new byte[1];
            Color color = src.GetPixel(0, 0);

            BitArray colorArray = ByteToBit(color.R);
            BitArray messageArray = ByteToBit(color.R);

            messageArray[0] = colorArray[0];
            messageArray[1] = colorArray[1];

            colorArray = ByteToBit(color.G);

            messageArray[2] = colorArray[0];
            messageArray[3] = colorArray[1];
            messageArray[4] = colorArray[2];

            colorArray = ByteToBit(color.B);

            messageArray[5] = colorArray[0];
            messageArray[6] = colorArray[1];
            messageArray[7] = colorArray[2];

            rez[0] = BitToByte(messageArray);

            string m = Encoding.GetEncoding(1251).GetString(rez);
            if (m == "/")
            {
                return true;
            }
            else return false;
        }

        private void WriteCountText(int count, Bitmap src)
        {
            List<char> array = count.ToString().PadRight(3, ' ').ToList();
           
            byte[] countSymbols = Encoding.GetEncoding(1251).GetBytes(array.ToArray());

            
            for(int i = 0; i < countSymbols.Length; i++)
            {
                BitArray bitCount = ByteToBit(countSymbols[i]);
                Color pColor = src.GetPixel(0, i + 1);
                BitArray bitsCurColor = ByteToBit(pColor.R);
                bitsCurColor[0] = bitCount[0];
                bitsCurColor[1] = bitCount[1];
                byte nR = BitToByte(bitsCurColor);

                bitsCurColor = ByteToBit(pColor.G);
                bitsCurColor[0] = bitCount[2];
                bitsCurColor[1] = bitCount[3];
                bitsCurColor[2] = bitCount[4];
                byte nG = BitToByte(bitsCurColor);

                bitsCurColor = ByteToBit(pColor.B);
                bitsCurColor[0] = bitCount[5];
                bitsCurColor[1] = bitCount[6];
                bitsCurColor[2] = bitCount[7];
                byte nB = BitToByte(bitsCurColor);

                Color nColor = Color.FromArgb(nR, nG, nB);
                src.SetPixel(0, i + 1, nColor);

            }
        }

        private int ReadCountText(Bitmap src)
        {
            byte[] rez = new byte[3]; 
            for (int i = 0; i < 3; i++)
            {
                Color color = src.GetPixel(0, i + 1); 
                BitArray colorArray = ByteToBit(color.R); 
                BitArray bitCount = ByteToBit(color.R); ; 
                bitCount[0] = colorArray[0];
                bitCount[1] = colorArray[1];

                colorArray = ByteToBit(color.G);
                bitCount[2] = colorArray[0];
                bitCount[3] = colorArray[1];
                bitCount[4] = colorArray[2];

                colorArray = ByteToBit(color.B);
                bitCount[5] = colorArray[0];
                bitCount[6] = colorArray[1];
                bitCount[7] = colorArray[2];
                rez[i] = BitToByte(bitCount);
            }
            string m = Encoding.GetEncoding(1251).GetString(rez).Replace(" ", "");
            return Convert.ToInt32(m, 10);
        }

        public Bitmap EncodeStart(string rText, Bitmap bPic)
        {
            List<byte> bList = Encoding.ASCII.GetBytes(rText).ToList();
            int CountText = bList.Count;
            if (CountText > ((bPic.Width * bPic.Height)) - 4)
            {
                throw new Exception("Incorrect size of file");
            }

            if (IsEncryption(bPic))
            {
                throw new Exception("Image is already encrypted");
            }

            byte[] Symbol = Encoding.GetEncoding(1251).GetBytes("/");
            BitArray ArrBeginSymbol = ByteToBit(Symbol[0]);
            Color curColor = bPic.GetPixel(0, 0);
            BitArray tempArray = ByteToBit(curColor.R);
            tempArray[0] = ArrBeginSymbol[0];
            tempArray[1] = ArrBeginSymbol[1];
            byte nR = BitToByte(tempArray);

            tempArray = ByteToBit(curColor.G);
            tempArray[0] = ArrBeginSymbol[2];
            tempArray[1] = ArrBeginSymbol[3];
            tempArray[2] = ArrBeginSymbol[4];
            byte nG = BitToByte(tempArray);

            tempArray = ByteToBit(curColor.B);
            tempArray[0] = ArrBeginSymbol[5];
            tempArray[1] = ArrBeginSymbol[6];
            tempArray[2] = ArrBeginSymbol[7];
            byte nB = BitToByte(tempArray);

            Color nColor = Color.FromArgb(nR, nG, nB);
            bPic.SetPixel(0, 0, nColor);

            WriteCountText(CountText, bPic);

            int index = 0;
            bool st = false;
            for (int i = 4; i < bPic.Width; i++)
            {
                for (int j = 0; j < bPic.Height; j++)
                {
                    Color pixelColor = bPic.GetPixel(i, j);
                    if (index == bList.Count)
                    {
                        st = true;
                        break;
                    }
                    BitArray colorArray = ByteToBit(pixelColor.R);
                    BitArray messageArray = ByteToBit(bList[index]);
                    colorArray[0] = messageArray[0]; //меняем
                    colorArray[1] = messageArray[1]; // в нашем цвете биты
                    byte newR = BitToByte(colorArray);

                    colorArray = ByteToBit(pixelColor.G);
                    colorArray[0] = messageArray[2];
                    colorArray[1] = messageArray[3];
                    colorArray[2] = messageArray[4];
                    byte newG = BitToByte(colorArray);

                    colorArray = ByteToBit(pixelColor.B);
                    colorArray[0] = messageArray[5];
                    colorArray[1] = messageArray[6];
                    colorArray[2] = messageArray[7];
                    byte newB = BitToByte(colorArray);

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    bPic.SetPixel(i, j, newColor);
                    index++;
                }
                if (st)
                {
                    break;
                }
            }
            return bPic;
        }

        public string Decrypt(Bitmap bPic)
        {
           
            if (!IsEncryption(bPic))
            {
                throw new Exception("У файлі немає зашифрованої інформації");
            }

            // зчитати кількість зашифрованих символів
            int countSymbol = ReadCountText(bPic); 

            byte[] message = new byte[countSymbol];
            int index = 0;
            bool st = false;
            for (int i = 4; i < bPic.Width; i++)
            {
                for (int j = 0; j < bPic.Height; j++)
                {
                    Color pixelColor = bPic.GetPixel(i, j);
                    if (index == message.Length)
                    {
                        st = true;
                        break;
                    }
                    BitArray colorArray = ByteToBit(pixelColor.R);
                    BitArray messageArray = ByteToBit(pixelColor.R); ;
                    messageArray[0] = colorArray[0];
                    messageArray[1] = colorArray[1];

                    colorArray = ByteToBit(pixelColor.G);
                    messageArray[2] = colorArray[0];
                    messageArray[3] = colorArray[1];
                    messageArray[4] = colorArray[2];

                    colorArray = ByteToBit(pixelColor.B);
                    messageArray[5] = colorArray[0];
                    messageArray[6] = colorArray[1];
                    messageArray[7] = colorArray[2];
                    message[index] = BitToByte(messageArray);
                    index++;
                }
                if (st)
                {
                    break;
                }
            }
            string strMessage = Encoding.GetEncoding(1251).GetString(message);

            return strMessage;
        }

      
    }
}
