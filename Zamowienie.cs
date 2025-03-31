using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjketC
{
    public class Zamowienie
    {
        public enum EnumStatusZamowienia { Oczekujace, WTrakcieRealizacji, Zakonczone, Anulowane }
        static int licznikZamowien = 11;
        public string IDZamowienia { get; set; }
        public List<Pizza> Pizze { get; set; } = new List<Pizza>();
        public Klient Klient { get; set; } 
        public Pracownik Pracownik { get; set; } 
        public DateTime DataZamowienia { get; set; } 
        public bool CzyZaplacone { get; set; }
        public bool CzyAnulowane { get; set; } = false;
        public DateTime OczekiwanyCzasDostawy { get; set; }
        public EnumStatusZamowienia Status { get; set; }


        public Zamowienie() { }
        public Zamowienie(BazaKlientow bazaKlientow, string nrTelefonuKlienta, ZarzadzaniePracownikami pracownicy, int idPrac, bool czyZaplacone, EnumStatusZamowienia status)
        {
            
            licznikZamowien++; 
            IDZamowienia = $"ID {licznikZamowien:D4}";
            Klient = bazaKlientow.ZnajdzKlientaZamowienie(nrTelefonuKlienta);
            DataZamowienia = DateTime.Now;
            OczekiwanyCzasDostawy = DataZamowienia.AddMinutes(30);
            CzyZaplacone = czyZaplacone;
            Pracownik = pracownicy.ZnajdzPracownikaZamowienie(idPrac);
            Status = status;
            

        }
        public void DodajPizze(Pizza pizza)
        {
            Pizze.Add(pizza);
            //Console.WriteLine($"Pizza {pizza.NazwaPizzy} dodana do zamówienia.");
        }

        public void SzczegolyZamowienia()
        {
            if (CzyAnulowane)
            {
                Console.WriteLine($"Zamówienie {IDZamowienia} dla {Klient.Imie} zostało anulowane {DataZamowienia}.");
            }
            else
            {
                Console.WriteLine($"Zamówienie  {IDZamowienia} dla {Klient.Imie} złożone {DataZamowienia}:");
                foreach (var pizza in Pizze)
                {
                    Console.WriteLine(pizza.ToString());
                }
            }
        }

        public void AnulujZamowienie()
        {
            CzyAnulowane = true;
            Console.WriteLine($"Zamówienie {IDZamowienia} zostało anulowane.");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            
            sb.AppendLine($"ID zamówienia: {IDZamowienia}");
            sb.AppendLine($"Klient: {Klient.Imie}");
            sb.AppendLine($"Pracownik: {Pracownik.Imie}"); 
            sb.AppendLine($"Data zamówienia: {DataZamowienia}");

            sb.AppendLine($"Status zamówienia: {Status}");

            sb.AppendLine($"Status płatności: {(CzyZaplacone ? "Zapłacone" : "Nie zapłacone")}");

            sb.AppendLine($"Pizze w zamówieniu:");
            foreach (var pizza in Pizze)
            {
                sb.AppendLine($"    Rozmiar pizzy: {pizza.Rozmiar}");
                sb.AppendLine($"    Składniki: {string.Join(", ", pizza.SkladnikiPizzy.Select(i => i.NazwaSkladnika))}");
                sb.AppendLine($"    Cena całkowita: {pizza.CenaCalkowita():c}");
            }

            ; 
            sb.AppendLine($"Przewidywany czas dostawy: {OczekiwanyCzasDostawy:HH:mm}");

            return sb.ToString();
        }

    }
}
