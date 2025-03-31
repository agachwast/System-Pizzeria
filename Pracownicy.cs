using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjketC;


namespace PizzeriaGUI
{
    public partial class Pracownicy : Form
    {
        private ZarzadzaniePracownikami prac;
        List<(int IdPracownika, Pracownik Pracownik)> pracownicy;
        public Pracownicy(List<(int IdPracownika, Pracownik Pracownik)> pracownicy, ZarzadzaniePracownikami prac)
        {
            InitializeComponent();
            this.prac = prac;
            this.pracownicy = pracownicy;

            WypiszPracownikow();
        }

        public void WypiszPracownikow()
        {
            listBoxPracownicy.Items.Clear();
            foreach (var p in pracownicy)
            {
                listBoxPracownicy.Items.Add($"({p.IdPracownika}) {p.Pracownik.Imie} {p.Pracownik.Nazwisko}");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajPracownika form = new DodajPracownika(this, prac);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsunPracownika form = new UsunPracownika(this, prac);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PokazInfoPracownik form = new PokazInfoPracownik(this, prac);
            form.ShowDialog();
        }

    }
}
