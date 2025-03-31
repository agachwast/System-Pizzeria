using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProjketC;

namespace PizzeriaGUI
{
    public partial class DodajNormalKlienta : Form
    {
        private BazaKlientow baza;
        private ListaKlientow listaKlientowForm;

        public DodajNormalKlienta(BazaKlientow baza, ListaKlientow listaKlientowForm)
        {
            InitializeComponent();
            this.baza = baza;
            this.listaKlientowForm = listaKlientowForm;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string imie = textBox1.Text;
            string nazwisko = textBox2.Text;

            string nrTel = textBox3.Text;


            baza.DodajBasicKlienta(imie, nazwisko, nrTel);

            baza.ZapiszXml("BazaKlientow.xml");

            MessageBox.Show("Klient został dodany!");

            listaKlientowForm.WyswietlKlientow();
            this.Close();
        }

    }
}
