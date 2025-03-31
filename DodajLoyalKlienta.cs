using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjketC;


namespace PizzeriaGUI
{
    public partial class DodajLoyalKlienta : Form
    {
        private BazaKlientow baza;
        private ListaKlientow listaKlientowForm;

        public DodajLoyalKlienta(BazaKlientow baza, ListaKlientow listaKlientowForm)
        {
            InitializeComponent();
            this.baza = baza;
            this.listaKlientowForm = listaKlientowForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string imie = textBox1.Text;
            string nazwisko = textBox2.Text;
            string dataUrodzenia = textBox3.Text;
            string miasto = textBox4.Text;
            string ulica = textBox5.Text;
            int numer = Convert.ToInt32(textBox6.Text);
            string email = textBox7.Text;
            string nrTel = textBox8.Text;


            baza.DodajLoyalKlienta(imie, nazwisko, dataUrodzenia, miasto, ulica, numer, email, nrTel);
            baza.ZapiszXml("BazaKlientow.xml");

            MessageBox.Show("Klient został dodany!");

            listaKlientowForm.WyswietlKlientow();
            this.Close();
        }

    }
}
