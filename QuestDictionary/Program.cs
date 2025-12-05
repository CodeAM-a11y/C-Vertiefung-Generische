namespace QuestDictionary
{
    public class QuestSammlung
    {
        public List<Quest> ListeQuests { get; set; } = new List<Quest>();
    }
    public class Quest
    {
        public string name { get; set; }
        public string Beschreibung { get; set; }
        public List<Item> benötigteItems = new List<Item>();

        public Quest(string name, string Beschreibung)
        {
            this.name = name;
            this.Beschreibung = Beschreibung;

        }

    }
    public class Item
    {
        public string name { get; set; }
        public string eigenschaft { get; set; }

        public Item(string name, string eigenschaft)
        {
            this.name = name;
            this.eigenschaft = eigenschaft;
        }
    }
    public class Hobbit
    {
        public string name { get; set; }
        public List<Item> Inventar = new List<Item>();
        public int WeisheitsLvl = 0;
        public Hobbit(string name)
        {
            this.name = name;
        }
        public void AufgabeErledigen()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            QuestSammlung q1 = new QuestSammlung();
            Quest DieWache = new Quest("Die Wache für Bergil – „Der Dienst am Tor“", "\"Ich bin jetzt ein Mann von Gondor!\"\r\nAufgabe:\r\nPippin verspricht dem jungen Bergil, dessen Vater in der Schlacht ist, Wache am Tor von Minas Tirith zu halten – nicht aus Pflicht, sondern aus Freundschaft und Respekt. Er dient unter Hauptmann Hador und bleibt wachsam, während die Schatten über das Land kriechen.\r\n");
            Item nahrung = new Item("lebensmittel","nahrung");
            Item Uniform = new Item("Uniform der Wache", "Verkleidung");
            Item LanzeWache = new Item("Lanze der Wache", "Waffe");
            Quest ersteQuest = new Quest("Vorräte klauen", "Du musst Vorräte klauen");
            DieWache.benötigteItems.Add(nahrung);
            DieWache.benötigteItems.Add(Uniform);
            DieWache.benötigteItems.Add(LanzeWache);

        }
    }
}
