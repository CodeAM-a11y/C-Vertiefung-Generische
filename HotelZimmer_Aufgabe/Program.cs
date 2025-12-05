using System.Globalization;
using System.Text;

namespace HotelZimmer_Aufgabe
{
    public class Hotel
    {
        public Dictionary<string, string> buchungen;
        public List<Dictionary<string, string>> Keys = new List<Dictionary<string, string>>();

        public void Datenverarbeiten(string text)
        {
            string[] subs = text.Split("\n");
            string[] wörter = new string[subs.Length];
            for(int i = 0; i < subs.Length; i++)
            {
                buchungen = new Dictionary<string, string>();

                wörter = subs[i].Split(';');
                for (int x = 0; x < 3; x++)
                {
                    switch (x)
                    {
                        case 0: buchungen.Add("Zimmer: ", subs[x]); break;
                        case 1: if (subs[x].Equals('D')) { buchungen.Add("Zimmertyp: ", "Doppelzimmer"); } else { buchungen.Add("Zimmertyp: ", "Einzelzimmer"); } break;
                        case 2: buchungen.Add("Vor - und Nachname: ", subs[x]); break;
                        case 3: buchungen.Add("Wohnort: ", subs[x]); break;
                    }
                }
                Keys.Add(buchungen);
            }
            foreach (Dictionary<string, string> item in Keys)
            {
                foreach(var item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel h1 = new Hotel();
            h1.Datenverarbeiten("15;D;Peter Schmidt;Wuppertal\n"
            + "17;D;Hans Meier;Düsseldorf\n"
            + "23;E;Regina Schulz;Mettmann\n"
            + "31;D;Kathrin Müller;Erkrath\n"
            + "32;E;Rudolf Kramer;Witten\n"
            + "35;E;Anne Kunze;Bremen");
            
        }
    }
}
