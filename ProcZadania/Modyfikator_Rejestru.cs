using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProcZadania
{
    public partial class Modyfikator_Rejestru : Form
    {
        String sciezkaRejestru = "Software\\Galsoft\\Daglas\\procentyProgram";

        public Modyfikator_Rejestru()
        {
            InitializeComponent();

            sciezkaLabel.Text = sciezkaLabel.Text + sciezkaRejestru;
            odczytajRejest();
        }

        private void zamknijButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void odczytajRejest()
        {
            String login = "", haslo = "", instancja = "", baza = "";

            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sciezkaRejestru);

            loginTextBox.Text = key.GetValue("login", login).ToString();
            hasloTextBox.Text = key.GetValue("haslo", haslo).ToString();
            instancjaTextBox.Text = key.GetValue("instancja", instancja).ToString();
            bazaTextBox.Text = key.GetValue("nazwaBD", baza).ToString();

            key.Close();
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sciezkaRejestru);

            if (WindowState != FormWindowState.Minimized)
            {
                key.SetValue("login", loginTextBox.Text);
                key.SetValue("haslo", hasloTextBox.Text);
                key.SetValue("instancja", instancjaTextBox.Text);
                key.SetValue("nazwaBD", bazaTextBox.Text);
            }
            key.Close();
            MessageBox.Show("Dane zostały zapisane do rejestru.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            zapiszButton.Enabled = false;
            zamknijButton.Enabled = false;
            testButton.Enabled = false;

            try
            {
                SqlConnection uchwytBD;
                uchwytBD = new SqlConnection(@"user id=" + loginTextBox.Text + "; password=" + hasloTextBox.Text + "; Data Source=" + instancjaTextBox.Text + "; Initial Catalog=" + bazaTextBox.Text + ";");
                uchwytBD.Open();
                uchwytBD.Close();

                MessageBox.Show("Połączenie zostało wykonane poprawnie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Wystąpił błąd podczas próby połączenia z bazą danych. Treść błędu:\n" + exc.Message, "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            zapiszButton.Enabled = true;
            zamknijButton.Enabled = true;
            testButton.Enabled = true;
        }
    }
}
