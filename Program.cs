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
            int optionSelected;
            //Inicializamos el delegado a su primer índice
            MyDelegate myDelegate = myDelegates[0];
            int i = 1;

            //Mostramos las opciones
            foreach (string option in options)
            {
                Console.WriteLine(i + ".-" + option);
                i++;
            }
            Console.WriteLine(i + ".-" + "Exit");
            Console.WriteLine("---------");
            //Pedimos la opción
            optionSelected = Convert.ToInt32(Console.ReadLine());

            //Si la opción esta fuera del rango
            //Mostramos error y pedimos de nuevo
            while (optionSelected <= 0 || optionSelected > options.Length + 1)
            {
                Console.WriteLine("Error");
                Console.WriteLine("Select your option again");
                optionSelected = Convert.ToInt32(Console.ReadLine());
            }
            optionSelected--;
            
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