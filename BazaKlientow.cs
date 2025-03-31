using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ProjketC
{
    interface IZapisywalna
    {
        void ZapiszXml(string nazwaPliku);
    }
    public class BazaKlientow : ICloneable
    {
        [XmlIgnore]
        public List<Klient> klienci;

        public List<Klient> Klienci { get => klienci; set => klienci = value; }

        public BazaKlientow()
        {
            Klienci = new List<Klient>();
        }
        public void DodajLoyalKlienta(string imie, string nazwisko, string dataUr, string miasto, string ulica, int numer, string email,
            string nrtel)
        {
            if (klienci.Any(k => k.NrTel == nrtel))
            {
                throw new KlientIstniejeException("Klient o podanym numerze telefonu już istnieje.");
            }
            Klient klient = new Klient(imie, nazwisko, dataUr, miasto, ulica, numer, email, nrtel);
            Klienci.Add(klient);
        }
        public void DodajBasicKlienta(string imie, string nazwisko, string nr)
        {

            if (Klienci.Any(k => k.NrTel == nr))
            {
                throw new KlientIstniejeException($"Klient z numerem telefonu {nr} już istnieje w bazie.");
            }


            Klient klient = new Klient(imie, nazwisko, nr);
            Klienci.Add(klient);
        }

        public string ZnajdzKlienta(string nrTel)
        {
            var klient = Klienci.Find(k => k.NrTel == nrTel);

            if (klient == null)
            {
                return "Brak klienta o takim nr tel.";
            }

            return klient.ToString();
        }

        public Klient ZnajdzKlientaZamowienie(string numerTelefonu)
        {

            return Klienci.FirstOrDefault(k => k.NrTel == numerTelefonu);
        }
        public void UsunKlientaZBazy(string nrTel)
        {
            var klient = Klienci.Find(p => p.NrTel == nrTel);
            if (klient != null)
            {
                Klienci.Remove(klient);
            }
        }
        public string DezaktywujKlienta(string nrTel)
        {
            var klient = Klienci.Find(p => p.NrTel == nrTel && p.LoyaltyClient == true);

            if (klient != null)
            {
                klient.LoyaltyClient = false;
                return "Dezaktywowano klienta.";
            }
            else
            {
                return "Brak aktywnego klienta o podanym numerze telefonu.";
            }
        }

        public string WyswietlWszystkichKlientow()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var klient in Klienci)
            {
                sb.AppendLine($"{klient.Imie} {klient.Nazwisko}, Nr Tel: {klient.NrTel}");
            }

            return sb.Length > 0 ? sb.ToString() : "Brak klientów w bazie.";
        }

        public object Clone()
        {
            BazaKlientow bazaClone = new BazaKlientow();
            foreach (var klient in Klienci)
            {
                bazaClone.klienci.Add((Klient)klient.Clone());
            }
            return bazaClone;
        }


        public void ZapiszXml(string nazwaPliku)
        {
            using StreamWriter sw = new(nazwaPliku);
            XmlSerializer xs = new(typeof(BazaKlientow));
            xs.Serialize(sw, this);
        }

        public static BazaKlientow? OdczytXml(string nazwaPliku)
        {
            using StreamReader sr = new(nazwaPliku);
            XmlSerializer xs = new(typeof(BazaKlientow));
            return xs.Deserialize(sr) as BazaKlientow;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var k in Klienci)
            {
                sb.Append(k.ToString());
            }
            return sb.ToString();
        }
    }
}