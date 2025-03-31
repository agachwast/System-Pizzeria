using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjketC
{
    public enum EnumStanowisko { kelner, kucharz_junior, kucharz_senior, menadżer, sprzątaczka, }
    public class Pracownik : Osoba, IComparable<Pracownik>, ICloneable
    {

        EnumStanowisko stanowisko;
        decimal stawka;
        
        DateTime dataRozp;
        DateTime dataZak;
        public int IdPracownika { get;  set; }


        public EnumStanowisko Stanowisko { get => stanowisko; set => stanowisko = value; }
        public decimal Stawka
        {
            get => stawka; set
            {
                if (value < 0) { throw new ArgumentException("Stawka nie może być ujemna!"); }

                stawka = value;
            }
        }
        public DateTime DataRozp { get => dataRozp; set => dataRozp = value; }
        public DateTime DataZak { get => dataZak; set => dataZak = value; }

        public Pracownik() { }

        public Pracownik(string imie, string nazwisko, string dataUr, string pesel, string dataRozp, decimal stawka, EnumStanowisko stanowisko)
            : base(imie, nazwisko, dataUr, pesel)
        {
            if (!DateTime.TryParseExact(dataRozp, new[] { "dd/MM/yyyy", "dd/MM/yy", "yyyy/MM/dd" }, null, DateTimeStyles.None, out DateTime d))
            {
                throw new ArgumentException("Nieprawidłowy format daty!");
            }
            DataRozp = d;
            Stawka = stawka;
            Stanowisko = stanowisko;
            
        }
        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                   $"ID Pracownika: {IdPracownika}\n" +
                   $"Stanowisko: {Stanowisko}\n" +
                   $"Stawka: {Stawka:C2}\n" +
                   $"Data rozpoczęcia pracy: {DataRozp:dd/MM/yyyy}\n" +
                   $"Data zakończenia pracy: {(DataZak == DateTime.MinValue ? "Brak" : DataZak.ToString("dd/MM/yyyy"))}\n";
        }

        public int CompareTo(Pracownik? other)
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
