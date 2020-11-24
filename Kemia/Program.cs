using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kemia
{
    class Program
    {
        static string be;
        static List<Elem> elemek = new List<Elem>();
        static Dictionary<string, int> felfedez_evek = new Dictionary<string, int>();
        static void Beolvasas()
        {
            StreamReader olvas = new StreamReader("felfedezesek.csv");
            olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                string[] a = olvas.ReadLine().Split(';');
                elemek.Add(new Elem(a[0],a[1],a[2],a[3],a[4]));
            }
            olvas.Close();
            //foreach (var i in elemek)
            //{
            //    Console.WriteLine(i.Felfedezo);
            //}
        }
        static void Harmadik()
        {
            Console.WriteLine($"3. feladat: Elemek száma: {elemek.Count}");
        }
        static void Negyedik()
        {
            int okor = 0;
            foreach (var i in elemek)
            {
                if (i.Ev==0)
                {
                    okor++;
                }
            }
            Console.WriteLine($"4. feladat: Felfedezések száma az ókorban: {okor}");
        }
        static bool Validal(string mit)
        {
            bool vissza = false;
            mit = mit.ToUpper();
            if (mit.Length == 0 || mit.Length > 2)
            {
                vissza = true;
            }
            else
            {
                foreach (char betu in mit)
                {
                    int kod = (int)betu;
                    if (!(kod >= 65 && kod <= 90))
                    {
                        vissza = true;               
                    }
                }
            }         
            return vissza;    
            //string abc = "abcdefghijklmnopqrstuvxyz";
        }
        static void Otodik()
        {         
            bool nemjo = true;
            while (nemjo)
            {
                Console.Write("Kérek egy vegyjelet: ");
                be = Console.ReadLine();
                nemjo = Validal(be);
            }           
        }
        static void Hatodik()
        {
            string neve = "";
            string rsz = "";
            string felfedezes = "";
            string felfedezo = "";
            string vegyjel = "";
            bool vane = true;
            foreach (var i in elemek)
            {
                if (i.Vegyjel.Contains(be))
                {
                    neve = i.Nev;
                    vegyjel = i.Vegyjel;
                    rsz = i.Rsz;
                    felfedezes = i.SEV;
                    felfedezo = i.Felfedezo;
                    vane = true;
                    break;                  
                }
                else
                {
                    vane = false;
                }
            }
            if (vane)
            {
                Console.WriteLine($"6. feladat: Keresés" +
              $"\n\t Az elem vegyjele:{vegyjel}" +
              $"\n\t Az elem neve: {neve} \n\t Rendszáma: {rsz} \n\t Felfedezés éve: {felfedezes} \n\t Felfedező: {felfedezo}");
            }
            else
            {
                Console.WriteLine("\t nincs");
            }
        }
        static void Hetedik()
        {
            //List<int> kulonbsegek = new List<int>();
            int kul = 0;
            int max = 0;
            for (int i = 10; i < elemek.Count; i++)
            {
                kul = elemek[i].Ev-elemek[i-1].Ev;
                if (kul > max)
                {
                    max = kul;
                }
                //kulonbsegek.Add(kul);
            }
            //foreach (var i in kulonbsegek)
            //{
            //    Console.WriteLine(i);
            //}
            Console.WriteLine($"7. feladat: {max} év volt a leghosszabb időszak különbség két elem felfedezése között.");
        }
        static void Nyolcadik()
        {
            foreach (var i in elemek)
            {
                if (!felfedez_evek.ContainsKey(i.SEV))
                {
                    felfedez_evek.Add(i.SEV, 0);
                }
            }
            foreach (var i in elemek)
            {
                if (felfedez_evek.ContainsKey(i.SEV))
                {
                    felfedez_evek[i.SEV]++;
                }
            }
            felfedez_evek.Remove("Ókor");
            foreach (var i in felfedez_evek)
            {                
                if (i.Value > 3)
                {
                    Console.WriteLine($"\t{i.Key} {i.Value}");
                }
            }
        }
        static void Main(string[] args)
        {
            Beolvasas();
            Harmadik();
            Negyedik();
            Otodik();
            Hatodik();
            Hetedik();
            Nyolcadik();
            Console.ReadKey();
        }
    }
}
