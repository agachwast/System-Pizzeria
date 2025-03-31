using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjketC
{
    public class Pizza
    {
        public enum EnumRozmiar { mala = 30, srednia = 35, duza = 40}
        
        public EnumRozmiar Rozmiar { get; set; }
        public List<Skladnik> SkladnikiPizzy { get; set; } = new List<Skladnik>(); 
        public int Ilosc { get; set; }

        public Pizza() { }

        
        public Pizza(EnumRozmiar rozmiar, int ilosc)
        {
            
            Rozmiar=rozmiar;
            Ilosc=ilosc;
        }


        public bool CzySkladnikJestDostepny(string nazwaSkladnika)
        {
            
            var dostepneSkladniki = new List<string> { "pieczarka", "papryka", "salami", "kurczak", "burrata" };

            return dostepneSkladniki.Contains(nazwaSkladnika.ToLower());
        }

        public void DodajSkladnik(string nazwaSkladnika)
        {
            
            if (CzySkladnikJestDostepny(nazwaSkladnika))
            {
                
                var skladnik = new Skladnik((TypSkladnika)Enum.Parse(typeof(TypSkladnika), nazwaSkladnika, true));

                
                SkladnikiPizzy.Add(skladnik);
           
            }
            else
            {
                Console.WriteLine($"Niestety składnik {nazwaSkladnika} nie jest dostępny.");
            }
        }


        public void UsunSkladnik(string nazwaSkladnika)
        {
            
            var skladnik = SkladnikiPizzy.FirstOrDefault(s => s.NazwaSkladnika.ToString().ToLower() == nazwaSkladnika.ToLower());

            if (skladnik != null)
            {
                
                SkladnikiPizzy.Remove(skladnik);
               
            }
            else
            {
                Console.WriteLine($"Składnik {nazwaSkladnika} nie występuje w pizzy");
            }
        }


        public void ListSkladnikow()
        {
            //Console.WriteLine($"Pizza: {PizzaName} - Ingredients:");
            foreach (var skladnik in SkladnikiPizzy)
            {
                Console.WriteLine($"{skladnik}, ");
            }
        }

        
        public decimal CenaCalkowita()
        {
            decimal totalCena = (decimal)Rozmiar;
            foreach (var skladnik in SkladnikiPizzy)
            {
                totalCena += skladnik.CenaSkladnika;
            }

            return totalCena * Ilosc;
        }

        public override string ToString()
        {
            string listaSkladnikow = string.Join(", ", SkladnikiPizzy);
            return $"Rozmiar: {Rozmiar}, Skladniki: {listaSkladnikow}, Ilosc: {Ilosc}, Cena calkowita: {CenaCalkowita():C}";
        }


    }

    
}
