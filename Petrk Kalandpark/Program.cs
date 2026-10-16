using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrk_Kalandpark
{
    internal class Program
    {

        static void MenuKiir()
        {
            Console.WriteLine("=== PETRIK KALANDPARK ===");
            Console.WriteLine();

            Console.WriteLine("1.) Napijegy vásárlása");
            Console.WriteLine("2.) Pálya választása");
            Console.WriteLine("3.) Kupon kalkulátor");
            Console.WriteLine("4.) Napi bevétel");
            Console.WriteLine("5.) Kilépés");
            Console.WriteLine();
        }

        static string JegyTipus(int eletkor)
        {
            if (eletkor >= 0 && eletkor <= 7)
            {
                return "Mini jegy";
            } else if (eletkor >= 8 && eletkor <= 15)
            {
                return "Junior jegy";
            } else if (eletkor >= 16 && eletkor <= 24)
            {
                return "Ifjúsági jegy";
            } else if (eletkor >= 25 && eletkor <= 59)
            {
                return "Felnőtt jegy";
            } else
            {
                return "Senior jegy";
            }
        }

        static int JegyAr(int eletkor)
        {
            if (eletkor >= 0 && eletkor <= 7)
            {
                return 1000;
            }
            else if (eletkor >= 8 && eletkor <= 15)
            {
                return 2200;
            }
            else if (eletkor >= 16 && eletkor <= 24)
            {
                return 3000;
            }
            else if (eletkor >= 25 && eletkor <= 59)
            {
                return 4500;
            }
            else
            {
                return 2800;
            }
        }

        static string PalyaValasztas(int palya, int magassag)
        {
            switch (palya)
            {
                case 1:
                    if (magassag >= 90)
                    {
                        return "Használhatod ezt a pályát!";
                    } else
                    {
                        return "Nem használhatod ezt a pályát!";
                    }

                case 2:
                    if (magassag >= 130)
                    {
                        return "Használhatod ezt a pályát!";
                    }
                    else
                    {
                        return "Nem használhatod ezt a pályát!";
                    }

                case 3:
                    if (magassag >= 160)
                    {
                        return "Használhatod ezt a pályát!";
                    }
                    else
                    {
                        return "Nem használhatod ezt a pályát!";
                    }

                default: {
                        return "Nincs ilyen pálya!";
                    }
            }
        }

        static int KuponosAr(int ar, int kupon)
        {
            switch (kupon)
            {
                case 1:
                    return ar;

                case 2:
                    return ar - (ar * 10) / 100;

                case 3:
                    return ar - (ar * 25) / 100;

                default:
                    {
                        return 0;
                    }
            }
        }

        static void Main(string[] args)
        {
            int valasztas = 0;

            int bevetel = 0;

            do
            {

                try
                {
                    Console.Clear();
                    MenuKiir();

                    Console.Write("Mit választasz?: ");
                    valasztas = Convert.ToInt32(Console.ReadLine());

                    switch (valasztas)
                    {
                        case 1:
                            Console.Clear();

                            Console.Write("Mi a neved?: ");
                            string nev = Console.ReadLine();

                            Console.Write("Hány éves vagy?: ");
                            int eletkor = Convert.ToInt32(Console.ReadLine());

                            if (eletkor >= 0 && eletkor <= 120)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Szia {nev}!");
                                Console.WriteLine($"Jegytípus: {JegyTipus(eletkor)}.");
                                Console.WriteLine($"Fizetendő: {JegyAr(eletkor)} Ft.");

                                bevetel += JegyAr(eletkor);

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Hibás életkor!");
                            }

                            Console.ReadLine();
                            break;

                        case 2:

                            Console.Clear();

                            Console.WriteLine("=== KALANDPÁLYÁK ===");
                            Console.WriteLine();

                            Console.WriteLine("1.) Gyerekpálya");
                            Console.WriteLine("2.) Erdei pálya");
                            Console.WriteLine("3.) Extrém pákya");

                            Console.Write("Melyik páylát választod?: ");
                            int palya = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Milyen magas vagy?: ");
                            int magassag = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine();
                            Console.WriteLine(PalyaValasztas(palya, magassag));

                            Console.ReadLine();
                            break;

                        case 3:
                            Console.Clear();

                            Console.Write("Add meg az eredeti árat: ");
                            int ar = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine();
                            Console.WriteLine("1.) Nincs kupon");
                            Console.WriteLine("2.) SILVER kupon - 10%");
                            Console.WriteLine("3.) GOLD kupon - 25%");
                            Console.WriteLine();

                            Console.Write("Add meg a kupon sorszámát: ");
                            int kupon = Convert.ToInt32(Console.ReadLine());

                            int fizetendo = KuponosAr(ar, kupon);
                            Console.WriteLine();

                            if (fizetendo != 0)
                            {
                                Console.WriteLine($"Fizetendő: {fizetendo} Ft");
                            }
                            else
                            {
                                Console.WriteLine("Nincs ilyen kupon!");
                            }

                            Console.ReadLine();
                            break;

                        case 4:
                            Console.Clear();

                            Console.WriteLine("=== NAPI BEVÉTEL ===");
                            Console.WriteLine();

                            Console.WriteLine($"A kalandpark mai bevétele: {bevetel} Ft");

                            Console.ReadLine();
                            break;


                    }

                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Hiba! Számot kell megadni!");
                    Console.ReadLine();
                }

            } while (valasztas != 5);
                Console.WriteLine();
                Console.WriteLine("Viszlát!");
                Console.ReadLine();

                Environment.Exit(0);

            }
    }
}
