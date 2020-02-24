using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppC
{
    class Program
    {
        static void Main(string[] args)
        {
            string zeile, datei, op, name;
            string[] inhalt;
            int alter = 0;
            StreamReader sr = null;
            StreamWriter sw = null;

            Console.WriteLine("Test");
            Console.Write("Eingabe Pfad und Dateinahme (z.B. C:\\daten\\kunden.txt): ");
            datei = Console.ReadLine();

            do
            {
                Console.Write("Datei lesen (l) oder schreiben (s), beenden (x): ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "l":
                        //Streamreader oeffnen und Datei einlesen
                        sr = new StreamReader(@datei);

                        //Erste Zeile aus Datei einlesen
                        zeile = sr.ReadLine();
                        while (zeile != null)
                        {
                            inhalt = zeile.Split(';');
                            name = inhalt[0];
                            alter = Convert.ToInt32(inhalt[1]);
                            Console.WriteLine("{0} ist {1} Jahre alt.", name, alter);
                            //Naechste Zeile einlesen
                            zeile = sr.ReadLine();
                        }
                        sr.Close();
                        sr = null;
                        break;

                    case "s":
                        {
                            //StreamWriter oeffnen und Datei erzeugen
                            sw = new StreamWriter(@datei);

                            Console.WriteLine("Daten einlesen (beenden mit Name = -1):");
                            while (true)
                            {
                                Console.Write("Eingabe Alter: ");
                                alter = Convert.ToInt32(Console.ReadLine());

                                if (alter == -1)
                                    break;

                                Console.Write("Eingabe Name : ");
                                name = Console.ReadLine();

                                sw.WriteLine(name + ";" + alter.ToString());
                            }
                            sw.Close();
                            sw = null;
                        }
                        break;

                    case "x":
                        break;

                    default:
                        Console.WriteLine("Operation '{0}' nicht definiert!", op);
                        break;
                }
            } while (op != "x");
        }
    }
}
