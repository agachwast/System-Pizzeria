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
    public partial class UsunPracownika : Form
    {

        private ZarzadzaniePracownikami prac;
        Pracownicy parentForm;
        public UsunPracownika(Pracownicy parentForm, ZarzadzaniePracownikami prac)
        {
            InitializeComponent();
            this.prac = prac;
            this.parentForm = parentForm; ;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (int.TryParse(textBox1.Text, out int id))
            {
                prac.ZwolnijPracownika(id);

                prac.ZapiszXml("bazaPracownikow.xml");
                MessageBox.Show("Pracownik został usunięty!");

                parentForm.WypiszPracownikow();
                this.Close();
            }
            else
            {
                MessageBox.Show("Niepoprawne ID!");
            }



        }

    }
}
