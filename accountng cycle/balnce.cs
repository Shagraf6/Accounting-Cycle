using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace accountng_cycle
{
    public partial class balnce : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ARYANZZ;Initial Catalog=AC;Integrated Security=True");
        string q1;
        int count = 0;
        int OE = 0;
        int TASSET = 0, Tliab = 0;
        public balnce(string[] acc, int[] sum)
        {
            con.Open();
            InitializeComponent();

            q1 = "DELETE FROM Balance";
            SqlDataAdapter sda2 = new SqlDataAdapter(q1, con);
            sda2.SelectCommand.ExecuteNonQuery();
            q1 = "DELETE FROM Bsheet";
            sda2 = new SqlDataAdapter(q1, con);
            sda2.SelectCommand.ExecuteNonQuery();
            con.Close();
            
            con.Open();
            for (int i = 0; i < 10; i++)
            {
                if (sum[i] != 0)
                {
                    count++;
                    q1 = "INSERT INTO Balance (Id,Account,Dr,Cr) VALUES ('" + count + "','" + acc[i] + "','" + sum[i] + "','')";
                    SqlDataAdapter sda = new SqlDataAdapter(q1, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    TASSET = TASSET + sum[i];
                }
            }
            for (int i = 10; i < 17; i++)
            {

                if (sum[i] != 0)
                {
                    count++;
                    q1 = "INSERT INTO Balance (Id,Account,Dr,Cr) VALUES ('" + count + "','" + acc[i] + "','','" + sum[i] + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(q1, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    Tliab = Tliab + sum[i];
                }
            }
            count++;
            q1 = "INSERT INTO Balance (Id,Account,Dr,Cr) VALUES ('" + count + "','Total','" + TASSET + "','" + Tliab + "')";
            SqlDataAdapter sda4 = new SqlDataAdapter(q1, con);
            sda4.SelectCommand.ExecuteNonQuery();
                
            con.Close();

            con.Open();
            string view = "SELECT * FROM Balance";
            SqlDataAdapter sda1 = new SqlDataAdapter(view, con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);

                GV.DataSource = dt;
                con.Close();

                richTextBox1.AppendText("\n\n                                         ABC COMPANY");
                richTextBox1.AppendText("\n                                     INCOME STATEMENT");
                richTextBox1.AppendText("\n                     FOR THE PERIOD ENDING ON DEC 31,2018");
                richTextBox1.AppendText("\n\n\n\n              Net Income = Revnue - Expense");
                richTextBox1.AppendText("\n                    Expense = " + (sum[6] + sum[7] + sum[8]));
                richTextBox1.AppendText("\n                    Revnue = " + (sum[10] + sum[11]));
            string ni="";
            OE=   ((sum[10] + sum[11])-(sum[6] + sum[7] + sum[8]));
            if(OE<0)
              ni="("+(-OE)+")";
            else
                ni=""+OE;
            richTextBox1.AppendText("\n                    => N.I = "+ni);
                richTextBox1.AppendText("\n\n\n\n                              OWNER's EQUITY STATEMENT  ");
                richTextBox1.AppendText("\n\n\n\n              O.E = O.C + N.I - O.W");
                OE = ((sum[16] + ((sum[10] + sum[11]) - (sum[6] + sum[7] + sum[8])) - sum[9]));
                if (OE < 0)
                    ni = "(" +(- OE )+ ")";
                else
                    ni = "" + OE;
                richTextBox1.AppendText("\n                    => O.E = " +ni);
             con.Open();
                count = 0;
                Tliab = OE; 
                TASSET = 0;
             for (int i = 0; i < 6; i++)
             {
                if (sum[i] != 0)
                {
                    count++;
                    q1 = "INSERT INTO Bsheet (Id,Account,Asset,LIABorOE) VALUES ('" + count + "','" + acc[i] + "','" + sum[i] + "','')";
                    SqlDataAdapter sda = new SqlDataAdapter(q1, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    TASSET = TASSET + sum[i];
                }
             }
            for (int i = 12; i < 16; i++)
            {

                if (sum[i] != 0)
                {
                    count++;
                    q1 = "INSERT INTO Bsheet (Id,Account,Asset,LIABorOE) VALUES ('" + count + "','" + acc[i] + "','','" + sum[i] + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(q1, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    Tliab = Tliab + sum[i];
                }

            }
            count++;
            q1 = "INSERT INTO Bsheet (Id,Account,Asset,LIABorOE) VALUES ('" + count + "','OE','','" + OE + "')";
            SqlDataAdapter sda3 = new SqlDataAdapter(q1, con);
            sda3.SelectCommand.ExecuteNonQuery();
            count++;
            q1 = "INSERT INTO Bsheet (Id,Account,Asset,LIABorOE) VALUES ('" + count + "','Total','" + TASSET + "','" + Tliab + "')";
            sda3 = new SqlDataAdapter(q1, con);
            sda3.SelectCommand.ExecuteNonQuery();
                
            con.Close();
            con.Open();
            view = "SELECT * FROM Bsheet";
             sda1 = new SqlDataAdapter(view, con);
             dt = new DataTable();
            sda1.Fill(dt);

            GV2.DataSource = dt;
            con.Close();
            OE = 0;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void balnce_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
