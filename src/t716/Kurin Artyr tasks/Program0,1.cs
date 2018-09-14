using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Drawing;


namespace TRPOtask2
{
    class GetProcessesByNameClass
    {
        static public System.Timers.Timer tm = new System.Timers.Timer();
        static public System.Timers.Timer tm1 = new System.Timers.Timer();
        static void Main(string[] args)
        {
            tm.Elapsed += new System.Timers.ElapsedEventHandler(FirstVariant);
            tm.Interval = 500;
            tm1.Elapsed += new System.Timers.ElapsedEventHandler(SecondVariant);
            tm1.Interval = 500;
            Console.Write("Pls choice your variant = ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)//Метод который возращает первый элемент массива
            {
                case 1:
                    {
                        tm.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        tm1.Enabled = true;
                        break;
                    }
                default:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
            Console.ReadKey();
        }
        public static void SecondVariant(object send, ElapsedEventArgs a)
        {
            Console.Clear();
            PerformanceCounter ob1 = new PerformanceCounter("Processor", " Cp %", "_Total");
            PerformanceCounter ob2 = new PerformanceCounter("Memory", " use dedicated memory%");
            Console.WriteLine("Processor downloaded on {0}% , Memory downloaded on {1}%  ", ob1.NextValue(), ob2.NextValue());
            Console.Write("[");
            for (int i = 0; i < 100; i++)
            {
                if (i < (int)ob2.NextValue())
                    Console.Write("|");
                else
                    Console.Write(".");
            }
            Console.Write("]\n\n");
        }
        public static void FirstVariant(object send, ElapsedEventArgs a)
        {
            Console.Clear();
            Thread.Sleep(1000);
            int i = 0; double some1 = 0; double some2 = 0;
            Process[] processes = Process.GetProcesses();
            Console.WriteLine("{0,-25} ||| {1,-11} ||| {2,-11}||| {3,-11} |||", "Name", "PID", "RAM_Ussage", "CPU_ussage");
            Console.WriteLine("\n\n\n");

            foreach (Process p in processes)//Processing
            {
                some2 += p.PagedSystemMemorySize64 / 1000000;
                i++;
                some1 += p.WorkingSet64 / 1000000;
                Console.WriteLine("{0,-25}|||{1,-11}|||{2,-11}|||{3,-11}|||", p.ProcessName, p.Id, p.PagedSystemMemorySize64 / 1000000, p.PagedMemorySize64 / 1000000);
            }
            Console.WriteLine("\n\n"
                + "\n" +
                some1
                + " Resultate:\n Count process: "
                + i +
                "\nCount public CPU: "
                + some2
                + "\nMachineName: "
                + Environment.MachineName);

        }
    }
}
