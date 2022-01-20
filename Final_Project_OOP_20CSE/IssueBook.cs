using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_OOP_20CSE
{
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from NewBook", con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for(int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBoxBooks.Items.Add(Sdr.GetString(i));
                }   
            }   
            Sdr.Close();
            con.Close();
        }

        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text != "")
            {
                String eid = txtStudentID.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Student where studentid = '" + eid + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


                //---------------------------------------------------------------
                //Code to Count how many have been issued on this ID number
                cmd.CommandText = "select count(std_id) from IRBook where std_id = '" + eid + "' and book_return_date is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());

                //-----------------------------------------------------------------

                if (DS.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtId.Text = DS.Tables[0].Rows[0][2].ToString();
                    txtMajor.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = DS.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtName.Clear();
                    txtId.Clear();
                    txtMajor.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Student ID No","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }   
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                //if(comboBoxBooks.SelectedIndex != -1 && count>=2)
                //{
                    String id = txtId.Text;
                    String sname = txtName.Text;
                    String smajor = txtMajor.Text;
                    String sem = txtSemester.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    String email = txtEmail.Text;
                    String bookname = comboBoxBooks.Text;
                    String bookIssueDate = dateTimePicker.Text;

                    String eid = txtStudentID.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into IRBook (std_id,std_major,std_sem,std_contact,std_email,book_name,book_issue_date) values ('"+id+"', '"+smajor+"', '"+sem+"', '"+ contact+"', '" +email+"', '"+ bookname+"', '" + bookIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                   // MessageBox.Show("Select Book. OR Maximum number of Book Has been ISSUED","No book Selected",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //}
            }   
            else
            {
                MessageBox.Show("Enter valid ID No", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }   
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(txtStudentID.Text =="")
            {
                txtName.Clear();
                txtId.Clear();
                txtMajor.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }   
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
