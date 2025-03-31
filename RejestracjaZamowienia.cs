using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjketC.Zamowienie;
using ProjketC;

namespace PizzeriaGUI
{
    public partial class RejestracjaZamowienia : Form
    {
        BazaKlientow baza;
        ZarzadzaniePracownikami prac;
        HistoriaZamowien historia;

        public RejestracjaZamowienia(BazaKlientow baza, ZarzadzaniePracownikami prac, HistoriaZamowien historia)
        {
            InitializeComponent();
            this.baza = baza;
            this.prac = prac;
            this.historia = historia;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nrtel = textBox1.Text;
            int idprac = Convert.ToInt32(textBox2.Text);
            string status = comboBox1.SelectedItem.ToString();
            Enum.TryParse(status, out EnumStatusZamowienia statusEnum);
            bool czyZaplacone = checkBox1.Checked;
            string rozmiar = comboBox2.SelectedItem.ToString();
            Enum.TryParse(rozmiar, out Pizza.EnumRozmiar rozmiarEnum);
            string dodatek = comboBox3.SelectedItem?.ToString();
            if (Enum.TryParse<TypSkladnika>(dodatek, out TypSkladnika result))
            {
                MessageBox.Show("Valid TypSkladnika");
            }
            else
            {
                MessageBox.Show("Invalid value for TypSkladnika.");
            }

            int ilosc = Convert.ToInt32(textBox3.Text);

            Pizza p = new Pizza(rozmiarEnum, ilosc);
            p.DodajSkladnik(dodatek);


            Zamowienie z = new Zamowienie(baza, nrtel, prac, idprac, czyZaplacone, statusEnum);
            z.DodajPizze(p);
            historia.DodajZamowienie(z);
            historia.ZapiszXml("historiaZamowien.xml");
            MessageBox.Show("Zamowienie zostało złożone!");
            this.Close();

        }

    }
}
