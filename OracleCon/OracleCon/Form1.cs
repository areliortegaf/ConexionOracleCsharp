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
//

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

            string host = "localhost";
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
            cmd.CommandText = "select job from emp where empno = '7839'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            int count = 0;
            dr.Read();
            
            if(resultado != null || resultado != "")
            {
                label2.Text = dr[0].ToString();
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
