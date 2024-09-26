namespace KursManager2
{
    class Programm
    {
        
        static void Main(string[] args)
        {

            List<Teilnehmer> alleTeilnehmer = new List<Teilnehmer>();
            List<Kurs> alleKurse = new List<Kurs>();

            bool weitereKurse = true;
            while (weitereKurse)
            {
                Console.WriteLine("++++++ Bitte gebe den Kurs ein: ");
                Console.WriteLine("Kursname: ");
                string? kursname = Console.ReadLine();
                Console.WriteLine("Trainername: ");
                string? trainerdeskurses = Console.ReadLine();
                Console.WriteLine("Datum der Kurstage getrennt durch Leerzeichen ein (z.B. 1.1.2024 20.10.2024): ");
                string? datum = Console.ReadLine();

                //Hier wird ein Konstruktor ohne Parameter verwendet
                //und die Werte der Attribute werden anschließend gesetzt
                Kurs kurs1 = new Kurs(kursname, trainerdeskurses, datum);

                bool weitereTeilnehmer = true;
                while (weitereTeilnehmer)
                {
                    Console.WriteLine("++++++ Bitte gebe die Teilnehmer des Kurses ein: ");
                    Console.WriteLine("Bitte gebe den Namen des Teilnehmers ein: ");
                    string? name = Console.ReadLine();

                    Console.WriteLine("Bitte gebe das Alter des Teilnehmers ein: ");
                    int alter = Convert.ToInt32(Console.ReadLine());

                    //Hier ist ein Konstruktor definiert worden,
                    //der die Parameter name und alter entgegennimmt und direkt setzt
                    Teilnehmer teilnehmer1 = new Teilnehmer(name, alter, kurs1);

                    kurs1.teilnehmerListe.Add(teilnehmer1);
                    alleTeilnehmer.Add(teilnehmer1);

                    Console.WriteLine("Weitere Teilnehmer? (gebe j für ja ein) ");
                    string? eingabeWeitereTeilnehmer = Console.ReadLine();
                    weitereTeilnehmer = (eingabeWeitereTeilnehmer == "j");
                }
                alleKurse.Add(kurs1);
                Console.WriteLine("Weitere Kurse? (gebe j für ja ein) ");
                string? eingabeWeitereKurse = Console.ReadLine();
                weitereKurse = (eingabeWeitereKurse == "j");
            }

            //Kontrolle, ob die Daten im Kurs richtig gesetzt wurden
            //Console.WriteLine(kurs1);

            //Schreibe eine Methode die eine Liste der Teilnehmer wie folgt zurückgibt:
            //Name des Teilnehmers, Alter, Kursname
            //Max, 17, C#1
            //Tobias, 23, C#2
            SchreibeListeAllerKurse(alleKurse);
            SchreibeListeAllerTeilnehmer(alleTeilnehmer);
        }

        public static void SchreibeListeAllerTeilnehmer(List<Teilnehmer> alleTeilnehmer)
        {
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Teilnehmer.csv"));
            outputFile.WriteLine("Name des Teilnehmers, Alter, Kursname");
            foreach (Teilnehmer item in alleTeilnehmer)
            {
                outputFile.WriteLine(item.TeilnehmerKommasepariert());
            }
            outputFile.Close();
        }

        public static void SchreibeListeAllerKurse(List<Kurs> alleKurse)
        {
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Kurs.csv"));
            outputFile.WriteLine("Name des Kurses, Trainername, Veranstaltungstage");
            foreach (Kurs item in alleKurse)
            {
                outputFile.WriteLine(item.KursKommasepariert());
            }
            outputFile.Close();
        }
    }
}
