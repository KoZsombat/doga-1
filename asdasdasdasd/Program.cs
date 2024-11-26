namespace asdasdasdasd
{
    internal class Program
    {
        public static string[] raktar = { "alma", "körte", "mák", "cigány", "cigány család", "fekete bors", "fekete ember", "fehér bors", "közmunkás" };
        public static int[] raktarAr = [200,300,400,8000,5000,500,10000,1000,11000];
        public static int[] raktarKeszlet = [10,10,10,10,10,10,10,10,10];
        public static List<string> kosar = new List<string>();
        public static List<int> kosarMennyiseg = new List<int>();
        static void Main(string[] args)
        { 
            bool fut = true;
            while (fut) {
                Console.WriteLine("1. Raktárkészlet kezelése\n2. Vásárlói kosár kezelése.\n3. Vásárlási műveletek szimulálása\n4. Statisztikák előállítása.");
                switch (Console.ReadLine()) {
                    case "1":
                        Console.WriteLine("1. Raktárkészlet megtekintése\n2. Új termék.\n3. Rendezés");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                listRaktar();
                                break;
                            case "2":
                                Ujtermek();
                                break;
                            case "3":
                                Rendez();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("1. Vétel\n2. Visszarak\n3. Kosár megtekintés\n4. Kosár ütítés");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Hozzaadas();
                                Ellenorzes();
                                break;
                            case "2":
                                Kivonás();
                                break;
                            case "3":
                                KosarMegtekintes();
                                break;
                            case "4":
                                Urites();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        Sim();
                        break;
                    case "4":
                        Console.WriteLine("1. Legdrágább\n2. Legolcsóbb\n3. Statisztikák\n4. Teljes ár");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Draga();
                                break;
                            case "2":
                                Olcso();
                                break;
                            case "3":
                                Stat();
                                break;
                            case "4":
                                TeljesAr();
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        static void listRaktar()
        {
            for (int i = 0; i < raktar.Length; i++)
            {
                Console.WriteLine($"{raktar[i]}, {raktarKeszlet[i]} db, {raktarAr[i]} Ft");
            }
        }

        static void Hozzaadas()
        {
            Console.WriteLine("Melyik terméket szeretnéd hozzáadni a kosárhoz?");
            string termek = Console.ReadLine();
            if (raktar.Contains(termek.ToLower()))
            {
                for (int i = 0; i < raktar.Length; i++)
                {
                    if (raktar[i].ToLower() == termek.ToLower())
                    {
                        Console.WriteLine("Hány darabot szeretnél?");
                        int menny = Convert.ToInt32(Console.ReadLine());
                        if (raktarKeszlet[i] >= menny)
                        {
                            raktarKeszlet[i] -= menny;
                            kosar.Add(raktar[i].ToLower());
                            kosarMennyiseg.Add(menny);
                        }
                        else
                        {
                            Console.WriteLine("Nincs ennyi a raktárban");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen termék");
            }

        }

        static void KosarMegtekintes()
        {
            for (int i = 0; i < kosar.Count; i++)
            {
                Console.WriteLine($"{kosar[i]}, {kosarMennyiseg[i]} db");
            }
        }

        static void Kivonás()
        {
            Console.WriteLine("Melyik terméket szeretnéd eltávolítani a kosárból?");
            string termek = Console.ReadLine();
            if (kosar.Contains(termek.ToLower()))
            {
                for (int i = 0; i < kosar.Count; i++)
                {
                    if (kosar[i].ToLower() == termek.ToLower())
                    {
                        raktarKeszlet[Array.IndexOf(raktar, kosar[i])] += kosarMennyiseg[i];
                        kosarMennyiseg.Remove(kosarMennyiseg[i]);
                        kosar.Remove(kosar[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen termék");
            }

        }

        static void Urites()
        {
            while (kosar.Count != 0)
            {
                raktarKeszlet[Array.IndexOf(raktar, kosar[0])] += kosarMennyiseg[0];
                kosar.RemoveAt(0);
                kosarMennyiseg.RemoveAt(0);
            }
        }

        static void Sim()
        {
            int koltseg = 0;

            for (int i = 0; i < kosar.Count; i++)
            {
                koltseg += raktarAr[Array.IndexOf(raktar, kosar[i])] * kosarMennyiseg[i];
            }

            for (int i = 0; i < kosar.Count; i++)
            {
                Console.WriteLine($"Vásárolt termék: {kosar[i]}, {kosarMennyiseg[i]} db, {raktarAr[Array.IndexOf(raktar, kosar[i])]} Ft.");
            }
            Console.WriteLine($"Összesen: {koltseg}");
        }

        static void Draga()
        {
            for (int i = 0; i < raktar.Length; i++)
            {
                if (raktarAr[i] == raktarAr.Max())
                {
                    Console.WriteLine($"A legdrágábbb árú: {raktar[i]}");
                }
            }
        }

        static void Olcso()
        {
            for (int i = 0; i < raktar.Length; i++)
            {
                if (raktarAr[i] == raktarAr.Min())
                {
                    Console.WriteLine($"A legolcsóbb árú: {raktar[i]}");
                }
            }
        }

        static void Stat()
        {
            Console.WriteLine($"Különböző termékek száma: {kosar.Count}, vett termékek száma: {kosarMennyiseg.Sum()}");
        }

        static void Ellenorzes()
        {
            for (int i = 0; i < raktar.Length; i++)
            {
                if (raktarKeszlet[i] < 5)
                {
                    Console.WriteLine($"{raktar[i]}-ből kevesebb mint 5 db maradt!");
                }
            }
        }

        static void TeljesAr()
        {
            int koltseg = 0;

            for (int i = 0; i < kosar.Count; i++)
            {
                koltseg += raktarAr[Array.IndexOf(raktar, kosar[i])] * kosarMennyiseg[i];
            }

            Console.WriteLine($"Összesen: {koltseg}");
        }

        static void Ujtermek()
        { 
            if (raktar.Length < 10)
            {
                Console.WriteLine("Mi az új termék neve?");
                string nev = Console.ReadLine().ToLower();
                Console.WriteLine("Mennyi legyen az új termékből a raktárban?");
                int menny = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Mennyi legyen az új terméknek az ára?");
                int ar = Convert.ToInt32(Console.ReadLine());
                raktar.Append(nev);
                raktarKeszlet.Append(menny);
                raktarAr.Append(ar);

            }
            else
            {
                Console.WriteLine("Nincs eleg hely.");
            }
        }

        static void Rendez()
        {
            int[] raktarardup = raktarAr;
            Array.Sort(raktarardup);
            for (int i = 0; i < raktar.Length; i++)
            {
                Console.WriteLine(raktar[Array.IndexOf(raktarAr, raktarardup[i])]);
            }
            
        }

    }
}
