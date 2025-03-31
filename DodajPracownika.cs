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
    public partial class DodajPracownika : Form
    {
        private ZarzadzaniePracownikami prac;
        Pracownicy parentForm;
        public DodajPracownika(Pracownicy parentForm, ZarzadzaniePracownikami prac)
        {
            InitializeComponent();
            this.prac = prac;
            this.parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imie = textBox1.Text;
            string nazwisko = textBox2.Text;
            string dataUr = textBox3.Text;
            string pesel = textBox4.Text;
            string dataRozp = textBox5.Text;
            int stawka = Convert.ToInt32(textBox6.Text);
            EnumStanowisko stanowisko = (EnumStanowisko)Enum.Parse(typeof(EnumStanowisko), comboBox1.SelectedItem.ToString());
            prac.DodajPracownika(imie, nazwisko, dataUr, pesel, dataRozp, stawka, stanowisko);
            prac.ZapiszXml("bazaPracownikow.xml");
            MessageBox.Show("Pracownik został dodany!");

            parentForm.WypiszPracownikow();
            this.Close();

        }

    }
}
