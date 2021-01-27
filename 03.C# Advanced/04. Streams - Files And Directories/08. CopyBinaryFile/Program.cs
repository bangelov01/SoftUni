using System;
using System.IO;

namespace _08._CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream read = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream write = new FileStream("../../../Copied.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;

                    while ((bytesRead = read.Read(buffer,0,buffer.Length)) > 0)
                    {
                        write.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
