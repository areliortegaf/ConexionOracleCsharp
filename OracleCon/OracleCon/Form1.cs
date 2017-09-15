using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client; --con el 12
//referiencia: http://o7planning.org/en/10509/connecting-to-oracle-database-using-csharp-without-oracle-client

namespace OracleCon
{
    public partial class Form1 : Form
    {

        string resultado = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void conexion()
        {

            string host = "xxx.xxx.xxx";
            string port = "1521";
            string sid = "pdborcl";
            string password = "hr";
            string user = "hr";

            string oradb = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
             + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
              + sid + ")));Password=" + password + ";User ID=" + user;
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM emp";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                resultado = resultado + dr.GetString(count);
                count++;
            }
            if(resultado != null || resultado != "")
            {
                label2.Text = "Conexion Exitosa";
            }
            else
            {
                label2.Text = "Conexion fallida";
            }
            
            conn.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
