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
            PopulateCouponList();
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
            /*
            //variables to hold the data returned by the query and add it to the dropdown menu
            int modelID;
            string model;
            ListItem modelItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT * FROM tRobo", conn);
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
                modelID = reader.GetInt32(0);
                //stores the name of the model
                model = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                modelItem = new ListItem(model, modelID.ToString());
                //adds the item to the dropdown menu
                //drpModel.Items.Add(modelItem);
            }
            */
        }

        private void PopulateStoreList()
        {
            /*
            //variables to hold the data returned by the query and add it to the dropdown menu
            int modelID;
            string model;
            ListItem modelItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT * FROM tRobo", conn);
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
                modelID = reader.GetInt32(0);
                //stores the name of the model
                model = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                modelItem = new ListItem(model, modelID.ToString());
                //adds the item to the dropdown menu
                //drpModel.Items.Add(modelItem);
            }
            */
        }

        private void PopulateEmployeeList()
        {
            /*
            //variables to hold the data returned by the query and add it to the dropdown menu
            int modelID;
            string model;
            ListItem modelItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT * FROM tRobo", conn);
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
                modelID = reader.GetInt32(0);
                //stores the name of the model
                model = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                modelItem = new ListItem(model, modelID.ToString());
                //adds the item to the dropdown menu
                //drpModel.Items.Add(modelItem);
            }
            */
        }

        private void PopulateProductList()
        {
            /*
            //variables to hold the data returned by the query and add it to the dropdown menu
            int modelID;
            string model;
            ListItem modelItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT * FROM tRobo", conn);
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
                modelID = reader.GetInt32(0);
                //stores the name of the model
                model = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                modelItem = new ListItem(model, modelID.ToString());
                //adds the item to the dropdown menu
                //drpModel.Items.Add(modelItem);
            }
            */
        }

        private void PopulateCouponList()
        {
            /*
            //variables to hold the data returned by the query and add it to the dropdown menu
            int modelID;
            string model;
            ListItem modelItem;

            // Clear the list box, in case we've already loaded something into it.
            //drpModel.Items.Clear();
            // create sql command object with the open connection object
            comm = new SqlCommand("SELECT * FROM tRobo", conn);
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
                modelID = reader.GetInt32(0);
                //stores the name of the model
                model = reader.GetString(1);
                //creates a list item with the text of the name of the model, and the value of the primary key of the model
                modelItem = new ListItem(model, modelID.ToString());
                //adds the item to the dropdown menu
                //drpModel.Items.Add(modelItem);
            }
            */
        }
    }
}