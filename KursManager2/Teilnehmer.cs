using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursManager2
{
    internal class Teilnehmer
    {
        public string? name;
        public int? alter;
        public Kurs kurs;
        
        public Teilnehmer() { }

        public Teilnehmer(string? _name, int? _alter, Kurs _kurs) { 
            name = _name; 
            alter = _alter;
            kurs = _kurs;
        }

        public override string ToString()
        {
            return "Teilnehmername: " + name + " Alter: " + alter + "\n";
        }

        //gib Teilnehmer Komma-separiert zurück, z.B.: Tobias, 23, C#2
        public string TeilnehmerKommasepariert()
        {
            return name + ", " + alter + ", " + kurs.name;
        }

    }
}
