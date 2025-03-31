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
    public partial class ZobaczZamowienia : Form
    {
        HistoriaZamowien historia;
        public ZobaczZamowienia(HistoriaZamowien historia)
        {
            InitializeComponent();
            this.historia = historia;
            Wyswietl();
        }

        public void Wyswietl()
        {
            listBoxZam.Items.Clear();
            string zamowieniaStr = historia.ToString();

            foreach (var line in zamowieniaStr.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                listBoxZam.Items.Add(line);
            }
        }

    }
}
