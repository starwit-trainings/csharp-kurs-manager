
using System.Reflection.Metadata;


namespace KursManager
{
    internal class Programm
    {

        static void Main(string[] args)
        {
            KursService service = new KursService();

            //Kursliste
            service.KursListe = service.ReadAllKurseFromCSV("C:\\Users\\anett\\git\\csharp-basics\\kurse.csv");

            //Teilnehmerliste
            service.TeilnehmerListe = service.ReadAllTeilnehmerFromCSV("C:\\Users\\anett\\git\\csharp-basics\\teilnehmer.csv");

            Console.WriteLine("+++++++ Alle Kurse ++++++++");
            List<Kurs> testKurse = service.findFromDB();
            foreach (var kurs in testKurse)
            {
                Console.WriteLine(kurs);
                foreach (var teilnehmer in kurs.TeilnehmerList)
                {
                    Console.WriteLine(teilnehmer);
                }

            }

            Console.WriteLine("+++++++ Alle Teilnehmer ++++++++");
            foreach (var teilnehmer in service.TeilnehmerListe)
            {
                Console.WriteLine(teilnehmer);
            }

            Console.WriteLine("+++++++ momentane Kurse ++++++++");
            List<Kurs> currentKursList = service.findKursByDate(DateTime.Now.ToString("dd.M.yyyy"));
            foreach (var kurs in currentKursList)
            {
                Console.WriteLine(kurs);
            }

            Console.WriteLine("+++++++ momentane Kurse eines Teilnehmers ++++++++");
            Console.WriteLine("Gib einen Namen eines Teilnehmers ein:");
            string? teilnehmerName = Console.ReadLine();
            currentKursList = service.findKursByTeilnehmerNameAndDate(teilnehmerName, DateTime.Now.ToString("dd.M.yyyy"));
            foreach (var kurs in currentKursList)
            {
                Console.WriteLine(kurs);
            }

            Console.WriteLine("+++++++ Kurse am Tag x ++++++++");
            Console.WriteLine("Gib ein Datum ein:");
            string? date = Console.ReadLine();
            currentKursList = service.findKursByDate(date);
            foreach (var kurs in currentKursList)
            {
                Console.WriteLine(kurs);
            }
        }
    }
}
