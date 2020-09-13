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
    }
}
