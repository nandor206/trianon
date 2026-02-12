namespace _2013maj
{
    internal class Program
    {

        public struct Nev
        {
            public string vezetek;
            public string utonev;
        }

        public class Szavazat
        {
            public int kerulet { get; set; }
            public int szavazat_szam { get; set; }
            public Nev nev { get; set; }
            public Part part { get; set; }

            public static Szavazat ToStruct(string[] sor)
            {
                Szavazat szavazat = new Szavazat();
                szavazat.kerulet = int.Parse(sor[0]);
                szavazat.szavazat_szam = int.Parse(sor[1]);
                Nev nev = new Nev();
                nev.vezetek = sor[2];
                nev.utonev = sor[3];
                szavazat.nev = nev;
                string part = sor[4];
                switch(part) {
                    case "GYEP": 
                        szavazat.part = Part.GYEP;
                        break;
                    case "HEP":
                        szavazat.part = Part.HEP;
                        break;
                    case "TISZ":
                        szavazat.part = Part.TISZ;
                        break;
                    case "ZEP":
                        szavazat.part = Part.ZEP;
                        break;
                    default:
                        szavazat.part = Part.Fuggetlen;
                        break;
                }

                return szavazat;
            }
        }
        public enum Part
        {
            ZEP,
            HEP,
            GYEP,
            TISZ,
            Fuggetlen
        }

        static List<Szavazat> szavazatok = new List<Szavazat>();
        static int jogsultak = 12345;
        static void Main(string[] args)
        {
            F1();
            F2();
            F3();
            F4();
        }

        static void F1()
        {
            string[] sorok =  File.ReadAllLines("./szavazatok.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                string[] sor = sorok[i].Split(' ');
                Szavazat szavazat = Szavazat.ToStruct(sor);

                szavazatok.Add(szavazat);
            }
        }

        static void F2()
        {
            Console.WriteLine("2. feladat:");
            int szam = szavazatok.Count();
            Console.WriteLine($"A helyhatósági választáson {szam} képviselőjelölt indult.");
        }

        static void F3()
        {
            Console.WriteLine("3. feladat:");
            Console.Write("Kérek egy nevet(vezetéknév, utónév): ");
            string input = Console.ReadLine()!;
            int? id = null;

            for (int i = 0; i < szavazatok.Count; i++)
            {
                Szavazat szavazat = szavazatok[i];
                string[] nev = input.Split(" ");
                if (szavazat.nev.vezetek == nev[0] && szavazat.nev.utonev == nev[1])
                {
                    id = i; break;
                }
            }

            if (id == null)
            {
                Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
            }
            else
            {
                Console.WriteLine($"{input}{szavazatok[id.Value].szavazat_szam} szavazatot kapott");
            }
        }

        static void F4()
        {
            int szavazat_szam = 0;
            for (int i = 0; i < szavazatok.Count; i++)
            {
                szavazat_szam += szavazatok[i].szavazat_szam;
            }

            double egy_szazalek = jogsultak / 100;
            double szazalek = szavazat_szam / egy_szazalek;

            Console.WriteLine($"A választáson {szavazat_szam} állampolgár, a jogosultak {szazalek.ToString("0.##")}%-a vett részt.");
        }

        static void F5()
        {
            int zep = 0;
            int hep = 0;
            int gyep = 0;
            int tisz = 0;
            int fugg = 0;
            int ossz = 0;

            for (int i = 0; i < szavazatok.Count; i++)
            {
                Szavazat szavazat = szavazatok[i];
                switch(szavazat.part)
                {
                    case Part.ZEP:
                        zep += szavazat.szavazat_szam;
                        break;
                    case Part.HEP:
                        hep += szavazat.szavazat_szam;
                        break;
                    case Part.GYEP:
                        gyep += szavazat.szavazat_szam;
                        break;
                    case Part.TISZ:
                        tisz += szavazat.szavazat_szam;
                        break;
                    case Part.Fuggetlen:
                        fugg += szavazat.szavazat_szam;
                        break;
                }
                ossz += szavazat.szavazat_szam;
            }

            int[] szamok = { zep, hep, gyep, tisz, fugg };

            double egy_szazalek = ossz / 100;
            for (int i = 0; i < 5; i++)
            {
                double szazalek = szamok[i] / egy_szazalek;
                Console.WriteLine($"{(Part)i}: {szazalek.ToString("0.##")}");
                
            }

        }
    }
}
