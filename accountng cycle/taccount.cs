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
    public partial class taccount : Form
    {
        string q = "";
        SqlConnection con = new SqlConnection(@"Data Source=ARYANZZ;Initial Catalog=AC;Integrated Security=True");
        int l, e, r, a, w, o = 0;
        public taccount()
        {
            InitializeComponent();

            //   Button button = (Button)sender;
 }   private void dgA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
       string[] acc = new string[17];
       int[] sum = new int[17];
       public taccount(string[] acc, int[] sum)
       {

           InitializeComponent();
            this.acc=acc;
            this.sum = sum;
           
           con.Open();
           string view = "SELECT * FROM Asset";
           SqlDataAdapter sda = new SqlDataAdapter(view, con);
           DataTable dt = new DataTable();
           sda.Fill(dt);
           if (sum[0] == 0)
               Asset.Visible = false;
           else
            Asset.DataSource = dt;
           
            view = "SELECT * FROM Revnue";
           sda = new SqlDataAdapter(view, con);
           dt = new DataTable();
           sda.Fill(dt);
           if (sum[10] == 0)
               Revnue.Visible = false;
           else
               Revnue.DataSource = dt;
           view = "SELECT * FROM ow";
           sda = new SqlDataAdapter(view, con);
           dt = new DataTable();
           sda.Fill(dt);
           if (sum[9] == 0)
               ow.Visible = false;
           else
               ow.DataSource = dt;
           view = "SELECT * FROM oc";
           sda = new SqlDataAdapter(view, con);
           dt = new DataTable();
           sda.Fill(dt);
           if (sum[16] == 0)
               oc.Visible = false;
           else
               oc.DataSource = dt;
           view = "SELECT * FROM Liability";
           sda = new SqlDataAdapter(view, con);
           dt = new DataTable();
           sda.Fill(dt);
           if (sum[12] == 0)
               Liability.Visible = false;
           else
               Liability.DataSource = dt;

           view = "SELECT * FROM Expense";
           sda = new SqlDataAdapter(view, con);
           dt = new DataTable();
           sda.Fill(dt);

           if (sum[6] == 0)
               Expense.Visible = false;
           else Expense.DataSource = dt;

            view = "SELECT * FROM Cash";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[1] == 0)
                cash.Visible = false;
            else
                cash.DataSource = dt;

            view = "SELECT * FROM Supplies";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[2] == 0)
                Supplies.Visible = false;
            else Supplies.DataSource = dt;

            view = "SELECT * FROM AR";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[5] == 0)
                AR.Visible = false;
            else
                AR.DataSource = dt;

            view = "SELECT * FROM NP";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[14] == 0)
                NP.Visible = false;
            else
                NP.DataSource = dt;

            view = "SELECT * FROM Land";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[3] == 0)
                Land.Visible = false;
            else Land.DataSource = dt;

            view = "SELECT * FROM Equipment";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[4] == 0)
                Equipment.Visible = false;
            else
            Equipment.DataSource = dt;

            view = "SELECT * FROM SalaryExp";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[7] == 0)
                SalaryExp.Visible = false;
            else
            SalaryExp.DataSource = dt;

            view = "SELECT * FROM SuppliesExp";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[8] == 0)
                SuppliesExp.Visible = false;
            else
            SuppliesExp.DataSource = dt;

            view = "SELECT * FROM AP";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[16] == 0)
                AP.Visible = false;
            else AP.DataSource = dt;

            view = "SELECT * FROM UER";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[13] == 0)
                UER.Visible = false;
            else UER.DataSource = dt;
           
            view = "SELECT * FROM ServiceRevnue";
            sda = new SqlDataAdapter(view, con);
            dt = new DataTable();
            sda.Fill(dt);
            if (sum[11] == 0)
                ServiceRev.Visible = false;
            else
                ServiceRev.DataSource = dt;

           
           
           con.Close();
       }



       private void label5_Click(object sender, EventArgs e)
       {

       }

       private void label7_Click(object sender, EventArgs e)
       {

       }

       private void label8_Click(object sender, EventArgs e)
       {

       }

       private void label13_Click(object sender, EventArgs e)
       {

       }

       private void label12_Click(object sender, EventArgs e)
       {

       }

       private void label10_Click(object sender, EventArgs e)
       {

       }

       private void dgL_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {

       }

       private void label20_Click(object sender, EventArgs e)
       {

       }

       private void dgE_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {

       }

       private void label22_Click(object sender, EventArgs e)
       {

       }

       private void label24_Click(object sender, EventArgs e)
       {

       }

       private void next_Click(object sender, EventArgs e)
       {
          for(int i=0;i<sum.Length;i++)
          {
              if (sum[i] < 0)
                  sum[i] = -sum[i];
          }
           balnce b = new balnce(this.acc, this.sum);
           this.Hide();
           b.Show();
       }

       private void groupBox1_Enter(object sender, EventArgs e)
       {

       }

       private void SalaryExp_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {

       }

       private void oc_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {

       }

       private void groupBox6_Enter(object sender, EventArgs e)
       {

       }

       private void taccount_Load(object sender, EventArgs e)
       {

       }

       private void groupBox3_Enter(object sender, EventArgs e)
       {

       }

       private void groupBox7_Enter(object sender, EventArgs e)
       {

       }

       private void label11_Click(object sender, EventArgs e)
       {

       }
    }
}
