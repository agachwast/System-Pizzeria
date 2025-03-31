using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ProjketC
{
    
    public class HistoriaZamowien
    {
        public List<Zamowienie> zamowienia;


        public HistoriaZamowien() 
        {
            zamowienia = new List<Zamowienie>();
        }

        
        public void DodajZamowienie(Zamowienie zamowienie)
        {
            zamowienia.Add(zamowienie);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Historia zamówień:");

            foreach (var zamowienie in zamowienia)
            {
                if (zamowienie.CzyAnulowane)
                {
                    sb.AppendLine($"Zamówienie zostało anulowane.");
                }
                sb.AppendLine($"Zamówienie ID: {zamowienie.IDZamowienia}");
                sb.AppendLine($"Klient: {zamowienie.Klient.Imie}");
                sb.AppendLine($"Data zamówienia: {zamowienie.DataZamowienia}");

                
                foreach (var pizza in zamowienie.Pizze)
                {
                    sb.AppendLine($" - Rozmiar pizzy: {pizza.Rozmiar}");
                    sb.AppendLine($"   Składniki: {string.Join(", ", pizza.SkladnikiPizzy.Select(i => i.NazwaSkladnika))}");
                    sb.AppendLine($"   Cena: {pizza.CenaCalkowita():C}");
                }

                
                if (!zamowienie.CzyAnulowane)
                {
                    sb.AppendLine($"Całkowita cena zamówienia: {zamowienie.Pizze.Sum(p => p.CenaCalkowita()):C}");
                }
                else
                {
                    sb.AppendLine($"Całkowita cena zamówienia: 0,00 zł");
                }

                sb.AppendLine("------------------------------------------------------");
            }

            return sb.ToString();
        }

        public void ZapiszXml(string nazwaPliku)
        {
            using StreamWriter sw = new StreamWriter(nazwaPliku);
            XmlSerializer xs = new(typeof(HistoriaZamowien));
            xs.Serialize(sw, this);
        }

        public static HistoriaZamowien? OdczytXml(string nazwaPliku)
        {
            using StreamReader sr = new(nazwaPliku);
            XmlSerializer xs = new(typeof(HistoriaZamowien));
            return xs.Deserialize(sr) as HistoriaZamowien;
        }
    }
}
