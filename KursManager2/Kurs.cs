using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace KursManager2
{
    internal class Kurs
    {
        public string? name;
        public string? trainername;
        public DateOnly[] tage;
        public List<Teilnehmer> teilnehmerListe = new List<Teilnehmer>();


        public Kurs() { }

        public Kurs(string? _name, string? _trainername, string datumstring)
        {
            name = _name;
            trainername = _trainername;
            string[] tagStringArray = datumstring.Trim().Split(" ");
            int size = tagStringArray.Length;
            tage = new DateOnly[size];
            for (int i = 0; i < size; i++) {
                DateOnly.TryParseExact(tagStringArray[i].Trim(), "d.M.yyyy", out tage[i]);
            }
        }

        public override string ToString()
        {
            string teilnehmerListeAlsString = "Teilnehmer: \n";
            foreach (Teilnehmer teilnehmer in teilnehmerListe)
            {
                teilnehmerListeAlsString = teilnehmerListeAlsString + " " + teilnehmer;
            }
            return "Kursname: " + name + ", Trainer: " + trainername + "\n" + teilnehmerListeAlsString;
        }

        public string KursKommasepariert()
        {
            string dateString = "";
            foreach (var item in tage)
            {
                dateString = dateString + " " + item.ToString("d.M.yyyy");
            }
            return name + ", " + trainername + "," + dateString;
        }
    }
}
