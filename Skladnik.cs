using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjketC
{

    public enum TypSkladnika
    {
        pieczarka = 2,  
        papryka = 3,    
        salami = 2,    
        oliwki = 3,    
        kurczak = 2,   
        burrata = 3    
    }

    [Serializable]
   
    public class Skladnik : IEquatable<Skladnik>
    {
        public TypSkladnika NazwaSkladnika { get; set; }

       
        public decimal CenaSkladnika => JakaCenaSkladnika(NazwaSkladnika);

        public Skladnik() { }
        public Skladnik(TypSkladnika nazwaSkladnika)
        {
            NazwaSkladnika = nazwaSkladnika;
        }

        
        public virtual decimal JakaCenaSkladnika(TypSkladnika skladnik)
        {
            
            return (decimal)skladnik;
        }

        public override string ToString()
        {
            return $"{NazwaSkladnika} ({CenaSkladnika:C})";
        }

       
        public bool Equals(Skladnik other)
        {
            if (other == null)
                return false;

            return this.NazwaSkladnika == other.NazwaSkladnika &&
                   this.CenaSkladnika == other.CenaSkladnika;
        }

        public override bool Equals(object obj)
        {
            if (obj is Skladnik skladnik)
                return Equals(skladnik);

            return false;
        }

        public override int GetHashCode()
        {
            int hashNazwa = NazwaSkladnika.GetHashCode();
            int hashCena = CenaSkladnika.GetHashCode();

            return hashNazwa ^ hashCena;
        }
    }
}
