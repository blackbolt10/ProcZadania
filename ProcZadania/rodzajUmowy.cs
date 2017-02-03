using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcZadania
{
    public partial class rodzajUmowy : Form
    {
        public DataTable pomDT;
        public String[] wynik;
        public String projekt;
        public String zadanie;


        public rodzajUmowy(DataTable _pomDT, String[] _wynik, String _projekt, String _zadanie)
        {
            pomDT = _pomDT;
            wynik = _wynik;
            projekt = _projekt;
            zadanie = _zadanie;

            InitializeComponent();
            wczytajListe();
        }

        private void wczytajListe()
        {
            for (int i = 0; i < pomDT.Rows.Count; i++)
            {
                listaUmowListBox.Items.Add(pomDT.Rows[i][0].ToString() + " - " + projekt +" - "+ zadanie+ " - " + pomDT.Rows[i][6].ToString());
            }

            if (listaUmowListBox.Items.Count != -1)
                listaUmowListBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            wynik[0] = pomDT.Rows[listaUmowListBox.SelectedIndex][0].ToString();
            wynik[1] = pomDT.Rows[listaUmowListBox.SelectedIndex][1].ToString();
            wynik[2] = pomDT.Rows[listaUmowListBox.SelectedIndex][2].ToString();
            wynik[3] = pomDT.Rows[listaUmowListBox.SelectedIndex][3].ToString();
            wynik[4] = pomDT.Rows[listaUmowListBox.SelectedIndex][4].ToString();
            wynik[5] = pomDT.Rows[listaUmowListBox.SelectedIndex][5].ToString();
            this.Close();
        }

        private void listaUmowListBox_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }
    }
}
