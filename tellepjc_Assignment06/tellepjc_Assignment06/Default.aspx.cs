/**
 * Connor Tellep and Danny Kroeger
 * Assignment 06
 * IT3047 Web Server App Dev
 * 3/2/2017
 * */

/* Hello from Bill */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tellepjc_Assignment06
{
    public partial class Default : System.Web.UI.Page
    {
        //declares all of the objects we will need to interact with the database
        //they're static because we only want one connection to the database regardless of the amount of clients
        private static System.Data.SqlClient.SqlConnection conn;
        private static SqlCommand comm;
        private static SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // We will open the connection one time and leave it open.
                OpenConnection();
                // We will populate the dropdown menus once as their contents don't change often
                PopulateDropdowns();
                // sets the calendar to todays date, only will run on the first page load event.
                this.calDateOfTransaction.SelectedDate = DateTime.Today;
            }
        }

        /**
         * Method to open database connection
         * */
        private void OpenConnection()
        {
            //creates a configuration setting object for the connection string
            System.Configuration.ConnectionStringSettings strConn;
            //sets the value of the connections setting object to the connection string
            strConn = ReadConnectionString();

            //initializes the connection object with the value of our connection string
            conn = new System.Data.SqlClient.SqlConnection(strConn.ConnectionString);

            
            // This could go wrong in so many ways...
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                // Miserable error handling...
                Response.Write(ex.Message);
            }
        }

        /**
         * Returns a settings object that holds the connection string for the database
         */
        private System.Configuration.ConnectionStringSettings ReadConnectionString()
        {
            //string to store the path so the web.config file
            String strPath;
            strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";

            //creates an object that points to the web.config file
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

            System.Configuration.ConnectionStringSettings connString = null;

            //if the connection string is present, sets the object to equal the connection string in the web.config file
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulator"];
            }

            //returns our connection string settings object
            return connString;
        }

        /**
         * Method to populate all of the dropdown menus
         * */
        private void PopulateDropdowns()
        {
            //calls the method of each respective dropdown menu
            PopulateLoyaltyList();
            PopulateTransactionTypeList();
            PopulateStoreList();
            PopulateEmployeeList();
            PopulateProductList();
        }

        /**
         * Populates loyalty number dropdown menu with information retrieved from the database
         * */
        private void PopulateLoyaltyList()
        {
            //variables to hold the data returned by the query and add it to the dropdown menu
            int loyaltyID;
            string loyaltyNumber;
            ListItem loyaltyItem;

            // Clear the list box, in case we've already loaded something into it.
            ddlLoyaltyID.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT LoyaltyID, LoyaltyNumber FROM tLoyalty", conn);
            //try to close the reader in case it's stil open, do nothing if we can't
            try
            {
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            
            //use the reader object to execute our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the loyalty account
                loyaltyID = reader.GetInt32(0);
                //stores the number of the loyalty account
                loyaltyNumber = reader.GetString(1);
                //creates a list item with the text of the name of the loyalty account, and the value of the primary key of the loyalty account
                loyaltyItem = new ListItem(loyaltyNumber, loyaltyID.ToString());
                //adds the item to the dropdown menu
                ddlLoyaltyID.Items.Add(loyaltyItem);
            }
        }

        /**
         * Populates the transaction type dropdown list with data retrieved from the database
         * */
        private void PopulateTransactionTypeList()
        {
            
            //variables to hold the data returned by the query and add it to the dropdown menu
            int transactionTypeID;
            string transactionType;
            ListItem transactionTypeItem;

            // Clear the list box, in case we've already loaded something into it.
            ddlTransactionTypeID.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT TransactionTypeID, TransactionType FROM tTransactionType", conn);
            //try to close the reader in case it's stil open, do nothing if we can't
            try
            {
                reader.Close();
            }
            catch (Exception ex)
            {
            }

            //use the reader object to execute our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the transaction type
                transactionTypeID = reader.GetInt32(0);
                //stores the name of the transaction type
                transactionType = reader.GetString(1);
                //creates a list item with the text of the name of the transaction type, and the value of the primary key of the transaction type
                transactionTypeItem = new ListItem(transactionType, transactionTypeID.ToString());
                //adds the item to the dropdown menu
                ddlTransactionTypeID.Items.Add(transactionTypeItem);
            }

        }

        /**
         * Populates the product dropdown list with data retrieed from the database
         * */
        private void PopulateProductList()
        {
            
            //variables to hold the data returned by the query and add it to the dropdown menu
            int productID;
            string product;
            ListItem productItem;

            // Clear the list box, in case we've already loaded something into it.
            ddlProductID.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT ProductID, Description FROM tProduct", conn);
            //try to close the reader in case it's stil open, do nothing if we can't
            try
            {
                reader.Close();
            }
            catch (Exception ex)
            {
            }

            //use the reader object to execute our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the product
                productID = reader.GetInt32(0);
                //stores the name of the product
                product = reader.GetString(1);
                //creates a list item with the text of the name of the product, and the value of the primary key of the product
                productItem = new ListItem(product, productID.ToString());
                //adds the item to the dropdown menu
                ddlProductID.Items.Add(productItem);
            }
            
        }

        /**
         * Populates the employee dropdown list with data retrieved from the database
         * */
        private void PopulateEmployeeList()
        {
            
            //variables to hold the data returned by the query and add it to the dropdown menu
            int emplID;
            string employeeFirstName;
            string employeeLastName;
            ListItem emplItem;

            // Clear the list box, in case we've already loaded something into it.
            ddlEmplID.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT emplID, FirstName, LastName FROM tEmpl", conn);
            //try to close the reader in case it's stil open, do nothing if we can't
            try
            {
                reader.Close();
            }
            catch (Exception ex)
            {
            }

            //use the reader object to execute our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the employee
                emplID = reader.GetInt32(0);
                //stores the name of the employee
                employeeFirstName = reader.GetString(1);
                employeeLastName = reader.GetString(2);
                string empl = employeeFirstName + " " + employeeLastName;
                //creates a list item with the text of the name of the employee, and the value of the primary key of the employee
                emplItem = new ListItem(empl, emplID.ToString());
                //adds the item to the dropdown menu
                ddlEmplID.Items.Add(emplItem);
            }
            
        }

        /**
         * Populates the store dropdown list with data retrieved from the database
         * */
        private void PopulateStoreList()
        {
            //variables to hold the data returned by the query and add it to the dropdown menu
            int storeID;
            string store;
            ListItem storeItem;

            // Clear the list box, in case we've already loaded something into it.
            ddlStoreID.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT StoreID, Store FROM tStore", conn);
            //try to close the reader in case it's stil open, do nothing if we can't
            try
            {
                reader.Close();
            }
            catch (Exception ex)
            {
            }

            //use the reader object to execute our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the store
                storeID = reader.GetInt32(0);
                //stores the name of the store
                store = reader.GetString(1);
                //creates a list item with the text of the name of the store, and the value of the primary key of the store
                storeItem = new ListItem(store, storeID.ToString());
                //adds the item to the dropdown menu
                ddlStoreID.Items.Add(storeItem);
            }
        }

        /**
         * Retrieves data from the web form
         * Passes the data to and executes the stored procedure spAddTransactionAndDetail
         * */
        private void ExecuteStoredProcedure()
        {
            //create sqlcommand with the name of the stored procedure and our open connection
            comm = new SqlCommand("dbo.spAddTransactionAndDetail", conn);
            //set the command type to StoredProcedure
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            //get the date and format it
            string strDate = calDateOfTransaction.SelectedDate.Date.ToString();
            strDate = strDate.Substring(0, 9);
            strDate = strDate.Trim();

            //add parameters to the SqlCommand for the stored procedure
            comm.Parameters.Add("@LoyaltyID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(ddlLoyaltyID.SelectedValue);
            comm.Parameters.Add("@DateOfTransaction", System.Data.SqlDbType.VarChar).Value = strDate;
            comm.Parameters.Add("@TimeOfTransaction", System.Data.SqlDbType.VarChar).Value = tbxTimeOfTransaction.Text.Trim();
            comm.Parameters.Add("@TransactionTypeID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(ddlTransactionTypeID.SelectedValue);
            comm.Parameters.Add("@StoreID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(ddlStoreID.SelectedValue);
            comm.Parameters.Add("@EmplID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(ddlEmplID.SelectedValue);
            comm.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(ddlProductID.SelectedValue);
            comm.Parameters.Add("@PricePerSellableUnitAsMarked", System.Data.SqlDbType.VarChar).Value = PricePerSellableUnitMarked(Convert.ToInt32(ddlProductID.SelectedValue));
            comm.Parameters.Add("@PricePerSellableUnitToTheCustomer", System.Data.SqlDbType.VarChar).Value = tbxPricePerSellableUnitToTheCustomer.Text;
            comm.Parameters.Add("@TransactionComment", System.Data.SqlDbType.VarChar).Value = tbxTransactionComment.Text + "_tellepjc_kroegedl";
            comm.Parameters.Add("@TransactionDetailComment", System.Data.SqlDbType.VarChar).Value = tbxtransactionDetailComment.Text + "_tellepjc_kroegedl";
            comm.Parameters.Add("@couponDetailID", System.Data.SqlDbType.Int).Value = 1;
            comm.Parameters.Add("@TransactionID", System.Data.SqlDbType.Int).Value = 1;

            //if the qty text box isn't empty
            if (tbxQty.Text.Length > 0)
            {
                comm.Parameters.Add("@Qty", System.Data.SqlDbType.Int).Value = Convert.ToInt32(tbxQty.Text);
            }
            //if the qty text box is empty, send a qty of 0
            else
            {
                comm.Parameters.Add("@Qty", System.Data.SqlDbType.Int).Value = 0;
            }

            //try to close the reader object, do nothing if we can't
            try
            {
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            //execute the stored procedure
            comm.ExecuteNonQuery();
        }

        /**
         * Retreives the marked price for the product that has been selected in the web form
         * */
        private string PricePerSellableUnitMarked(int productID)
        {
            //variable to hold the data returned by the query
            string price;

            // create sql command object with the open connection object
            SqlCommand cmd = new SqlCommand("SELECT InitialPricePerSellableUnit FROM tProduct WHERE ProductID = " + productID, conn);
            //try to close the reader in case it's stil open, do nothing if we can't
            try
            {
                reader.Close();
            }
            catch (Exception ex)
            {
            }

            //use the reader object to execute our query
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                //move cursor to the record
                reader.Read();

                //stores the price
                price = Convert.ToString(reader.GetSqlValue(0));
            }
            //if there's no rows, returns a price of zero
            else
            {
                price = "0.00";
            }

            //returns the price
            return price;
        }

        /**
         * Click event handler for the submit button
         * Executes the stored procedure spAddTransactionAndDetail
         * */
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //calls method to execute the stored procedure
            ExecuteStoredProcedure();
        }
    }
}