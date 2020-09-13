using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysqlConnect
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        String connectionString = "";
        bool isOpen = false;
        MySqlConnection conn = null;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            connectionString = $"server={tbHost.Text};userid={tbUser.Text};password={tbPass.Text};database={tbDbName.Text};port=3306";
            try
            {
                if (isOpen)
                {
                    // rozłącz
                    conn.Close();
                    conn.Dispose();
                    isOpen = false;
                    btnConnect.Text = "Połącz";
                } else
                {
                    // połącz
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                    isOpen = true;
                    btnConnect.Text = "Rozłącz";
                }
            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message);                
            }
        }

        private void btnRunSQL_Click(object sender, EventArgs e)
        {

            try
            {
                lvGrid.BeginUpdate();
                lvGrid.Items.Clear();
                lvGrid.Columns.Clear();

                MySqlCommand cmd = new MySqlCommand(tbSQL.Text, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    int j = rdr.FieldCount; //liczba kolumn w odp. z serwera
                    for (int i = 0; i < j; i++)
                    {
                        lvGrid.Columns.Add(rdr.GetName(i), 150);
                    }

                    while (rdr.Read())
                    {
                        string[] arr = new string[j];
                        for (int i = 0; i < j; i++)
                        {
                            if (rdr.IsDBNull(i))
                            {
                                arr[i] = "(NULL)";
                            }
                            else
                            {
                                arr[i] = rdr.GetString(i);
                            }
                        }
                        lvGrid.Items.Add(new ListViewItem(arr));
                    }
                    
                }
                

            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            } finally
            {
                lvGrid.EndUpdate();
            }

        }
    }
}
