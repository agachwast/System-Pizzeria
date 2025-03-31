using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjketC;


namespace PizzeriaGUI
{
    public partial class Menu : Form
    {


        private BazaKlientow baza;
        private ZarzadzaniePracownikami bazaPracownikow;
        private HistoriaZamowien historia;
        public Menu()
        {

            InitializeComponent();

            baza = BazaKlientow.OdczytXml("BazaKlientow.xml");

            bazaPracownikow = ZarzadzaniePracownikami.OdczytXml("bazaPracownikow.xml");

            historia = HistoriaZamowien.OdczytXml("historiaZamowien.xml");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ListaKlientow Listaklientow = new ListaKlientow(baza.Klienci, baza);
            Listaklientow.WyswietlKlientow();
            Listaklientow.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RejestracjaZamowienia rejestracja = new RejestracjaZamowienia(baza, bazaPracownikow, historia);
            rejestracja.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Pracownicy pracownicy = new Pracownicy(bazaPracownikow.pracownicy, bazaPracownikow);
            pracownicy.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZobaczZamowienia hs = new ZobaczZamowienia(historia);
            hs.Show();
        }

    }
}
