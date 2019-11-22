using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Week7
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filePath = @"C:\Users\verag\source\.NET course\Week7_HomeWork\Week7\Week7\";
            //string fileName = "Program.cs";
            //PrintFileContent(filePath, fileName);
            //--------------------------------------------------------------------------
            //string link = "https://wantsome.ro/wp-content/uploads/2019/08/WWantsome_Logo_Light1_03-1.png";
            //string fileName = "poza1.png";
            //DownloadInternetFile(link, fileName);
            //---------------------------------------------------------------------------
            //EnterNumbers(1, 100);
            //---------------------------------------------------------------------------


            BitArray64 simpleBitArray1 = new BitArray64(45445);
            
            foreach (var bit in simpleBitArray1)
            {
                Console.Write(bit);
            }
            simpleBitArray1[1] = 1;

            Console.WriteLine();
            foreach (var bit in simpleBitArray1)
            {
                Console.Write(bit);
            }

            Console.WriteLine();
            BitArray64 simpleBitArray2 = new BitArray64(25544);
            foreach (var bit in simpleBitArray2)
            {
                Console.Write(bit);
            }

            Console.WriteLine();
            Console.WriteLine(simpleBitArray1.Equals(simpleBitArray2));
            Console.WriteLine();

            Console.WriteLine(simpleBitArray1.GetHashCode());
            Console.WriteLine(simpleBitArray1[2] == simpleBitArray2[2]);

            

            Console.WriteLine();
           

        }

        private static void EnterNumbers(int start, int end)
        {
            int before = start;
            int next = end;
            bool okNumber = true;
            if (before > next || before == next)
            {
                Console.WriteLine("Range limits are not consistent");
            }
            
            List<int> list = new List<int>();

            Console.WriteLine($"Enter 10 numbers in ascending order in a range between {start} and {end}. One number per line.");

            for (int i = 0; i < 10; i++)
            {
                if (okNumber == false)
                {
                    i = i - 1;
                }
                try
                {
                   
                    int number = int.Parse(Console.ReadLine());
                    if (before < number && number < next)
                    {
                        list.Add(number);
                        okNumber = true;
                        before = number;
                    }
                    else
                    {
                        Console.WriteLine("Provided number is not fitting into the range");
                        okNumber = false;
                    }
                }

                catch (ArgumentNullException ae)
                {
                    Console.WriteLine($"{ae.GetType().Name}: {ae.Message}");
                    okNumber = false;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"{fe.GetType().Name}: {fe.Message}");
                    okNumber = false;
                }
                catch (OverflowException of)
                {
                    Console.WriteLine($"{of.GetType().Name}: {of.Message}");
                    okNumber = false;
                }

            }
        }

        private static void DownloadInternetFile(string link, string fileName)
        {
            var client = new WebClient();
            try
            {                 
                client.DownloadFile(link, fileName);
            }
            catch (Exception)
            {
            }
            finally
            {
                client.Dispose();
            }
            
        }

        private static void PrintFileContent(string path, string name)
        {
           
            string fileNameAndPath = path + name;
            
            try
            {
                var fileContent = File.ReadAllText(fileNameAndPath);
                Console.WriteLine(fileContent);

            }
            catch(NotSupportedException nse)
            {
                Console.WriteLine(nse.Message);
            }
            catch (ArgumentException ar)
            {
                Console.WriteLine(ar.Message);
            }
            catch(PathTooLongException pt)
            {
                Console.WriteLine(pt.Message);
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine(fnf.Message);
            }
            catch (DirectoryNotFoundException dr)
            {
                Console.WriteLine(dr.Message);
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
            
        }
    }
}
