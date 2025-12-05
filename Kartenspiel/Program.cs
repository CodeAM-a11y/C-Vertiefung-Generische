namespace Kartenspiel
{
    public class KartenspielKlasse
    {
        public Stack<string> KartenDeckPik = new Stack<string>();
        public Stack<string> KartenDeckHerz = new Stack<string>();
        public Stack<string> NeuDeckGemischt = new Stack<string>();
        public Stack<string> StapelEins = new Stack<string>();
        public Stack<string> StapelZwei = new Stack<string>();
        public Stack<string> StapelDrei = new Stack<string>();
        public Stack<string> StapelVier = new Stack<string>();

        public KartenspielKlasse()
        {
            KartenDeckPik.Push("Pik 7");
            KartenDeckPik.Push("Pik 8");
            KartenDeckPik.Push("Pik 9");
            KartenDeckPik.Push("Pik 10");
            KartenDeckPik.Push("Pik Bube");
            KartenDeckPik.Push("Pik Dame");
            KartenDeckPik.Push("Pik König");
            KartenDeckPik.Push("Pik Ass");

            KartenDeckHerz.Push("Herz 7");
            KartenDeckHerz.Push("Herz 8");
            KartenDeckHerz.Push("Herz 9");
            KartenDeckHerz.Push("Herz 10");
            KartenDeckHerz.Push("Herz Bube");
            KartenDeckHerz.Push("Herz Dame");
            KartenDeckHerz.Push("Herz König");
            KartenDeckHerz.Push("Herz Ass");
        }
        public List<Stack<string>> TeilStapelErstellen(Stack<string> StapelZuTeilen, int anzahlS) //zu bearbeiten
        {
            int counter = 0;
            int ZuTeilenLänge = StapelZuTeilen.Count;
            List<Stack<string>> liste = new List<Stack<string>>(); //
            for(int i=0;i< anzahlS; i++)
            {
                liste.Add(new Stack<string>());
                for(int x = 0; x < ZuTeilenLänge / anzahlS; x++)
                {
                    liste[i].Push(StapelZuTeilen.Pop());
                }
            }
            if (StapelZuTeilen.Count > 0) { liste[anzahlS - 1].Push(StapelZuTeilen.Pop()); }
            return liste;
        }
        public void DeckAusgeben(Stack<string> anzeigenDeck)
        {
            foreach(var item in anzeigenDeck)
            {
                Console.WriteLine(item);
            }
        }
        public void NeuenStapel()
        {
            foreach (var item in KartenDeckPik)
            {
                item.Replace("Pik", "Karo");
                NeuDeckGemischt.Push(item);
            }
            foreach (var item in KartenDeckHerz)
            {
                item.Replace("Herz", "Kreuz");
                NeuDeckGemischt.Push(item);
            }
        }
        public void VierDecks()
        {
            for (int i = 0; i < 16; i++)
            {
                switch (i)
                {
                    case < 4: StapelEins.Push(NeuDeckGemischt.Pop()); break;
                    case < 8 and > 3: StapelZwei.Push(NeuDeckGemischt.Pop()); break;
                    case < 12 and > 7: StapelDrei.Push(NeuDeckGemischt.Pop()); break;
                    case < 16 and > 11: StapelVier.Push(NeuDeckGemischt.Pop()); break;
                }
            }
            for(int i=0;i<4;i++)
            {
                StapelDrei.Push(StapelEins.Pop());
            }
            for (int i = 0; i < 4; i++)
            {
                StapelVier.Push(StapelZwei.Pop());
            }
            for(int i = 0; i < 8; i++)
            {
                StapelVier.Push(StapelDrei.Pop());
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            KartenspielKlasse k1 = new KartenspielKlasse();
            k1.NeuenStapel();
            k1.VierDecks();
            Console.WriteLine("Stappel Vier: ");
            k1.DeckAusgeben(k1.StapelVier);
            Console.WriteLine("KartenDeckPik: ");
            k1.DeckAusgeben(k1.KartenDeckPik);
            Console.WriteLine("Neues Kommando!!!: ");
            foreach(var item in k1.TeilStapelErstellen(k1.StapelVier, 5))
            {
                foreach(string str in item)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
