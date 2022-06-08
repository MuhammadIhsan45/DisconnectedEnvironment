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



namespace DisconnectedEnvironment
{
    public partial class Form1 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prodiTIDataSet1.Mahasiswa' table. You can move, or remove it, as needed.
            this.mahasiswaTableAdapter1.Fill(this.prodiTIDataSet1.Mahasiswa);
            // TODO: This line of code loads data into the 'prodiTIDataSet1.HRDataSet' table. You can move, or remove it, as needed.
            this.hRDataSetTableAdapter.Fill(this.prodiTIDataSet1.HRDataSet);
            // TODO: This line of code loads data into the 'prodiTIDataSet.Mahasiswa' table. You can move, or remove it, as needed.
            this.mahasiswaTableAdapter.Fill(this.prodiTIDataSet.Mahasiswa);
            // TOFO:This line of code loads data into the 'hRDataSet.empdetails' table.
            //you da move, or remove it, as needed
            this.hRDataSetTableAdapter.Fill(this.prodiTIDataSet1.HRDataSet);

            this.hRDataSetTableAdapter.Fill(this.prodiTIDataSet1.HRDataSet); 
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartment.Enabled = false;
            cbDesignation.Items.Add("MAMAGER");
            cbDesignation.Items.Add("AUTHOR");
            cbDesignation.Items.Add("Designer");
            cbDepartment.Items.Add("MARKETING");
            cbDepartment.Items.Add("FINANCE");
            cbDepartment.Items.Add("IDD");
            cmdSave.Enabled=false;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            cmdSave.Enabled= true;
            txtName.Enabled= true;
            txtAddress.Enabled = true;
            txtState.Enabled =true;
            txtCountry.Enabled =true;
            cbDesignation.Enabled =true;
            cbDepartment.Enabled = true;
            txtName.Text="";
            txtAddress.Text="";
            txtState.Text="";
            txtCountry.Text = "";
            cbDesignation.Text = "";
            cbDepartment.Text = "";
            int ctr, len;
            string codeval;
            dt = prodiTIDataSet1.Tables["HRDataSet"];
            len = dt.Rows.Count-1;
            dr = dt.Rows[len];
            code = dr["ccode"].ToString();
            codeval =code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr > 1) && (ctr < 9))
            {
                ctr=ctr+1;
                txtCode.Text = "coo" + ctr;
            }
            else if ((ctr >= 1) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtCode.Text = "C0" + ctr;
            }
            cmdAdd.Enabled = false;

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = prodiTIDataSet1.Tables["HRDataSet"];
            dr = dt.NewRow();
            dr[0] = txtCode.Text;
            dr[1] = txtName.Text;
            dr[2] = txtAddress.Text;
            dr[3] = txtState.Text;
            dr[4] = txtCountry.Text;
            dr[5] = cbDesignation.SelectedItem;
            dr[6] = cbDepartment.SelectedItem;
            dt.Rows.Add(dr);
            this.hRDataSetTableAdapter.Update(prodiTIDataSet1);
            txtCode.Text=System.Convert.ToString(dr[0]);
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartment.Enabled = false;
            this.hRDataSetTableAdapter.Fill(this.prodiTIDataSet1.HRDataSet);
            cmdAdd.Enabled=  true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtCode.Text;
            dr= prodiTIDataSet1.Tables["HRDataSet"].Rows.Find(code);
            dr.Delete();
            hRDataSetTableAdapter.Update(prodiTIDataSet1);
        }

        private void label4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
