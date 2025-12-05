namespace QuestDictionary
{
    public class QuestSammlung
    {
        public List<Quest> ListeQuests { get; set; } = new List<Quest>();
        public void QuestsAuflisten()
        {
            Console.WriteLine($"Noch zu erledigende Quests: ");
            foreach (Quest item in ListeQuests)
            {
                if (item.QuestErledigt == false) { Console.WriteLine($"{item.name} Beschreibung: {item.Beschreibung}"); }
            }
        }
    }
    public class Quest
    {
        public bool QuestErledigt { get; set; } = false;
        public string name { get; set; }
        public string Beschreibung { get; set; }
        public List<Item> Belohnungen = new List<Item>();
        public string benötigteItems;

        public Quest(string name, string Beschreibung, Item belohnung, string benötigteItems)
        {
            this.name = name;
            this.Beschreibung = Beschreibung;
            Belohnungen.Add(belohnung);
            this.benötigteItems = benötigteItems;
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
            Item dietrich = new Item("Dietrich", "TürÖffnen");
            this.name = name;
            Inventar.Add(dietrich);
        }
        public void AufgabeErledigen(Quest zuErledigen)
        {
            if (zuErledigen.QuestErledigt == false)
            {

                if (Inventar.Exists(x=>x.eigenschaft.Equals(zuErledigen.benötigteItems)))
                {
                    foreach (Item toRetreive in zuErledigen.Belohnungen)
                    {
                        Inventar.Add(toRetreive);
                        Console.WriteLine($"erhalten: {toRetreive.name} ");
                    }
                    zuErledigen.QuestErledigt = true;
                    Console.WriteLine($"Gratuliere du hast die Quest {zuErledigen.name} geschafft.");
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            QuestSammlung q1 = new QuestSammlung();
            Item Uniform = new Item("Uniform der Wache", "Verkleidung");
            Item LanzeWache = new Item("Lanze der Wache", "Waffe");
            Quest DieWache = new Quest("Die Wache für Bergil – „Der Dienst am Tor“", "\"Ich bin jetzt ein Mann von Gondor!\"\r\nAufgabe:\r\nPippin verspricht dem jungen Bergil, dessen Vater in der Schlacht ist, Wache am Tor von Minas Tirith zu halten – nicht aus Pflicht, sondern aus Freundschaft und Respekt. Er dient unter Hauptmann Hador und bleibt wachsam, während die Schatten über das Land kriechen.\r\n", LanzeWache,"nahrung");
            Item nahrung = new Item("Brot der Stadt","nahrung");
            Quest ersteQuest = new Quest("Vorräte klauen", "Du musst Vorräte klauen", nahrung, "TürÖffnen");
            Hobbit h1 = new Hobbit("Frodo");
            q1.ListeQuests.Add(DieWache);
            q1.ListeQuests.Add(ersteQuest);
            q1.QuestsAuflisten();
            h1.AufgabeErledigen(ersteQuest);
            h1.AufgabeErledigen(DieWache);
        }
    }
}
