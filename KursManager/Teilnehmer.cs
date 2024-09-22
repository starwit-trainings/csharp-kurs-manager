namespace KursManager
{
    internal class Teilnehmer
    {
        private string? name;
        private Kurs? kurs;

        public string? Name { get; set; }
        public Kurs? Kurs { get; set; }

        public override string ToString()
        {
            return Name + ", "
                + (Kurs != null ? Kurs.Name : string.Empty);
            ;
        }
    }
}
