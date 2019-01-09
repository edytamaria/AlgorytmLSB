using System;
using System.Collections;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace AlgorytmLSB
{
    class Coding
    {
        private string message { get; set; }
        private Bitmap image { get; set; }
        private string key { get; set; }

        public Coding() { }

        public Bitmap CodingMessage(string message, Bitmap image, string key)
        {
            //this.image = image;
            //return this.CopyDataToBitmap(this.ImgToArr(image));

            this.message = message;
            this.image = image;
            this.key = key;


            //byte[] Key = Encoding.ASCII.GetBytes(this.key);

            byte[] encrypted = EncryptStringToBytes_Aes(this.message, this.key);
            byte[] imgByte = ImgToArr(image);
            int messageSize = encrypted.Length;

            // konwertuję messageSize na bity
            byte[] messageSizeByte = BitConverter.GetBytes(messageSize); // byteconverter - zawsze zwraca 4 bajty
            BitArray messageSizeBit = new BitArray(8 * messageSizeByte.Length);
            int counter = 0;
            foreach (byte b in messageSizeByte)
            {
                BitArray bb = ByteToBit(b);
                foreach (bool bbb in bb)
                {
                    messageSizeBit[counter++] = bbb;
                }
            }
            // konwersja wiadomości na bity
            BitArray encryptedBit = new BitArray(8 * encrypted.Length);
            int mcounter = 0;
            foreach (byte b in encrypted)
            {
                BitArray bb = ByteToBit(b);
                foreach (bool bbb in bb)
                {
                    encryptedBit[mcounter++] = bbb;
                }
            }

            // i mam długość wiadomości w bitach
            // koduję je teraz w obrazie w pierwszych 2 kolorach, czyli 6 bajtach - 2x3x2 = 12

            //konwersja bitmapy do bytemap
            //Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            //System.Drawing.Imaging.BitmapData bmpData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, image.PixelFormat);

            //int bytes = Math.Abs(bmpData.Stride) * image.Height;
            //IntPtr ptr = bmpData.Scan0;
            //byte[] rgbValues = new byte[bytes];
            //System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);


            // wklejam długość tekstu do obrazka
            //int i = 0;


            byte[] imgByteEncrypted = imgByte.ToArray();
            int imgCounter = 0;
            for (int i = 0; i < messageSizeBit.Length; i = i + 2)
            {
                imgByteEncrypted[imgCounter] = Hide2Bit(imgByte[imgCounter], messageSizeBit[i], messageSizeBit[i + 1]);
                imgCounter++;
            }
            // UKRYĆ CAŁĄ WIADOMOŚĆ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (encryptedBit.Length % 2 == 1)
            {

            }
            for (int i = 0; i < encryptedBit.Length; i = i + 2)
            {
                imgByteEncrypted[imgCounter] = Hide2Bit(imgByte[imgCounter], encryptedBit[i], encryptedBit[i + 1]);
                imgCounter++;
            }
            // Code message in image
            return CopyDataToBitmap(imgByteEncrypted);
        }

        public string DecodeMessage(Bitmap image, string key)
        {
            byte[] decodeImg = ImgToArr(image);

            List<byte> data = new List<byte>();
            int imageIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                BitArray xx = new BitArray(8);
                for (int j = 0; j < 4; j++)
                {
                    var arr = Read2Bit(decodeImg[imageIndex]);
                    xx[j * 2 + 0] = arr[0];
                    xx[j * 2 + 1] = arr[1];
                    imageIndex++;
                }

                var byteForTest = BitToByte(xx);
                data.Add(byteForTest);
            }

            int textLength = BitConverter.ToInt32(data.ToArray(), 0);
            byte[] text = new byte[textLength];
            for (int i = 0; i < textLength; i++)
            {
                BitArray xx = new BitArray(8);
                for (int j = 0; j < 4; j++)
                {
                    var arr = Read2Bit(decodeImg[imageIndex]);
                    xx[j * 2 + 0] = arr[0];
                    xx[j * 2 + 1] = arr[1];
                    imageIndex++;
                }

                var byteForTest = BitToByte(xx);
                text[i] = (byteForTest);
            }
            string decryptedText = DecryptStringFromBytes_Aes(text, key);

            return decryptedText;
        }


       
        public Bitmap CopyDataToBitmap(byte[] data)
        {
            int height = this.image.Height;
            int width = this.image.Width;

            Bitmap bmp = new Bitmap(width, height, this.image.PixelFormat);

            int counter = 0;


            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    bmp.SetPixel(w, h, Color.FromArgb(data[counter * 3 + 0], data[counter * 3 + 1], data[counter * 3 + 2]));
                    counter++;
                }
            }

            return bmp;
        }

        private byte[] ImgToArr(Bitmap image)
        {
            var width = image.Width;
            var height = image.Height;

            byte[] imgArr = new byte[3 * width * height];
            int counter = 0;


            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    Color color = image.GetPixel(w, h);
                    imgArr[counter * 3 + 0] = color.R;
                    imgArr[counter * 3 + 1] = color.G;
                    imgArr[counter * 3 + 2] = color.B;

                    counter++;
                }
            }

            return imgArr;
        }

        private byte Hide2Bit(byte data, bool x1, bool x2)
        {
            var bitData = this.ByteToBit(data);
            bool a1 = bitData[0], a2 = bitData[1], a3 = bitData[2];

            if (x1 == a1 ^ a3 && x2 == a2 ^ a3)
            {
                return data;
            }

            if (x1 != a1 ^ a3 && x2 == a2 ^ a3)
            {
                bitData[0] = !bitData[0];
                return this.BitToByte(bitData);
            }

            if (x1 == a1 ^ a3 && x2 != a2 ^ a3)
            {
                bitData[1] = !bitData[1];
                return this.BitToByte(bitData);
            }

            if (x1 != a1 ^ a3 && x2 != a2 ^ a3)
            {
                bitData[2] = !bitData[2];
                return this.BitToByte(bitData);
            }

            return data;
        }

        private bool[] Read2Bit(byte data)
        {
            var bitData = this.ByteToBit(data);
            bool a1 = bitData[0], a2 = bitData[1], a3 = bitData[2];
            bool[] response = new bool[2];
            response[0] = a1 ^ a3;
            response[1] = a2 ^ a3;
            return response;
        }


        static byte[] EncryptStringToBytes_Aes(string plainText, string key/* byte[] IV*/)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] bytesMessage = Encoding.ASCII.GetBytes(plainText);
            byte[] keyBytes = SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes(key));

            byte[] Key = new byte[32];
            byte[] IV = new byte[16];
            Buffer.BlockCopy(keyBytes, 0, Key, 0, 32);
            Buffer.BlockCopy(keyBytes, 32, IV, 0, 16);

            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(Key, IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }


            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, string key)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");

            byte[] keyBytes = SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes(key));

            byte[] Key = new byte[32];
            byte[] IV = new byte[16];
            Buffer.BlockCopy(keyBytes, 0, Key, 0, 32);
            Buffer.BlockCopy(keyBytes, 32, IV, 0, 16);

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return plaintext;
        }

        private BitArray ByteToBit(byte src)
        {
            BitArray bitArray = new BitArray(8);
            for (int i = 0; i < 8; i++)
            {
                bitArray[i] = ((src >> i & 1) == 1);
            }
            return bitArray;
        }

        private byte BitToByte(BitArray scr)
        {
            byte num = 0;
            for (int i = 0; i < scr.Count; i++)
                if (scr[i] == true)
                    num += (byte)Math.Pow(2, i);
            return num;
        }

    }
}
