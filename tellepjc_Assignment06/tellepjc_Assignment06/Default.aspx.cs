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

        private void PopulateDropdowns()
        {
            PopulateLoyaltyList();
            PopulateTransactionTypeList();
            PopulateStoreList();
            PopulateEmployeeList();
            PopulateProductList();
        }

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
            
            //use the reader object to execuet our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the model
                loyaltyID = reader.GetInt32(0);
                //stores the name of the model
                loyaltyNumber = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                loyaltyItem = new ListItem(loyaltyNumber, loyaltyID.ToString());
                //adds the item to the dropdown menu
                ddlLoyaltyID.Items.Add(loyaltyItem);
            }
        }

        private void PopulateTransactionTypeList()
        {
            
            //variables to hold the data returned by the query and add it to the dropdown menu
            int transactionTypeID;
            string transactionType;
            ListItem transactionTypeItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
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

            //use the reader object to execuet our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the model
                transactionTypeID = reader.GetInt32(0);
                //stores the name of the model
                transactionType = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                transactionTypeItem = new ListItem(transactionType, transactionTypeID.ToString());
                //adds the item to the dropdown menu
                ddlTransactionTypeID.Items.Add(transactionTypeItem);
            }

        }

        private void PopulateProductList()
        {
            
            //variables to hold the data returned by the query and add it to the dropdown menu
            int productID;
            string product;
            ListItem productItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
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

            //use the reader object to execuet our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the model
                productID = reader.GetInt32(0);
                //stores the name of the model
                product = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                productItem = new ListItem(product, productID.ToString());
                //adds the item to the dropdown menu
                ddlProductID.Items.Add(productItem);
            }
            
        }

        private void PopulateEmployeeList()
        {
            
            //variables to hold the data returned by the query and add it to the dropdown menu
            int emplID;
            string employeeFirstName;
            string employeeLastName;
            ListItem emplItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
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

            //use the reader object to execuet our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the model
                emplID = reader.GetInt32(0);
                //stores the name of the model
                employeeFirstName = reader.GetString(1);
                employeeLastName = reader.GetString(2);
                string empl = employeeFirstName + " " + employeeLastName;
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                emplItem = new ListItem(empl, emplID.ToString());
                //adds the item to the dropdown menu
                ddlEmplID.Items.Add(emplItem);
            }
            
        }

        private void PopulateStoreList()
        {
            //variables to hold the data returned by the query and add it to the dropdown menu
            int storeID;
            string store;
            ListItem storeItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
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

            //use the reader object to execuet our query
            reader = comm.ExecuteReader();

            //iterate through the dataset line by line
            while (reader.Read())
            {
                //stores the primary key of the model
                storeID = reader.GetInt32(0);
                //stores the name of the model
                store = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                storeItem = new ListItem(store, storeID.ToString());
                //adds the item to the dropdown menu
                //drpModel.Items.Add(modelItem);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            comm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter loyaltyID = new SqlParameter("@LoyaltyID", Convert.ToInt32(ddlLoyaltyID.SelectedValue));
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.Int32;
            comm.Parameters.Add(loyaltyID);

            SqlParameter date = new SqlParameter("@DateOfTransaction", calDateOfTransaction.SelectedDate);
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.Date;
            comm.Parameters.Add(loyaltyID);

            SqlParameter time = new SqlParameter("@TimeOfTransaction", tbxTimeOfTransaction.Text);
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.String;
            comm.Parameters.Add(time);

            SqlParameter TransactionTypeID = new SqlParameter("@TransactionTypeID", Convert.ToInt32(ddlTransactionTypeID.SelectedValue));
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.Int32;
            comm.Parameters.Add(TransactionTypeID);

            SqlParameter storeID = new SqlParameter("@StoreID", Convert.ToInt32(ddlStoreID.SelectedValue));
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.Int32;
            comm.Parameters.Add(storeID);

            SqlParameter emplID = new SqlParameter("@EmplID", Convert.ToInt32(ddlEmplID.SelectedValue));
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.Int32;
            comm.Parameters.Add(emplID);

            SqlParameter productID = new SqlParameter("@ProductID", Convert.ToInt32(ddlProductID.SelectedValue));
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.Int32;
            comm.Parameters.Add(productID);

            SqlParameter qty = new SqlParameter("@Qty", Convert.ToInt32(tbxQty.Text));
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.Int32;
            comm.Parameters.Add(qty);

            SqlParameter price = new SqlParameter("@LoyaltyID", Convert.ToInt32(ddlLoyaltyID.SelectedValue));
            loyaltyID.Direction = System.Data.ParameterDirection.Input;
            loyaltyID.DbType = System.Data.DbType.String;
            comm.Parameters.Add(loyaltyID);
        }

        private string PricePerSellableUnitMarked(int productID)
        {
            return "";
        }
    }
}