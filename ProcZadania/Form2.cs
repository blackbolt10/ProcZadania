using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProcZadania
{
    public partial class Form2 : Form
    {
        procentyProgram form1;
        SqlConnection uchwytBD;
        bool bladKrytyczny;

        public Form2(procentyProgram _form1, SqlConnection _uchwytBD)
        {
            form1 = _form1;
            uchwytBD = _uchwytBD;
            bladKrytyczny = false;

            InitializeComponent();

            String[] rozszerzenie = this.form1.openFileDialog1.FileName.Split('.');
            //MessageBox.Show(rozszerzenie[rozszerzenie.Length-1].ToString());

            switch (rozszerzenie[rozszerzenie.Length - 1])
            {
                case "xlsx":
                    czytajPlikExcel(this.form1.openFileDialog1.FileName.ToString());
                    break;
                case "txt": 
                    czytajPlik(this.form1.openFileDialog1.FileName.ToString());
                    break;
                default:
                    MessageBox.Show("Nie wybrano prawidłowego rozszerzenia", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bladKrytyczny = true;
                    break;
            }
            if (!bladKrytyczny)
            {
                sprzwdzPoprawnoscDanych();

                progressBar1.Value = progressBar1.Maximum;
                form1.progressBar1.Value = form1.progressBar1.Maximum;

                if (richTextBox1.Lines.Count() == 4)
                    richTextBox1.AppendText("Nie wykryto błędów\n");

                if (bladKrytyczny)
                    richTextBox1.AppendText("\nPlik zawiera błędne dane. Zapis nie będzie możliwy.\n");

                ZamknijButton.Focus();
            }
        }

        private void czytajPlikExcel(String fileLink)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            int licznikOdczytu = 0; 
            
            form1.dataGridView1.Rows.Clear();
            form1.progressBar1.Maximum = 50;
            form1.zapiszButton.Enabled = true;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileLink);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[3];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                try
                {
                    String akronimPracownika = xlRange.Cells[i, 1].Value2.ToString();
                    String projekt = xlRange.Cells[i, 3].Value2.ToString();
                    String zadanie = xlRange.Cells[i, 4].Value2.ToString();
                    String procent = xlRange.Cells[i, 10].Value2.ToString();

                    procent = procent.Replace(".", ",");
                    double procentWartosc = Convert.ToDouble(procent) * 100;
                    //MessageBox.Show(akronimPracownika + " " + projekt + " " + zadanie + " " + procentWartosc.ToString());

                    String[] dodatkoweInformacje = pobierzDodatkoweInformacje(akronimPracownika, projekt, zadanie);
                    try
                    {
                        form1.dataGridView1.Rows.Add(akronimPracownika, projekt, zadanie, procentWartosc.ToString()+"%", dodatkoweInformacje[0], dodatkoweInformacje[1], dodatkoweInformacje[2], dodatkoweInformacje[3], dodatkoweInformacje[4], dodatkoweInformacje[5], "0");
                        licznikOdczytu++;

                        if (dodatkoweInformacje[0] == null || dodatkoweInformacje[0] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o pracowniku '" + akronimPracownika + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        else if (dodatkoweInformacje[1] == null || dodatkoweInformacje[1] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o rodzaju źródła pracownika '" + akronimPracownika + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        else if (dodatkoweInformacje[2] == null || dodatkoweInformacje[2] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o id źródła pracownika '" + akronimPracownika + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        else if (dodatkoweInformacje[3] == null || dodatkoweInformacje[3] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o id pracownika '" + projekt + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        if (dodatkoweInformacje[4] == null || dodatkoweInformacje[4] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o projekcie '" + zadanie + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        if (dodatkoweInformacje[5] == null || dodatkoweInformacje[5] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o zadaniu '" + zadanie + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                    }
                    catch (Exception e)
                    {

                        MessageBox.Show(e.Message + "\r\n\r\nTen rekord zostanie pominięty!", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    zwiekszProgressBar();
                    zwiekszForm1ProgressBar();
                }
                catch
                {
                    break;
                }
            }
            xlWorkbook.Close(false, null, null);
            xlApp.Quit();

            form1.dataGridView1.Sort(form1.dataGridView1.Columns["Akronim"], ListSortDirection.Ascending);
            richTextBox1.AppendText("\nOdczytano z pliku  " + licznikOdczytu + " wierszy.\n\n");

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void czytajPlik(String NazwaPliku)
        {
            string line;
            int licznikOdczytu = 0;

            form1.dataGridView1.Rows.Clear();
            form1.progressBar1.Maximum = 50;
            form1.zapiszButton.Enabled = true;

            System.IO.StreamReader file = new System.IO.StreamReader(@NazwaPliku, System.Text.Encoding.Default);
           // try
            {
                line = file.ReadLine(); //pierwsza linie odrzucamy

                while ((line = file.ReadLine()) != null)
                {
                    String[] wiersz = line.Split('\t');

                    if (wiersz[0] == "" && wiersz[2] == "" && wiersz[3] == "" && wiersz[9] == "")
                        break;

                    String akronimPracownika = wiersz[0];
                    String projekt = wiersz[2];
                    String zadanie = wiersz[3];
                    String procent = wiersz[9];

                    //MessageBox.Show("akronim = " + akronimPracownika + " | projekt = " + projekt + " | zadanie = " + zadanie + " | procent =" + procent);

                    String[] dodatkoweInformacje = pobierzDodatkoweInformacje(akronimPracownika, projekt, zadanie);

                    try
                    {
                        form1.dataGridView1.Rows.Add(akronimPracownika, projekt, zadanie, procent, dodatkoweInformacje[0], dodatkoweInformacje[1], dodatkoweInformacje[2], dodatkoweInformacje[3], dodatkoweInformacje[4], dodatkoweInformacje[5], "0");
                        licznikOdczytu++;

                        //Pri_kod, 16 rodzajzrodla, pre_preid ZrodloID, pri_praid, PRI_DzlId

                        if (dodatkoweInformacje[0] == null ||  dodatkoweInformacje[0] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o pracowniku '" + akronimPracownika + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        else if (dodatkoweInformacje[1] == null || dodatkoweInformacje[1] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o rodzaju źródła pracownika '" + akronimPracownika + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        else if(dodatkoweInformacje[2] == null || dodatkoweInformacje[2] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o id źródła pracownika '" + akronimPracownika + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        else if(dodatkoweInformacje[3] == null || dodatkoweInformacje[3] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o id pracownika '" + projekt + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        if(dodatkoweInformacje[4] == null || dodatkoweInformacje[4] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o projekcie '" + zadanie + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                        if(dodatkoweInformacje[5] == null || dodatkoweInformacje[5] == "")
                        {
                            richTextBox1.AppendText("Nie udało się pobrać informacji o zadaniu '" + zadanie + "'\n");
                            ustawBlad(akronimPracownika, projekt, zadanie);
                        }
                    }
                    catch (Exception e)
                    {

                        MessageBox.Show(e.Message + "\r\n\r\nTen rekord zostanie pominięty!", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    zwiekszProgressBar();
                    zwiekszForm1ProgressBar();
                }
            }
            //catch
            {
                //progressBar1.Value = progressBar1.Maximum;
                //form1.progressBar1.Value = form1.progressBar1.Maximum;
            }
            file.Close();

            form1.dataGridView1.Sort(form1.dataGridView1.Columns["Akronim"], ListSortDirection.Ascending);
            richTextBox1.AppendText("\nOdczytano z pliku  " + licznikOdczytu + " wierszy.\n\n");
        }

        private void ustawBlad(String akronimPracownika, String projekt, String zadanie)
        {
            //richTextBox1.AppendText("Nie udało się pobrać informacji o pracowniku '" + akronimPracownika + "' projekcie '" + projekt + "' zadaniu '" + zadanie + "'\n");
            form1.dataGridView1.Rows[form1.dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
            form1.zapiszButton.Enabled = false;
            bladKrytyczny = true;
        }
        
        private void zwiekszProgressBar()
        {
            progressBar1.Increment(1);

            if (progressBar1.Value >= progressBar1.Maximum)
            {
                progressBar1.Value = 0;
            }
        }

        private void zwiekszForm1ProgressBar()
        {
            form1.progressBar1.Increment(1);

            if (form1.progressBar1.Value >= form1.progressBar1.Maximum)
            {
                form1.progressBar1.Value = 0;
            }
        }

        private void sprzwdzPoprawnoscDanychExcel()
        {
            String[] tabPomAkronim = new String[form1.dataGridView1.Rows.Count];
            decimal[] tabPomProcent = new decimal[form1.dataGridView1.Rows.Count];
            int licznikTabPom = 0;

            String poprzedniAkronim = form1.dataGridView1.Rows[0].Cells["Akronim"].Value.ToString();

            for (int i = 0; i < form1.dataGridView1.Rows.Count; i++)
            {
                String aktualnyAkronim = form1.dataGridView1.Rows[i].Cells["Akronim"].Value.ToString();
                if (poprzedniAkronim == aktualnyAkronim)
                {
                    tabPomAkronim[licznikTabPom] = aktualnyAkronim;
                    decimal procPom = Convert.ToDecimal(form1.dataGridView1.Rows[i].Cells["procent"].Value.ToString().Remove(form1.dataGridView1.Rows[i].Cells["procent"].Value.ToString().Length - 1));
                    tabPomProcent[licznikTabPom] = tabPomProcent[licznikTabPom] + procPom;
                }
                else
                {
                    licznikTabPom++;
                    tabPomAkronim[licznikTabPom] = aktualnyAkronim;
                    decimal procPom = Convert.ToDecimal(form1.dataGridView1.Rows[i].Cells["procent"].Value.ToString().Remove(form1.dataGridView1.Rows[i].Cells["procent"].Value.ToString().Length - 1));
                    tabPomProcent[licznikTabPom] = procPom;
                }

                poprzedniAkronim = aktualnyAkronim;
            }
            oznaczNieprawidloweDane(tabPomAkronim, tabPomProcent, licznikTabPom);
            zwiekszForm1ProgressBar();
            zwiekszProgressBar();
        }

        private void sprzwdzPoprawnoscDanych()
        {
            String[] tabPomAkronim = new String[form1.dataGridView1.Rows.Count];
            decimal[] tabPomProcent = new decimal[form1.dataGridView1.Rows.Count];
            int licznikTabPom = 0;

            String poprzedniAkronim = form1.dataGridView1.Rows[0].Cells["Akronim"].Value.ToString();

            for (int i = 0; i < form1.dataGridView1.Rows.Count; i++)
            {
                String aktualnyAkronim = form1.dataGridView1.Rows[i].Cells["Akronim"].Value.ToString();
                if (poprzedniAkronim == aktualnyAkronim)
                {
                    tabPomAkronim[licznikTabPom] = aktualnyAkronim;
                    decimal procPom = Convert.ToDecimal(form1.dataGridView1.Rows[i].Cells["procent"].Value.ToString().Remove(form1.dataGridView1.Rows[i].Cells["procent"].Value.ToString().Length - 1));
                    tabPomProcent[licznikTabPom] = tabPomProcent[licznikTabPom] + procPom;
                }
                else
                {
                    licznikTabPom++;
                    tabPomAkronim[licznikTabPom] = aktualnyAkronim;
                    decimal procPom = Convert.ToDecimal(form1.dataGridView1.Rows[i].Cells["procent"].Value.ToString().Remove(form1.dataGridView1.Rows[i].Cells["procent"].Value.ToString().Length - 1));
                    tabPomProcent[licznikTabPom] = procPom;
                }

                poprzedniAkronim = aktualnyAkronim;
            }
            oznaczNieprawidloweDane(tabPomAkronim, tabPomProcent, licznikTabPom);
            zwiekszForm1ProgressBar();
            zwiekszProgressBar();
        }

        private void oznaczNieprawidloweDane(String[] tabPomAkronim, decimal[] tabPomProcent, int licznikTabPom)
        {
            for (int i = 0; i < licznikTabPom; i++)
            {
                decimal wartosc = tabPomProcent[i];
                if (wartosc > (decimal)100 || wartosc < (decimal)0)
                {
                    for (int j = 0; j < form1.dataGridView1.Rows.Count; j++)
                    {
                        if (form1.dataGridView1.Rows[j].Cells["Akronim"].Value.ToString() == tabPomAkronim[i])
                        {
                            form1.dataGridView1.Rows[j].Cells["blad"].Value = "1";

                            String akronim = form1.dataGridView1.Rows[i].Cells["akronim"].Value.ToString();
                            String projekt = form1.dataGridView1.Rows[i].Cells["projekt"].Value.ToString();
                            String zadanie = form1.dataGridView1.Rows[i].Cells["zadania"].Value.ToString();

                            richTextBox1.AppendText("Pracownik '"+akronim+"' z projektu '"+projekt+"' zadania '"+zadanie+"' przekrocza sumę 100% ze wszystkich zadań.\n");
                            form1.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                        }

                        zwiekszForm1ProgressBar();
                        zwiekszProgressBar();
                    }
                }
                zwiekszForm1ProgressBar();
                zwiekszProgressBar();
            }
        }

        private void ZamknijButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public String[] pobierzDodatkoweInformacje(String akronimPracownika, String projekt, String zadanie)
        {
            DateTime data = new DateTime(form1.dataTimePicker.Value.Year, form1.dataTimePicker.Value.Month, form1.dataTimePicker.Value.Day, 00, 00, 00);
            String zapytanie = "select Pri_kod, 16 rodzajzrodla, pre_preid ZrodloID, pri_praid, PRI_DzlId, (select b.prj_prjid from cdn.defprojekty as A join cdn.defprojekty as B on b.PRJ_ParentId=a.PRJ_PrjId where a.prj_kod='" + projekt + "' and b.prj_kod='" + zadanie + "') PrjID, 'Umowa o pracę - Etat' Umowa from cdn.Pracidx join cdn.pracetaty on pri_praid=pre_praid where PRI_Typ=10 and '" + data + "' between pre_dataod and pre_datado and '" + data + "' between PRE_ZatrudnionyOd and PRE_ZatrudnionyDo and pri_kod='" + akronimPracownika + "' union select Pri_kod, 8 rodzajzrodla, umw_umwid ZrodloID, PRI_PraId, PRI_DzlId, (select b.prj_prjid from cdn.defprojekty as A join cdn.defprojekty as B on b.PRJ_ParentId=a.PRJ_PrjId where a.prj_kod='" + projekt + "' and b.prj_kod='" + zadanie + "') PrjID, UMW_NumerPelny from cdn.Pracidx join cdn.umowy on PRI_PraId=UMW_PraId where pri_typ=20 and '" + data + "' between UMW_DataOd and UMW_DataDo and pri_kod='" + akronimPracownika + "'";
            String[] wynik = new String[6];
            SqlCommand polecenieSQL = null;

            SqlDataReader reader = null;
            try
            {
                using (polecenieSQL = new SqlCommand(zapytanie, uchwytBD))
                {
                    reader = polecenieSQL.ExecuteReader();

                    DataTable pomDT = new DataTable();
                    pomDT.Load(reader);

                    if (pomDT.Rows.Count > 1)
                    {
                        //MessageBox.Show("test");
                        rodzajUmowy rodzajOkno = new rodzajUmowy(pomDT, wynik, projekt, zadanie);
                        rodzajOkno.ShowDialog();
                        rodzajOkno.Dispose();
                    }
                    else
                    {
                        for (int i = 0; i < pomDT.Rows.Count; i++) 
                        {
                            wynik[0] = pomDT.Rows[i][0].ToString();
                            wynik[1] = pomDT.Rows[i][1].ToString();
                            wynik[2] = pomDT.Rows[i][2].ToString();
                            wynik[3] = pomDT.Rows[i][3].ToString();
                            wynik[4] = pomDT.Rows[i][4].ToString();
                            wynik[5] = pomDT.Rows[i][5].ToString();
                        }
                    }
                }
            }
            catch //(Exception exc)
            {
                //MessageBox.Show(exc.Message);
                //MessageBox.Show("Nie udało się pobrać dodatkowych informacji z bazy danych.\nJednym z powodów błędu może być brak projektu o kodzie '" + projekt + "' lub zadania '" + zadanie + "'. \nProgram zostanie zamknięty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.AppendText("Nie udało się pobrać dodatkowych informacji z bazy danych.\nJednym z powodów błędu może być brak projektu o kodzie '" + projekt + "' lub zadania '" + zadanie + "'. \n");
                form1.zapiszButton.Enabled = false;
                bladKrytyczny = true;
            }
            reader.Close();

            return wynik;
        }
    }
}
