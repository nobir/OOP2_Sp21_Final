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
using System.Collections;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection ConnectDb()
        {
            SqlConnection connection = null;

            try{
                string connString = @"Server=NOBIR\SQLEXPRESS;Database=db_final_sp;Integrated Security=true;";
                connection = new SqlConnection(connString);
            }
            catch(Exception ex)
            {
                MessageBox.Show("[Error]\n" + ex + "\n");
            }

            return connection;
        }

        private void btnCLoad_Click(object sender, EventArgs e)
        {
            this.ShowAllCourse();
        }

        private void btnCAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = this.ConnectDb();

            if (connection == null)
            {
                MessageBox.Show("Connection Failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            connection.Open();

            string errorMessage = "";

            // Form data
            string cname = tbCCname.Text.Trim();
            string ccode = tbCCode.Text.Trim();

            // MySQL query
            string query = String.Format("INSERT INTO course VALUES('{0}','{1}')", ccode, cname);

            // validation
            if(cname.Length == 0)
            {
                errorMessage += "\nCourse Name Can't be Empty.";
            }
            if(ccode.Length == 0)
            {
                errorMessage += "\n\nCourse Code Can't be Empty.";
            }

            // show error message if available
            if(errorMessage.Length != 0)
            {
                MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                int row = cmd.ExecuteNonQuery();


                if(row > 0)
                {
                    MessageBox.Show("Successfully Added", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to Add", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            connection.Close();
            this.ShowAllCourse();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowAllCourse();
        }

        private void ShowAllCourse()
        {
            SqlConnection connection = this.ConnectDb();

            if (connection == null)
            {
                MessageBox.Show("Connection Failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // MySQL query
            string query = @"SELECT * FROM course";

            List<Course> courses = new List<Course>();

            connection.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    Course c = new Course();

                    c.Id = data.GetInt32(data.GetOrdinal("id"));
                    c.CourseName = data.GetString(data.GetOrdinal("cname"));
                    c.CourseCode = data.GetString(data.GetOrdinal("ccode"));

                    courses.Add(c);
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            connection.Close();

            dgvCourses.DataSource = courses;
        }
    }
}