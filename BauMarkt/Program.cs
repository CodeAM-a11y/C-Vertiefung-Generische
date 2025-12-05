using System;
using System.Linq;

namespace BauMarkt
{
    public class Baumarkt
    {
        Dictionary<string, List<string>> listeArtikel = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> ArtikelKundennummer = new Dictionary<string, List<string>>();

        public void ListeAusgebenNeu()
        {
            foreach (var item in ArtikelKundennummer)
            {
                Console.WriteLine($"Artikel:{item.Key}");
                foreach (string listItem in item.Value)
                {
                    Console.WriteLine($"-{listItem}");
                }
            }
        }
        public void DatenVerarbeitungNeu()
        {
            foreach (var item in listeArtikel)
            {
                foreach (string listItem in item.Value)
                {
                    if (!ArtikelKundennummer.ContainsKey(listItem)) //Artikel als Keys in ArtikelKundennummer
                    { 
                        ArtikelKundennummer.Add(listItem, new List<string>());
                    } 
                }
            }
            foreach (var KundenNr in listeArtikel) //abgleichen ob listeArtikel keys Liste ArtikelKundennummer Key entsprechen
            {
                foreach (var artikelKey in ArtikelKundennummer)
                {
                    if (KundenNr.Value.Contains(artikelKey.Key))
                    {
                        artikelKey.Value.Add(KundenNr.Key);
                    }
                }
            }
        }
        public void ListeAusgeben()
        {
            foreach(var item in listeArtikel)
            {
                Console.WriteLine($"Kundennummer: {item.Key}");
                foreach(string listItem in item.Value)
                {
                    Console.WriteLine($"-{listItem}");
                }
            }
        }
        public void Datenverarbeitung(string text)
        {
            string[] kunde = text.Split("\n");
            for(int i = 0; i < kunde.Length; i++)
            {
                listeArtikel.Add(kunde[i].Split(';')[0], kunde[i].Split(';')[1].Split(',').ToList()); //fügt die Kundennummern zu Liste hinzu
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Baumarkt b1 = new Baumarkt();
            b1.Datenverarbeitung("0123; Hammer, Dübel, Nägel\n"
             + "4711; Kantholz, Säge, Nägel, Leim\n"
             + "8698; Schrauben, Dübel, Hänge-WC\n"
             + "9876; Fischfutter, Hammer, Säge\n"
             + "4862; Kantholz, Säge\n"
             + "3179; Schrauben, Schraubenzieher, Dübel\n"
             + "7410; Leim, Fischfutter\n"
             + "8520; Hänge-WC, Nägel, Säge");
            b1.ListeAusgeben();
            b1.DatenVerarbeitungNeu();
            b1.ListeAusgebenNeu();
        }
    }
}
