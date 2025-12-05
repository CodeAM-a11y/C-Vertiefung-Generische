namespace JobListe
{
    public class JobVerwaltung
    {
        private Queue<Job> listeMitJobs = new Queue<Job>();
        public void ShowAllJobs()
        {
            foreach(Job j in listeMitJobs)
            {
                Console.WriteLine(j.bezeichnung);
            }
        }
        public int AddJob(Job hinzufügen)
        {
            listeMitJobs.Enqueue(hinzufügen);
            return listeMitJobs.Count;
        }
        public int GetJobDone()
        {
            Console.WriteLine(listeMitJobs.Dequeue().bezeichnung);
            return listeMitJobs.Count;
        }
    }
    public class Job
    {
        public string bezeichnung { get; set; }
        public string auftragGeber { get; set; }
        public int dauer { get; set; }
        public Job(string bezeichnung, string auftragGeber, int dauer)
        {
            this.bezeichnung = bezeichnung;
            this.auftragGeber = auftragGeber;
            this.dauer = dauer;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Job neuerJob = new Job("Putzmann","BITLC",6);
            Job neuerJob1 = new Job("Fachkraft", "BITLC", 4);
            Job neuerJob2 = new Job("Superfachkraft", "BITLC", 7);
            JobVerwaltung neueVerwaltung = new JobVerwaltung();
            neueVerwaltung.AddJob(neuerJob1);
            neueVerwaltung.AddJob(neuerJob2);
            Console.WriteLine(neueVerwaltung.AddJob(neuerJob));
            Console.WriteLine(neueVerwaltung.GetJobDone());
            neueVerwaltung.ShowAllJobs();
        }
    }
}
