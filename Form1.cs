using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movies2019
{
    public partial class Form1 : Form
    {

        //make an instance of the database class
        private database myDatabase = new database();

        public Form1()
        {
            InitializeComponent();
            Bunifu.Framework.Lib.Elipse.Apply(this, 20);
            DisplaydgvCustomers();
            DisplaydgvMovies();
            DisplaydgvRented();

        }

        // Displays Customers in DGV
        private void DisplaydgvCustomers()
        {
            //clear out old data.
            dgvCustomers.DataSource = null;
            try
            {
                dgvCustomers.DataSource = myDatabase.FilldgvCustomersWithCustomer();
                //pass the datatable data to the DataGridView
                dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception)
            {
                MessageBox.Show("dgvCustomers not filling with data");
            }

            Console.WriteLine("Line 48 Stuff");
            // Debug.WriteLine("Object is not valid for this category");
        }

        // Diplays Movies in DGV
        private void DisplaydgvMovies()
        {
            //clear out old data.
            dgvMovies.DataSource = null;
            try
            {
                dgvMovies.DataSource = myDatabase.FilldgvMoviesWithMovies();
                //pass the datatable data to the DataGridView
                dgvMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception)
            {
                MessageBox.Show("dgvMovies not filling with data");
            }

            Console.WriteLine("Line 48 Stuff");
            // Debug.WriteLine("Object is not valid for this category");
        }

        // Diplays Rented Movies in DGV
        private void DisplaydgvRented()
        {
            //clear out old data.
            dgvRented.DataSource = null;
            try
            {
                dgvRented.DataSource = myDatabase.FilldgvRentedWithRented();
                //pass the datatable data to the DataGridView
                dgvRented.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception)
            {
                MessageBox.Show("dgvRented not filling with data");
            }

            Console.WriteLine("Line 48 Stuff");
            // Debug.WriteLine("Object is not valid for this category");
        }




        //Displays Customer DGV
        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            dgvCustomers.Visible = true;
            dgvMovies.Visible = false;
            dgvRented.Visible = false;
            lblCustomers.Visible = true;
            lblMovies.Visible = false;
            lblRented.Visible = false;
            pnlCustomer.Visible = true;
            pnlMovie.Visible = false;
            // pnlRented.Visible = false;
            btnCustomers.BorderStyle = BorderStyle.Fixed3D;
            btnMovies.BorderStyle = BorderStyle.None;
            btnRented.BorderStyle = BorderStyle.None;

        }

        //Displays Movies DGV
        private void BtnMovies_Click(object sender, EventArgs e)
        {
            dgvCustomers.Visible = false;
            dgvMovies.Visible = true;
            dgvRented.Visible = false;
            lblCustomers.Visible = false;
            lblMovies.Visible = true;
            lblRented.Visible = false;
            pnlCustomer.Visible = false;
            //pnlRented.Visible = false;
            pnlMovie.Visible = true;
            btnCustomers.BorderStyle = BorderStyle.None;
            btnMovies.BorderStyle = BorderStyle.Fixed3D;
            btnRented.BorderStyle = BorderStyle.None;

        }

        //Displays Rented DGV
        private void BtnRented_Click(object sender, EventArgs e)
        {
            dgvCustomers.Visible = false;
            dgvMovies.Visible = false;
            dgvRented.Visible = true;
            lblCustomers.Visible = false;
            lblMovies.Visible = false;
            lblRented.Visible = true;
            pnlCustomer.Visible = false;
            pnlMovie.Visible = false;
            //pnlRented.Visible = true;
            btnCustomers.BorderStyle = BorderStyle.None;
            btnMovies.BorderStyle = BorderStyle.None;
            btnRented.BorderStyle = BorderStyle.Fixed3D;

        }



        //CRUD for customers

        //Update Click
        private void UpdateCustomer_Click(object sender, EventArgs e)
        {
            myDatabase.InsertOrUpdateCustomer(txtFN.Text, txtLN.Text, txtAddress.Text, txtPhone.Text, txtCustomerID.Text, "Update");
            DisplaydgvCustomers();
        }

        //Delete Click
        private void DeleteCustomer_Click(object sender, EventArgs e)
        {
            myDatabase.DeleteCustomer(txtCustomerID.Text);
            DisplaydgvCustomers();
        }

        //Add Click
        private void AddCustomer_Click(object sender, EventArgs e)
        {
            myDatabase.InsertOrUpdateCustomer(txtFN.Text, txtLN.Text, txtAddress.Text, txtPhone.Text, txtCustomerID.Text, "Add");
            DisplaydgvCustomers();
        }


        //CRUD for Movies

        //Update Click
        private void UpdateMovie_Click(object sender, EventArgs e)
        {
            myDatabase.InsertOrUpdateMovie(txtRating.Text, txtTitle.Text, txtYear.Text, txtCost.Text, txtCopies.Text, txtPlot.Text, txtGenre.Text, txtDate.Text, txtMovieID.Text, "Update");
            DisplaydgvMovies();
        }

        //Delete Click
        private void DeleteMovie_Click(object sender, EventArgs e)
        {
            myDatabase.DeleteMovie(txtMovieID.Text);
            DisplaydgvMovies();
        }

        //Add Click
        private void AddMovie_Click(object sender, EventArgs e)
        {
            myDatabase.InsertOrUpdateMovie(txtRating.Text, txtTitle.Text, txtYear.Text, txtCost.Text, txtCopies.Text, txtPlot.Text, txtGenre.Text, txtDate.Text, txtMovieID.Text, "Add");
            DisplaydgvMovies();
        }









        //passes data in to txt boxes from database on click
        private void DgvCustomers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int CustomerID = 0;

            //these are the cell clicks for the values in the row that you click on 
            try
            {

                CustomerID = (int)dgvCustomers.Rows[e.RowIndex].Cells[0].Value;

                txtFN.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLN.Text = dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
                //if you are clicking on a row and not outside it
                if (e.RowIndex >= 0)
                {


                    txtCustomerID.Text = CustomerID.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvRented_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int RMID = 0;

            //these are the cell clicks for the values in the row that you click on 
            try
            {

                RMID = (int)dgvRented.Rows[e.RowIndex].Cells[0].Value;


                //if you are clicking on a row and not outside it
                if (e.RowIndex >= 0)
                {


                    txtRMID.Text = RMID.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //passes data in to txt boxes from database on click
        private void DgvMovies_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int MovieID = 0;

            //these are the cell clicks for the values in the row that you click on 
            try
            {
                MovieID = (int)dgvMovies.Rows[e.RowIndex].Cells[0].Value;
                txtRating.Text = dgvMovies.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTitle.Text = dgvMovies.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtYear.Text = dgvMovies.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCost.Text = dgvMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCopies.Text = dgvMovies.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPlot.Text = dgvMovies.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtGenre.Text = dgvMovies.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtDate.Text = dgvMovies.Rows[e.RowIndex].Cells[8].Value.ToString();
                //if you are clicking on a row and not outside it
                if (e.RowIndex >= 0)
                {


                    txtMovieID.Text = MovieID.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        // CLoses Form
        private void Lbl3_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


        //Minimizes form
        private void Label2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {
            myDatabase.InsertRentedMovies(txtMovieID.Text, txtCustomerID.Text);
            MessageBox.Show("Movie has been Rented");
            DisplaydgvRented();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            myDatabase.UpdateRentedMovies(txtRMID.Text);
            MessageBox.Show("Movie has been Returned");
            DisplaydgvRented();
        }
    }
}
