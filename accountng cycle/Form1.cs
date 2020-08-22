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
    public partial class Form1 : Form
    {
        int count = 0;
        int asset_count = 0;
        int rev_count = 0;
        int liab_count = 0;
        int exp_count = 0;
        int oc_count = 0;
        int ow_count = 0;
        int asset_sum = 0;
        int rev_sum = 0;
        int ow_sum = 0; int oc_sum = 0; int liab_sum = 0;
        int exp_sum = 0; 
        string choice = "";
        string account = "";
        string q1 = "";
        String[] acc_name = new String[17] { "Asset", "Cash", "Supplies", "Land", "Equipment", "AR", "Expense", "SalaryExp", "SuppliesExp", "OW", "Revnue", "ServiceRevnue", "Liability", "UER", "NP", "AP", "OC" };
        int[] acc_sum = new int[17]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        int[] acc_id = new int[17] { 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0, 0, 0,0,0,0,0 };
        SqlConnection con = new SqlConnection(@"Data Source=ARYANZZ;Initial Catalog=AC;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            con.Open();
            for(int i=0;i<acc_sum.Length;i++)
            {
                q1 = "DELETE FROM "+acc_name[i];
                SqlDataAdapter sda2 = new SqlDataAdapter(q1, con);
                sda2.SelectCommand.ExecuteNonQuery();

            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Button button = (Button)sender;
        }

        private void button_click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            account =button.Text;
            aclabel.Text = button.Text;
            aclabel.Visible = true;
            choice = "";
          }

        private void button1_Click_1(object sender, EventArgs e)
        {
            choice = "Dr";
             aclabel.Text=account+"  (Dr)  :";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            for (int i = 0; i < acc_sum.Length; i++)
            {
                if (acc_name[i] == account)
                {
                    if (choice == "Dr")
                    {
                        acc_sum[i] = acc_sum[i] + int.Parse(amount.Text);
                        acc_id[i] = acc_id[i]++;
                        richTextBox1.AppendText("\n    " + account + " ");
                        richTextBox1.AppendText("                                  Dr   " + int.Parse(amount.Text));
                        q1 = "INSERT INTO "+account+" (Id,Dr,Cr) VALUES ('" + acc_id[i]+ "','" + int.Parse(amount.Text) + "','')";
                    }
                    else if (choice == "Cr")
                    {
                        acc_sum[i] = acc_sum[i] - int.Parse(amount.Text);
                        acc_id[i] = acc_id[i]++;
                        richTextBox1.AppendText("\n    " + account + " ");
                        richTextBox1.AppendText("                                                     Cr   " + int.Parse(amount.Text));
                        q1 = "INSERT INTO " + account + " (Id,Dr,Cr) VALUES ('" + acc_id[i]+ "','','" + int.Parse(amount.Text) + "')";
                    }
                }
            }
            choice = "";
            SqlDataAdapter sda = new SqlDataAdapter(q1, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted !");
          //  choice = "";
        }

        private void clear(object sender, EventArgs e)
        {
            amount.Clear();

        }
        private void clear2(object sender, EventArgs e)
        {
            amount.Clear();
            richTextBox1.Clear();
            con.Open();
           
            for (int i = 0; i < acc_sum.Length; i++)
            {
                q1 = "DELETE FROM " + acc_name[i];
                SqlDataAdapter sda2 = new SqlDataAdapter(q1, con);
                sda2.SelectCommand.ExecuteNonQuery();
                acc_sum[i] = 0;
                acc_id[i] = 0;

            }
            con.Close();
        
        }
        private void btn_cr_Click(object sender, EventArgs e)
        {
            choice = "Cr";
            
             aclabel.Text=account+"  (Cr)  :";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelt_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
                 for (int i=0;i<17;i++)
                 {
                     if (acc_sum[i] < 0)
                         acc_sum[i] = -acc_sum[i];
                 }
                    taccount t = new taccount(acc_name, acc_sum);
            //  this.Hide();
            t.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}

