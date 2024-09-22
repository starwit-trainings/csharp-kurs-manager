namespace KursManager
{
    internal class Kurs
    {
        private string? name;
        private string? trainer;
        private DateOnly[]? dates;
        private List<Teilnehmer>? teilnehmerList;

        public string? Name { get; set; }
        public string? Trainer { get; set; }
        public DateOnly[]? Dates { get; set; }
        public List<Teilnehmer> TeilnehmerList {
            get {
                if (teilnehmerList == null)
                {
                    teilnehmerList = new List<Teilnehmer>();
                }
                return teilnehmerList;
            } 
            set { teilnehmerList = value; }
            }

        public override string ToString()
        {
            string dateString = "Dates: " + "\n\t    ";
            if (Dates != null) {
                for (int i = 0; i < Dates.Length; i++)
                {
                    dateString = dateString + Dates[i].ToString("dd.M.yyyy") + "\n\t";
                    if (i < Dates.Length - 1)
                    {
                        dateString = dateString + "    ";
                    }
                } 
            }
            string teilnehmerString = "Teilnehmer: " + "\n\t    ";
            if (teilnehmerList != null)
            {
                int count = teilnehmerList.Count;
                for (int i = 0; i < count; i++)
                {
                    teilnehmerString = teilnehmerString + teilnehmerList[i].ToString() + "\n\t    ";
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
