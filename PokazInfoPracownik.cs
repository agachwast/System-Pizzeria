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
    public partial class PokazInfoPracownik : Form
    {
        private ZarzadzaniePracownikami prac;
        Pracownicy parentForm;
        public PokazInfoPracownik(Pracownicy parentForm, ZarzadzaniePracownikami prac)
        {
            InitializeComponent();
            this.prac = prac;
            this.parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;

            if (int.TryParse(data, out int id))
            {
                var result = prac.PokazInfoPracownika(id: id);
                MessageBox.Show(result);
                this.Close();
            }

            else if (!string.IsNullOrEmpty(data))
            {
                var result = prac.PokazInfoPracownika(nazwisko: data);
                MessageBox.Show(result);
                this.Close();
            }
            else
            {

                MessageBox.Show("Niepoprawne ID/nazwisko!");
            }

        }

    }
}
