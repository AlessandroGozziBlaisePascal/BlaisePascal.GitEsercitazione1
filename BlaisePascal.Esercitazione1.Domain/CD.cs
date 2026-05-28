using System.Text;

namespace BlaisePascal.Esercitazione1.Domain
{
    public class CD
    {
        public List<Brano> Brani { get; private set; }
        
        private string Titolo { get;  set; }
        private string Autore { get;  set; }
        public int DurataCd { get; private set; }
        public CD(string titolo, string autore) 
        { 
            Brani = new List<Brano>();
            Titolo = titolo;
            Autore = autore;
        }


        public string GetTitolo() 
        {
            return Titolo;
        }

        public string GetAutore()
        {
            return Autore;
        }

        public void SetTitolo(string titolo) 
        {
            Titolo = titolo;
        }

        public void SetAutore(string autore) 
        {
            Autore = autore;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            
            foreach (var brano in Brani)
            {
                sb.Append($"{brano.Title} \n");
            }
            return sb.ToString();
        }

        public int Durata() 
        {
            foreach(Brano b in Brani) 
            {
                DurataCd += b.DurationInSec;
            }
            return DurataCd;
        }
    }
}


