using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjketC;


namespace PizzeriaGUI
{
    public partial class ListaKlientow : Form
    {
        private List<Klient> klienci;
        private BazaKlientow baza;


        public ListaKlientow(List<Klient> klienci, BazaKlientow baza)
        {
            InitializeComponent();
            this.klienci = klienci;
            this.baza = baza;
        }


        public void WyswietlKlientow()
        {

            ListBoxZwykliKlienci.Items.Clear();
            ListBoxLoyalKlienci.Items.Clear();


            var loyaltyKlienci = klienci.Where(k => k.LoyaltyClient).ToList();
            foreach (var klient in loyaltyKlienci)
            {

                string adres = $"{klient.Miasto}, {klient.Ulica} {klient.Numer}";
                ListBoxLoyalKlienci.Items.Add($"{klient.Imie} {klient.Nazwisko} - Nr Tel: {klient.NrTel}, Adres: {klient.Miasto}, {klient.Ulica} {klient.Numer}");
            }


            var zwykliKlienci = klienci.Where(k => !k.LoyaltyClient).ToList();
            foreach (var klient in zwykliKlienci)
            {
                ListBoxZwykliKlienci.Items.Add($"{klient.Imie} {klient.Nazwisko} - Nr Tel: {klient.NrTel}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajLoyalKlienta form = new DodajLoyalKlienta(baza, this);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajNormalKlienta form = new DodajNormalKlienta(baza, this);
            form.ShowDialog();
        }

    }
}
