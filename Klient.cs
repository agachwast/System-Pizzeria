using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjketC
{
    public class Klient: Osoba, IComparable<Klient>, ICloneable
    {
        bool loyaltyClient;
        string miasto;
        string ulica;
        int numer;
        string email;
        string nrTel;

        public bool LoyaltyClient { get => loyaltyClient; set => loyaltyClient = value; }
        public string Miasto { get => miasto; set => miasto = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public int Numer { get => numer; set => numer = value; }
        public string Email { get => email; set => email = value; }
        public string NrTel { get => nrTel; set => nrTel = value; }

        
        public Klient() { }
          
        public Klient(string imie, string nazwisko, string nrtel)
        
        {
            Imie = imie;
            Nazwisko = nazwisko;
            LoyaltyClient = false;
            Email = "Brak";
            NrTel = nrtel;
        }
        public Klient(string imie, string nazwisko, string dataUr, string miasto, string ulica, int numer, string email,
            string nrtel) :base(imie,  nazwisko, dataUr)
        {
            Miasto = miasto;
            Ulica = ulica;
            Numer = numer;
            Email = email;
            NrTel = nrtel;
            LoyaltyClient= true;
            
        }

        
        public override string ToString()
        {
            return base.ToString();
        }

        public int CompareTo(Klient? other)
        {

            if (other == null)
                return 1;

            int nazwiskoComparison = Nazwisko.CompareTo(other.Nazwisko);
            if (nazwiskoComparison != 0)
                return nazwiskoComparison;

            return Imie.CompareTo(other.Imie);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
