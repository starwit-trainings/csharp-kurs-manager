

namespace KursManager
{
    internal class Programm
    {
        private List<Kurs>? kursListe;

        private List<Teilnehmer>? teilnehmerListe;

        static void Main(string[] args)
        {
            
            Programm programm = new Programm();

            //Kursliste
            programm.kursListe = programm.ReadAllKurseFromCSV("C:\\Users\\anett\\git\\csharp-basics\\kurse.csv");

            //Teilnehmerliste
            programm.teilnehmerListe = programm.ReadAllTeilnehmerFromCSV("C:\\Users\\anett\\git\\csharp-basics\\teilnehmer.csv");

            Console.WriteLine("+++++++ Alle Kurse ++++++++");
            foreach (var kurse in programm.kursListe)
            {
                Console.WriteLine(kurse);
            }

            Console.WriteLine("+++++++ Alle Teilnehmer ++++++++");
            foreach (var teilnehmer in programm.teilnehmerListe)
            {
                Console.WriteLine(teilnehmer);
            }

            Console.WriteLine("+++++++ momentane Kurse ++++++++");
            List<Kurs> currentKursList = programm.findKursByDate(DateTime.Now.ToString("dd.M.yyyy"));
            foreach (var kurs in currentKursList)
            {
                Console.WriteLine(kurs);
            }

            Console.WriteLine("+++++++ momentane Kurse eines Teilnehmers ++++++++");
            Console.WriteLine("Gib einen Namen eines Teilnehmers ein:");
            string? teilnehmerName = Console.ReadLine();
            currentKursList = programm.findKursByTeilnehmerNameAndDate(teilnehmerName, DateTime.Now.ToString("dd.M.yyyy"));
            foreach (var kurs in currentKursList)
            {
                Console.WriteLine(kurs);
            }

            Console.WriteLine("+++++++ Kurse am Tag x ++++++++");
            Console.WriteLine("Gib ein Datum ein:");
            string? date = Console.ReadLine();
            currentKursList = programm.findKursByDate(date);
            foreach (var kurs in currentKursList)
            {
                Console.WriteLine(kurs);
            }
        }

        private List<Kurs> findKursByDate(string? dateString)
        {
            List<Kurs> currentKursList = new List<Kurs>();
            if (kursListe != null)
            {
                foreach (var kurs in kursListe)
                {
                    if (kurs.Dates != null)
                    {
                        foreach (var date in kurs.Dates)
                        {
                            if (date.ToString("dd.M.yyyy") == dateString)
                            {
                                currentKursList.Add(kurs);
                                break;
                            }
                        }
                    }
                }
            }
            return currentKursList;
        }

        private List<Kurs> findKursByTeilnehmerNameAndDate(string? teilnehmerName, string dateString)
        {
            List<Kurs> currentKursList = new List<Kurs>();
            if (teilnehmerListe != null)
            {
                foreach (var teilnehmer in teilnehmerListe)
                {
                    if (teilnehmer.Name == teilnehmerName 
                        && teilnehmer.Kurs != null 
                        && teilnehmer.Kurs.Dates != null)
                    {
                        foreach (var date in teilnehmer.Kurs.Dates)
                        {
                            if (date.ToString("dd.M.yyyy") == dateString)
                            {
                                currentKursList.Add(teilnehmer.Kurs);
                                break;
                            }
                        }
                    }
                }
            }
            return currentKursList;
        }


        private List<Kurs> ReadAllKurseFromCSV(string fileLocation)
        {
            List<Kurs> kursListe = new List<Kurs>();
            StreamReader srKurse = new StreamReader(fileLocation);
            //Read the first line of text
            srKurse.ReadLine();
            string? line = srKurse.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                kursListe.Add(ReadKursFromCSV(line));
                line = srKurse.ReadLine();
            }
            //close the file
            srKurse.Close();
            return kursListe;
        }

        private Kurs ReadKursFromCSV(string kursAsString)
        {
            string[] kursAttributes = kursAsString.Split(",");
            Kurs kurs = new Kurs();
            kurs.Name = kursAttributes[0].Trim();
            kurs.Trainer = kursAttributes[1].Trim();
            string[] dateStrings = kursAttributes[2].Trim().Split(" ");
            kurs.Dates = new DateOnly[dateStrings.Length];
            for (int i = 0; i < dateStrings.Length; i++)
            {
                DateOnly.TryParseExact(dateStrings[i].Trim(), "dd.M.yyyy", out kurs.Dates[i]);
            }
            return kurs;
        }

        private List<Teilnehmer> ReadAllTeilnehmerFromCSV(string fileLocation)
        {
            List<Teilnehmer> teilnehmerListe = new List<Teilnehmer>();
            string? line;
            StreamReader srTeilnehmer = new StreamReader(fileLocation);

            //Read the first line of text
            srTeilnehmer.ReadLine();

            //Read second line -> skip heading
            line = srTeilnehmer.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                teilnehmerListe.Add(ReadTeilnehmerFromCSV(line));
                line = srTeilnehmer.ReadLine();
            }

            //close the file
            srTeilnehmer.Close();
            return teilnehmerListe;
        }

        private Teilnehmer ReadTeilnehmerFromCSV(string teilnehmerAsString)
        {
            string[] teilnehmerAttributes = teilnehmerAsString.Split(",");
            Teilnehmer teilnehmer = new Teilnehmer();
            teilnehmer.Name = teilnehmerAttributes[0].Trim();
            if (kursListe != null)
            {
                int count = kursListe.Count;
                for (int i = 0; i < count; i++)
                {
                    if (teilnehmerAttributes[1] == kursListe[i].Name)
                    {
                        teilnehmer.Kurs = kursListe[i];
                        kursListe[i].TeilnehmerList.Add(teilnehmer);
                    }
                }
            }
            return teilnehmer;
        }

    }
}
