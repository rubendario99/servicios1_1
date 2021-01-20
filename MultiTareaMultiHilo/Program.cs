using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultitareaMultihilo
{
    class Program
    {
        //Creamos el delegado
        public delegate void MyDelegate();
        static void MenuGenerator(string[] options, MyDelegate[] myDelegates)
        {

            int optionSelected = 0;
            //Inicializamos el delegado a su primer índice
            MyDelegate myDelegate = myDelegates[optionSelected];
            int i = 1;

            if (options.Length != myDelegates.Length)
            {
                Console.WriteLine("Check that the vector of strings and the vector of delegates have the same length");
                Console.ReadKey();
                Environment.Exit(0);
            }

            //Mostramos las opciones
            void showOptions()
            {
                foreach (string option in options)
                {
                    Console.WriteLine(i + ".-" + option);
                    i++;
                }
                Console.WriteLine(i + ".-" + "Exit");
                Console.WriteLine("---------");
                i = 1;
            }
            do
            {
                showOptions();
                void AskForOption()
                {
                    do
                    {
                        //Pedimos la opción
                        Console.WriteLine("Select an option");
                        try
                        {
                            optionSelected = Convert.ToInt32(Console.ReadLine());
                            optionSelected--;
                        }
                        catch (System.FormatException s)
                        {
                            Console.Clear();
                            showOptions();
                            optionSelected = -1;
                        }
                        catch (System.OverflowException soe)
                        {
                            Console.Clear();
                            showOptions();
                            optionSelected = -1;
                        }
                    } while (optionSelected == -1);
                }
                AskForOption();
                //Si la opción esta fuera del rango
                //Mostramos error y pedimos de nuevo
                while (optionSelected < 0 || optionSelected > options.Length + 1)
                {
                    Console.Clear();
                    showOptions();
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Error");
                    //Console.WriteLine("Select your option again");
                    //optionSelected = Convert.ToInt32(Console.ReadLine());
                    //optionSelected--;
                    AskForOption();
                }

                //Asignamos el método correspondiente al delegado
                try
                {
                    myDelegate = myDelegates[optionSelected];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Press any key to close the window");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                myDelegate();
                Console.WriteLine("Press any key to repeat");
                Console.ReadKey();
                Console.Clear();

            } while (optionSelected != options.Length);

        }
        static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");
        }
        static void f3()
        {
            Console.WriteLine("C");
        }
        static void f4()
        {
            Console.WriteLine("D");
        }
        static void Main(string[] args)
        {
            MenuGenerator(new string[] { "Letra A", "Letra B", "Letra C", "Letra D" }, new MyDelegate[] { f1, f2, f3, f4 });
            Console.ReadKey();
        }
    }
}
