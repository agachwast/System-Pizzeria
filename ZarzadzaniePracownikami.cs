using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace ProjketC
{
    public class ZarzadzaniePracownikami : ICloneable
    {
        public List<(int IdPracownika, Pracownik Pracownik)> pracownicy;
        static int idCounter = 11;  // Pierwsze ID zaczyna się od 1

        public ZarzadzaniePracownikami()
        {
            pracownicy = new List<(int, Pracownik)>();
        }

        public void DodajPracownika(string imie, string nazwisko, string dataUr, string pesel, string dataRozp,
            decimal stawka, EnumStanowisko stanowisko)
        {
            Pracownik nowyPracownik = new Pracownik(imie, nazwisko, dataUr, pesel, dataRozp, stawka, stanowisko);
            nowyPracownik.IdPracownika = idCounter++;
            pracownicy.Add((nowyPracownik.IdPracownika, nowyPracownik));
        }

        public string PokazInfoPracownika(string? nazwisko = null, int? id = null)
        {
            if (nazwisko == null && id == null)
            {
                throw new NieZnalezionoPracownikaException("Nie znaleziono takiego pracownika");
            }

            var wyniki = pracownicy
                .Where(p => (nazwisko != null && p.Pracownik.Nazwisko == nazwisko) || (id != null && p.IdPracownika == id))
                .ToList();

            if (wyniki.Count == 0)
            {
                throw new NieZnalezionoPracownikaException("Nie znaleziono takiego pracownika");
            }

            StringBuilder sb = new StringBuilder();
            foreach (var p in wyniki)
            {
                sb.AppendLine(p.Pracownik.ToString());
            }
            return sb.ToString();
        }

        public Pracownik ZnajdzPracownikaZamowienie(int id)
        {
            return pracownicy
                .FirstOrDefault(p => p.IdPracownika == id).Pracownik;
        }

        public void ZwolnijPracownika(int id)
        {
            var pracownik = pracownicy.FirstOrDefault(p => p.IdPracownika == id);
            if (pracownik.Equals(default((int, Pracownik))))
            {
                throw new NieZnalezionoPracownikaException("Nie znaleziono takiego pracownika");
            }
            else
            {
                pracownicy.Remove(pracownik);
                pracownik.Pracownik.DataZak = DateTime.Now;
                Console.WriteLine($"Pracownik o ID {id} został zwolniony. Data zakończenia pracy: {pracownik.Pracownik.DataZak:dd/MM/yyyy}");
            }
        }

        public object WypiszAktywnychPracownikow()
        {
            var aktywniPracownicy = pracownicy
                .Where(p => p.Pracownik.DataZak == DateTime.MinValue) // Filtruje tylko aktywnych pracowników
                .ToList();

            if (aktywniPracownicy.Count == 0)
            {
                return "Brak aktywnych pracowników.";
            }

            StringBuilder sb = new StringBuilder("Aktywni pracownicy:\n");
            foreach (var pracownik in aktywniPracownicy)
            {
                sb.AppendLine($"{pracownik.Pracownik.Imie} {pracownik.Pracownik.Nazwisko}, Stanowisko: {pracownik.Pracownik.Stanowisko}");
            }

            return sb;
        }

        public object Clone()
        {
            ZarzadzaniePracownikami zpClone = new ZarzadzaniePracownikami();
            foreach (var pair in pracownicy)
            {
                zpClone.pracownicy.Add((pair.IdPracownika, (Pracownik)pair.Pracownik.Clone()));
            }
            return zpClone;
        }

        public void ZapiszXml(string nazwaPliku)
        {
            using StreamWriter sw = new StreamWriter(nazwaPliku);
            XmlSerializer xs = new(typeof(ZarzadzaniePracownikami));
            xs.Serialize(sw, this);
        }

        public static ZarzadzaniePracownikami? OdczytXml(string nazwaPliku)
        {
            using StreamReader sr = new(nazwaPliku);
            XmlSerializer xs = new(typeof(ZarzadzaniePracownikami));
            return xs.Deserialize(sr) as ZarzadzaniePracownikami;
        }
    }
}
