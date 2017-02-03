using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
  
namespace ProcZadania
{
    public partial class procentyProgram : Form
    {
        private String nazwaBD = "", login = "", haslo = "", instancja = "";
        private bool debuger;
        private Boolean zapisano = true;

        private SqlConnection uchwytBD;
        private SqlCommand polecenieSQL;

        public procentyProgram(bool _debuger)
        {
            InitializeComponent();

            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Galsoft\\Daglas\\" + this.Name);

            this.SetDesktopLocation(Convert.ToInt16(key.GetValue("Location.X", Location.X.ToString())), Convert.ToInt16(key.GetValue("Location.Y", Location.Y.ToString())));
            this.Size = new Size(Convert.ToInt16(key.GetValue("Size.Width", Size.Width.ToString())), Convert.ToInt16(key.GetValue("Size.Height", Size.Height.ToString())));
            login = key.GetValue("login", login).ToString();
            haslo = key.GetValue("haslo", haslo).ToString();
            instancja = key.GetValue("instancja", instancja).ToString();
            nazwaBD = key.GetValue("nazwaBD", nazwaBD).ToString();

            key.Close();
            
            try
            {
               uchwytBD = new SqlConnection(@"user id=" + login + "; password=" + haslo + "; Data Source=" + instancja + "; Initial Catalog=" + nazwaBD + ";");

               // MessageBox.Show(@"user id=" + login + "; password=" + haslo + "; Data Source=" + instancja + "; Initial Catalog=" + nazwaBD + ";");
                uchwytBD.Open();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Błąd połączenia z bazą danych: " + exc.Message);
                this.Close();
            }

            this.Text = this.Text + " - Połączono z " + nazwaBD;
            debuger = _debuger;
            startProgramu();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            uchwytBD.Close();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Galsoft\\Daglas\\" + this.Name);

            if (WindowState != FormWindowState.Minimized)
            {
                key.SetValue("Location.X", Location.X.ToString());
                key.SetValue("Location.Y", Location.Y.ToString());

                // this.Size.Height .Width
                key.SetValue("Size.Width", Size.Width.ToString());
                key.SetValue("Size.Height", Size.Height.ToString());

                key.SetValue("login", login);
                key.SetValue("haslo", haslo);
                key.SetValue("instancja", instancja);
                key.SetValue("nazwaBD", nazwaBD);
            }
            key.Close();
        }

        public SqlDataAdapter zapytanie(string zapytanieString)
        {
            SqlDataAdapter wynik = new SqlDataAdapter();
            polecenieSQL = new SqlCommand(zapytanieString);
            polecenieSQL.Connection = uchwytBD;
            wynik = new SqlDataAdapter(polecenieSQL);
            
            return wynik;
        }

        public void zapiszDB(string zapytanieString)
        {
            //MessageBox.Show(zapytanieString);
            polecenieSQL = new SqlCommand(zapytanieString);
            polecenieSQL.Connection = uchwytBD;
            polecenieSQL.ExecuteNonQuery();
        }
        
        private void executeSQL(String zapytanie)
        {
            using (polecenieSQL = new SqlCommand(zapytanie, uchwytBD))
            {
                SqlDataReader reader = polecenieSQL.ExecuteReader();
                reader.Close();
            }
        }

        private void pomocTSMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Galsoft Robert Bożek \nul. Trembeckiego 11A\n35-234 Rzeszów \n\nE-mail: firma@galsoft.pl\nTel: (17) 742-11-97", "Informacje o programie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zamknijTSMI_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UnhandledThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            this.HandleUnhandledException(e.Exception);
        }

        public void HandleUnhandledException(Exception e)
        {
            raportBledu("Błąd aplikacji " + e.TargetSite + " {koniec target site} " + e.HelpLink + " {koniec helplink} " + e.Message + "{Koniec wiadomosci}");

            MessageBox.Show("Ups...\nWystąpił błąd aplikacji. \nRaport został przechwycony i przekazany obsłudze technicznej. Kontynuować?",
                "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            /*
                if (MessageBox.Show("Ups...\nWystąpił błąd systemu. \nRaport został przechwycony i przekazany obsłudze technicznej. Kontynuować?",
                    "Błąd", MessageBoxButtons.YesNo, MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    Application.Exit();
                }
            */
        }

        private void raportBledu(String blad)
        {
            String nazwaKompOper = Environment.MachineName + "\\" + Environment.UserName;
            DateTime dataKomp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            MessageBox.Show(blad);

            try
            {
                //zapiszDB("");
            }
            catch (Exception  exc)
            {
                String msg = exc.Message;                
                //MessageBox.Show("Z przykrością informuję o wyniknięciu błędu przy dodwaniu raportu o błędzie. Pierwszy błąd jest zbyt poważny :(","Błąd w wyniku błędu",MessageBoxButtons.OK, MessageBoxIcon.Question);
                // MessageBox.Show("Wystąpił błąd : " + exc.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


//-----------------------------------------------------------------------------------------------------------------------------------------------
        
        private void startProgramu()
        {
            przygotujKolumnyDGV();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.BeginEdit(true);
            //MessageBox.Show("lama\n" + dataGridView1.CurrentCell.RowIndex + "  |  " + dataGridView1.CurrentCell.ColumnIndex);
        }              

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                Form2 form2 = new Form2(this, uchwytBD);
                form2.ShowDialog();             
            }

            if (dataGridView1.Rows.Count > 0)
            {
                zapisano = false;
            }
        }

        private void przygotujKolumnyDGV()
        {
            dataGridView1.Columns.Add("akronim", "Akronim");
            dataGridView1.Columns.Add("projekt", "Projekt");
            dataGridView1.Columns.Add("zadania", "Zadania");
            dataGridView1.Columns.Add("procent", "Procent");
            dataGridView1.Columns.Add("Pri_kod", "Pri_kod");
            dataGridView1.Columns.Add("typZrodla", "typZrodla");
            dataGridView1.Columns.Add("ZrodloID", "ZrodloID");
            dataGridView1.Columns.Add("pri_praid", "pri_praid");
            dataGridView1.Columns.Add("PRI_DzlId", "PRI_DzlId");
            dataGridView1.Columns.Add("PrjID", "PrjID");
            dataGridView1.Columns.Add("blad", "blad");

            if (debuger)
            {
                dataGridView1.Columns["blad"].Visible = false;
                dataGridView1.Columns["PrjID"].Visible = false;
                dataGridView1.Columns["PRI_DzlId"].Visible = false;
                dataGridView1.Columns["pri_praid"].Visible = false;
                dataGridView1.Columns["ZrodloID"].Visible = false;
                dataGridView1.Columns["typZrodla"].Visible = false;
                dataGridView1.Columns["Pri_kod"].Visible = false;
            }
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            try
            {
                String zapytanie = "exec cdn.Galsoft_czyszczenie_tabeli_opiskadry";
                executeSQL(zapytanie);

                przeslijDane();

                zapytanie = "exec cdn.galsoft_uzupelnienie_do_stu";
                executeSQL(zapytanie);
                zapisano = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Wystąpił błąd podczas zapisu, proszę spróbować ponownie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void przeslijDane()
        {
            progressBar1.Maximum = dataGridView1.Rows.Count;
            int licznikWpisow = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[5].Value != null &&
                    dataGridView1.Rows[i].Cells["ZrodloID"].Value != null &&
                    dataGridView1.Rows[i].Cells["pri_praid"].Value != null &&
                    dataGridView1.Rows[i].Cells["PRI_DzlId"].Value != null &&
                    dataGridView1.Rows[i].Cells["PrjID"].Value != null &&
                    dataGridView1.Rows[i].Cells["blad"].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells["blad"].Value.ToString() != "1")
                    {
                        licznikWpisow++;
                        String rodzajZrodla = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        String zrodloId = dataGridView1.Rows[i].Cells["ZrodloID"].Value.ToString();
                        String praId = dataGridView1.Rows[i].Cells["pri_praid"].Value.ToString();
                        String dzlId = dataGridView1.Rows[i].Cells["PRI_DzlId"].Value.ToString();
                        String prjId = dataGridView1.Rows[i].Cells["PrjID"].Value.ToString();
                        String procent = dataGridView1.Rows[i].Cells["procent"].Value.ToString();
                        procent = procent.Remove(procent.Length - 1).Replace(",", ".");

                        String zapytanie = "insert into CDN.OpisKadry(OPK_RodzajZrodla, OPK_ZrodloId, OPK_PraId, OPK_DzlId, OPK_PrjId, OPK_Procent) values(" + rodzajZrodla + ", " + zrodloId + ", " + praId + ", " + dzlId + ", " + prjId + ", " + procent + ")";
                        zapiszDB(zapytanie);
                    }
                }
                zwiekszProgressBar();
            }
            progressBar1.Value = progressBar1.Maximum;
            MessageBox.Show("Dodano " + licznikWpisow + " wpisów do bazy danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void zwiekszProgressBar()
        {
            progressBar1.Increment(1);

            if (progressBar1.Value >= progressBar1.Maximum)
            {
                progressBar1.Value = 0;
            }
        }

        private void dataTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void procentyProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!zapisano && zapiszButton.Enabled)
            {
                DialogResult dialogResult = MessageBox.Show("Zmiany nie zostały zapisane w Optimie.\n\nCzy na pewno chcesz zamknąć program bez zapisu?", "Potwierdzenie zamknięcia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}