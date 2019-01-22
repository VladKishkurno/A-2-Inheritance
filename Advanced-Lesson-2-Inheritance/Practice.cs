using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Practice
    {
        public interface IPrinter
        {
             void Print();
        }

        public class FilePrinter : IPrinter
        {
            public string Text;
            private string _fileName;
            public FilePrinter( string Text, string FileName)
            {
                this.Text = Text;
                this._fileName = FileName;
            }
            public void Print()
            {
                System.IO.File.AppendAllText($@"d:\{_fileName}.txt", Text);
            }
        }

        public class ConsolePrinter : IPrinter
        {
            public string Text;
            private ConsoleColor _color;
            public ConsolePrinter(string Text, ConsoleColor color)
            {
                this.Text = Text;
                this._color = color;
            }
            public void Print()
            {
                Console.ForegroundColor = _color;
                Console.WriteLine(Text);
            }
        }

        public class ImagePrinter : IPrinter
        {
            public string Text;
            private string _fileName;
            public ImagePrinter(string Text, string FileName)
            {
                this.Text = Text;
                this._fileName = FileName;
            }
            public void Print()
            {
                Bitmap image = new Bitmap(2000, 1000) ;
                
                RectangleF rectf = new RectangleF(70, 90, 100, 70);
                Graphics g = Graphics.FromImage(image);

                g.DrawString(Text, new Font("Tahoma", 18), Brushes.Black, rectf);
                
                image.Save($@"d:\{_fileName}.jpg");

            }
        }
        /// <summary>
        /// A.L2.P1/1. Создать консольное приложение, которое может выводить 
        /// на печатать введенный текст  одним из трех способов: 
        /// консоль, файл, картинка. 
        /// </summary>
        public static void A_L2_P1_1()
        {
            Console.WriteLine("Введите строку");
            var text = Console.ReadLine();

           

            Console.WriteLine("Выберите метод вывода информации: \n 1 - Console \n 2 - File \n 3 -Image ");

            string choose = Console.ReadLine();

            IPrinter printer = null;

            switch (choose)
            {
                case "1":
                    {
                        Console.WriteLine( value: " Console ");
                        printer = new ConsolePrinter(text, ConsoleColor.DarkRed);
                        printer.Print();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine(value: " File ");
                        printer = new FilePrinter(text, "practice");
                        printer.Print();
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine(value: " Image ");
                        printer = new ImagePrinter(text, "practice");
                        printer.Print();
                        break;
                    }
            }
        }       
    }
}
