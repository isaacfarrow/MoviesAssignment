using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace Movies2019
{
    class database
    {
        //Create Connection and Command,and an Adapter.
        private SqlConnection Connection = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();

        public int CustomerID { get; set; }

        //THE CONSTRUCTOR SETS THE DEFAULTS UPON LOADING THE CLASS
        public database()
        {
            //change the connection string to run from your own music db
            string connectionString =
                @"Data Source=LAPTOP-1SH00TN0\SQLEXPRESS;Initial Catalog=VBMoviesFullData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection.ConnectionString = connectionString;
            Command.Connection = Connection;

        }


        // Fill DGVS

        // Fillls DGV with Customers
        public DataTable FilldgvCustomersWithCustomer()

        {
            //create a datatable as we only have one table, the Owner
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from Customer ", Connection))
            {
                //connect in to the DB and get the SQL
                Connection.Open();
                //open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection 

            }

            return dt; //pass the datatable data to the DataGridView   
        }

        // Fillls DGV with Movies
        public DataTable FilldgvMoviesWithMovies()

        {
            //create a datatable as we only have one table, the Owner
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from Movies  ", Connection))
            {
                //connect in to the DB and get the SQL
                Connection.Open();
                //open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection 

            }

            return dt; //pass the datatable data to the DataGridView   
        }

        // Fillls DGV with Rented Movies
        public DataTable FilldgvRentedWithRented()

        {
            //create a datatable as we only have one table, the Owner
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from RentedMovies  ", Connection))
            {
                //connect in to the DB and get the SQL
                Connection.Open();
                //open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection 

            }

            return dt; //pass the datatable data to the DataGridView   
        }


        //CRUD

        //Insert or Update Customer

        public string InsertOrUpdateCustomer(string Firstname, string Lastname, string Address, string Phone, string ID, string AddOrUpdate)
        {
            try
            {
                //Add gets passed through the parameter
                if (AddOrUpdate == "Add")
                {
                    //Create a Command object  //Create a Query. Create and open a connection to SQL Server
                    string query = "INSERT INTO Customer (FirstName, LastName, Address, Phone) " + "VALUES(@Firstname, @Lastname, @Address, @Phone)";


                    var myCommand = new SqlCommand(query, Connection);
                    //create params
                    myCommand.Parameters.AddWithValue("Firstname", Firstname);
                    myCommand.Parameters.AddWithValue("Lastname", Lastname);
                    myCommand.Parameters.AddWithValue("Address", Address);
                    myCommand.Parameters.AddWithValue("Phone", Phone);
                    Connection.Open();
                    // open connection add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();

                }
                //Update gets passed through the parameter
                else if (AddOrUpdate == "Update")
                {
                    var myCommand =
                        new SqlCommand(
                            "UPDATE Customer set FirstName = @Firstname, LastName=@Lastname, Address=@Address, Phone=@Phone where CustID = @ID ",
                            Connection);
                    //use parameters to prevent SQL injections
                    myCommand.Parameters.AddWithValue("Firstname", Firstname);
                    myCommand.Parameters.AddWithValue("Lastname", Lastname);
                    myCommand.Parameters.AddWithValue("Address", Address);
                    myCommand.Parameters.AddWithValue("Phone", Phone);
                    myCommand.Parameters.AddWithValue("ID", ID);
                    Connection.Open();
                    // open connection add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();
                }

                return " is Successful";
            }
            catch (Exception e)
            {
                //need to get it to close a second time as it jumps the first connection.close if ExecuteNonQuery fails.
                Connection.Close();
                return " has Failed with " + e;
            }
        }

        //Delete statement doesnt work as it has FK's in another table
        public void DeleteCustomer(string ID)
        {

            var myCommand = new SqlCommand("DELETE FROM Customer where CustID = @ID", Connection);
            myCommand.Parameters.AddWithValue("ID", ID);
            Connection.Open();
            myCommand.ExecuteNonQuery();
            Connection.Close();


        }

        //Insert or Update Movie

        public string InsertOrUpdateMovie(string Rating, string Title, string Year, string Rental_Cost, string Copies, string Plot, string Genre, string Date, string ID, string AddOrUpdate)
        {
            try
            {
                //Add gets passed through the parameter
                if (AddOrUpdate == "Add")
                {
                    //Create a Command object  //Create a Query. Create and open a connection to SQL Server
                    string query = "INSERT INTO Movies (Rating, Title, Year, Rental_Cost, Copies, Plot, Genre, Date) " + "VALUES(@Rating, @Title, @Year, @Rental_Cost, @Copies, @Plot, @Genre, @Date)";


                    var myCommand = new SqlCommand(query, Connection);
                    //create params
                    myCommand.Parameters.AddWithValue("Rating", Rating);
                    myCommand.Parameters.AddWithValue("Title", Title);
                    myCommand.Parameters.AddWithValue("Year", Year);
                    myCommand.Parameters.AddWithValue("Rental_Cost", Rental_Cost);
                    myCommand.Parameters.AddWithValue("Copies", Copies);
                    myCommand.Parameters.AddWithValue("Plot", Plot);
                    myCommand.Parameters.AddWithValue("Genre", Genre);
                    myCommand.Parameters.AddWithValue("Date", Date);
                    Connection.Open();
                    // open connection add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();

                }
                //Update gets passed through the parameter
                else if (AddOrUpdate == "Update")
                {
                    var myCommand =
                        new SqlCommand(
                            "UPDATE Movies set Rating=@Rating, Title=@Title, Year=@Year, Rental_Cost= @Rental_Cost, Copies=@Copies, Plot=@Plot, Genre=@Genre, Date=@Date where MovieID = @ID ",
                            Connection);
                    //use parameters to prevent SQL injections
                    myCommand.Parameters.AddWithValue("Rating", Rating);
                    myCommand.Parameters.AddWithValue("Title", Title);
                    myCommand.Parameters.AddWithValue("Year", Year);
                    myCommand.Parameters.AddWithValue("Rental_Cost", Rental_Cost);
                    myCommand.Parameters.AddWithValue("Copies", Copies);
                    myCommand.Parameters.AddWithValue("Plot", Plot);
                    myCommand.Parameters.AddWithValue("Genre", Genre);
                    myCommand.Parameters.AddWithValue("Date", Date);
                    myCommand.Parameters.AddWithValue("ID", ID);
                    Connection.Open();
                    // open connection add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();
                }

                return " is Successful";
            }
            catch (Exception e)
            {
                //need to get it to close a second time as it jumps the first connection.close if ExecuteNonQuery fails.
                Connection.Close();
                return " has Failed with " + e;
            }
        }



        //Insert Rented Movie

        public string InsertRentedMovies(string MovieIDFK, string CustIDFK)
        {
            string DateRented = DateTime.Today.ToString();

            try
            {


                {
                    //Create a Command object  //Create a Query. Create and open a connection to SQL Server
                    string query = "INSERT INTO RentedMovies (MovieIDFK, CustIDFK, DateRented) " + "VALUES(@MovieIDFK, @CustIDFK, @DateRented)";


                    var myCommand = new SqlCommand(query, Connection);
                    //create params
                    myCommand.Parameters.AddWithValue("MovieIDFK", MovieIDFK);
                    myCommand.Parameters.AddWithValue("CustIDFK", CustIDFK);
                    myCommand.Parameters.AddWithValue("DateRented", DateRented);
                    Connection.Open();
                    // open connection add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();

                }


                return " is Successful";
            }
            catch (Exception e)
            {
                //need to get it to close a second time as it jumps the first connection.close if ExecuteNonQuery fails.
                Connection.Close();
                return " has Failed with " + e;
            }
        }


        //Return Rented Movie

        public string UpdateRentedMovies(string RMID)
        {
            string DateReturned = DateTime.Today.ToString();
            string DateRented = DateTime.Today.ToString();

            try
            {


                {
                    //Create a Command object  //Create a Query. Create and open a connection to SQL Server
                    var myCommand = new SqlCommand("UPDATE RentedMovies set   DateReturned= @DateReturned  where RMID=@RMID", Connection);


                    //create params
                    myCommand.Parameters.AddWithValue("RMID", RMID);

                    myCommand.Parameters.AddWithValue("DateReturned", DateReturned);
                    Connection.Open();
                    // open connection add in the SQL
                    myCommand.ExecuteNonQuery();
                    Connection.Close();

                }


                return " is Successful";
            }
            catch (Exception e)
            {
                //need to get it to close a second time as it jumps the first connection.close if ExecuteNonQuery fails.
                Connection.Close();
                return " has Failed with " + e;
            }
        }

        //Delete statement doesnt work as it has FK's in another table
        public void DeleteMovie(string ID)
        {

            var myCommand = new SqlCommand("DELETE FROM Movies where MovieID = @ID", Connection);
            myCommand.Parameters.AddWithValue("ID", ID);
            Connection.Open();
            myCommand.ExecuteNonQuery();
            Connection.Close();


        }



    }
}










