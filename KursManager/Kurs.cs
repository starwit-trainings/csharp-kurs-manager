namespace KursManager
{
    internal class Kurs
    {
        private string? name;
        private string? trainer;
        private DateOnly[]? dates;
        private List<Teilnehmer> teilnehmerList;

        public string? Name { get; set; }
        public string? Trainer { get; set; }
        public DateOnly[]? Dates { get; set; }
        public List<Teilnehmer> TeilnehmerList { get; set; }


        public Kurs()
        {
            TeilnehmerList = new List<Teilnehmer>();
        }

        public override string ToString()
        {
            string dateString = "Dates: " + "\n\t    ";
            if (Dates != null) {
                for (int i = 0; i < Dates.Length; i++)
                {
                    dateString = dateString + Dates[i].ToString("d.M.yyyy") + "\n\t";
                    if (i < Dates.Length - 1)
                    {
                        dateString = dateString + "    ";
                    }
                } 
            }
            string teilnehmerString = "Teilnehmer: " + "\n\t    ";
            if (TeilnehmerList != null)
            {
                int count = TeilnehmerList.Count;
                for (int i = 0; i < count; i++)
                {
                    teilnehmerString = teilnehmerString + TeilnehmerList[i].ToString() + "\n\t    ";
                }
            }
            return "Name: " + Name + "\n\t" 
                + "Trainer: " + Trainer + "\n\t"
                + dateString
                + teilnehmerString
                ;
        }
    }
}
