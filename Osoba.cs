using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ProjketC
{
        public abstract class Osoba
        {
            string imie;
            string nazwisko;
            DateTime dataUr;
            string pesel;

            public string Imie { get => imie; set => imie = value; }
            public string Nazwisko { get => nazwisko; set => nazwisko = value; }
            public DateTime DataUr { get => dataUr; set => dataUr = value; }
            public string Pesel
            {
                get => pesel; set
                {
                    if (!Regex.IsMatch(value, @"^\d{11}"))
                    {
                        throw new ArgumentException("Nieprawidłowe wyrażenie!");
                    }
                    pesel = value;
                }
            }
            public Osoba()
            {
                Imie = String.Empty;
                Nazwisko = String.Empty;

                DataUr = DateTime.MinValue;
            }
            public Osoba(string imie, string nazwisko, string dataUr) : this()
            {
                Imie = imie;
                Nazwisko = nazwisko;
                if (!DateTime.TryParseExact(dataUr, new[] { "dd/MM/yyyy", "dd/MM/yy", "yyyy/MM/dd" }, null, DateTimeStyles.None, out DateTime d))
                {
                    throw new ArgumentException("Nieprawidłowy format daty!");
                }


                DataUr = d;


            }
            public Osoba(string imie, string nazwisko, string dataUr, string pesel) : this(imie, nazwisko, dataUr)
            {
                Pesel = pesel;
            }
            public override string ToString()
            {
                return $"{Imie} {Nazwisko} Data urodzenia: {DataUr:dd/MM/yyyy}";
            }
        }
}
