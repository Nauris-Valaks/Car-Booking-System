using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Nauris Valaks 
// Version 1.0 15/05/2018

namespace Car_Booking_System
{
    public partial class Jaguar : Form
    {
        public Jaguar()
        {
            InitializeComponent();
        }
        private void Jaguar_Load(object sender, EventArgs e)
        {
            carList.DropDownStyle = ComboBoxStyle.DropDownList; //Sets the combo box style to a list so the user is not able to type in it
            // TODO: This line of code loads data into the 'dataSet1.tblBookingConfirmation' table. You can move, or remove it, as needed.
            this.tblBookingConfirmationTableAdapter1.Fill(this.dataSet1.tblBookingConfirmation);
            // TODO: This line of code loads data into the 'dataSet1.Customer_Info' table. You can move, or remove it, as needed.
            this.customer_InfoTableAdapter2.Fill(this.dataSet1.Customer_Info);

            try
            {
                this.carsTableAdapter.FillJJaguar(this.projectDataSet.Cars); // Using the table cars from dataset to fill the jaguar combo box with jaguar models once the form loads
            }
            catch (System.Exception ex) // catches an exception if the try doens't work and displays a message with the error message inside
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            this.Visible = false; // Closes the current form
            (new Home()).Show(); // Shows the home form
        }

        private void btnLamb_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;  // Closes the current form
            (new Lamborghini()).Show(); //Shows the lamborghini form
        }

        private void btnAston_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;  // Closes the current form
            (new Aston()).Show(); //Shows the aston form
        }

        private void btnFerrari_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;  // Closes the current form
            (new Ferrari()).Show(); //Shows the ferrari form
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            { // using the try catch method to catch an error for an if else statement
                if (txtID.Text == String.Empty || txtName.Text == String.Empty || txtLast.Text == String.Empty || txtEmail.Text == String.Empty || txtAddress.Text == String.Empty) // checks if all of the text boxes are empty, if they are empty
                // then a message box fill display 
                {
                    MessageBox.Show("All Fields Required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); // message box displays with an error message
                }

                else
                {
                    DataSet1TableAdapters.Customer_InfoTableAdapter customerTableAdapter =
                    new DataSet1TableAdapters.Customer_InfoTableAdapter(); //assigns the Customer_Info table adapter to customerTableAdapter

                    DataSet1TableAdapters.tblBookingConfirmationTableAdapter bookingTableAdapter =
                    new DataSet1TableAdapters.tblBookingConfirmationTableAdapter(); //assigns the tblBookingConfirmation table adapter to bookingTableAdapter

                    string Forename = txtName.Text; //assigns the text box to a string which is then used for inserting into table
                    string Surname = txtLast.Text; //assigns the text box to a string which is then used for inserting into table
                    string Email = txtEmail.Text; //assigns the text box to a string which is then used for inserting into table
                    string Address = txtAddress.Text; //assigns the text box to a string which is then used for inserting into table
                    string model = this.carList.GetItemText(this.carList.SelectedItem); //assigns the text box to a string which is then used for inserting into table
                    int ID = Convert.ToInt32(txtID.Text); //Coverts text box into an intiger due to it being a number in the database

                    DateTime date = dtpDate.Value.Date; // Assigns the dtpDate value to date which is used for inserting the date

                    customerTableAdapter.Insert(ID, Forename, Surname, Email, Address); // inserts values inside the Customer info table
                    bookingTableAdapter.Insert(ID, model, date);  // inserts values into booking table

                    MessageBox.Show("Thank you for booking a car with us!"); // Message box which will display the customer message

                }
            }
            catch (Exception ex) // catches the error thrown and displays an error message after
            {
                MessageBox.Show("Customer ID already exists. Enter a different ID please."); // displays a message
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, "[^0-9]")) // formats text box to accept only numbers
            {
                MessageBox.Show("Please enter only numbers."); // displays a message box
                txtID.Text = txtID.Text.Remove(txtID.Text.Length - 1); // removes the entered character
            }
        }
    }
}
