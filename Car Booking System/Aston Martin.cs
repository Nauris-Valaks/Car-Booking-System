using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Nauris Valaks 
// Version 1.0 15/05/2018
namespace Car_Booking_System
{
    public partial class Aston : Form
    {
        public Aston()
        {
            InitializeComponent();
        }
        private void Aston_Load(object sender, EventArgs e)
        {
            carList.DropDownStyle = ComboBoxStyle.DropDownList; //Sets the combo box style to a list so the user is not able to type in it
            // TODO: This line of code loads data into the 'dataSet1.tblBookingConfirmation' table. You can move, or remove it, as needed.
            this.tblBookingConfirmationTableAdapter2.Fill(this.dataSet1.tblBookingConfirmation);
            // TODO: This line of code loads data into the 'dataSet1.Customer_Info' table. You can move, or remove it, as needed.
            this.customer_InfoTableAdapter2.Fill(this.dataSet1.Customer_Info);

            try //try function which will try to run a line of code if it doesn't work then a catch will catch the error and display
            {
                this.carsTableAdapter.FillAston(this.projectDataSet.Cars);// Using the table cars from dataset to fill the Aston Martin combo box with Aston Martin models once the form loads

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message); // message box which will display an error if the try fucntion doesn't work
            }

        }



        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Visible = false; // Closes the current form
            (new Home()).Show(); // Shows the home form
        }

        private void btnJaguar_Click(object sender, EventArgs e)
        {
            this.Visible = false; // Closes the current form
            (new Jaguar()).Show(); // Shows the home form
        }

        private void btnLamb_Click(object sender, EventArgs e)
        {
            this.Visible = false; // Closes the current form
            (new Lamborghini()).Show(); // Shows the home form
        }

        private void btnFerrari_Click(object sender, EventArgs e)
        {
            this.Visible = false; // Closes the current form
            (new Ferrari()).Show(); // Shows the home form
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try // try function which will try to run the if and else statements. If an error happens catch will run instea displaying an error message
            {
                if (txtID.Text == String.Empty || txtName.Text == String.Empty || txtLast.Text == String.Empty || txtEmail.Text == String.Empty || txtAddress.Text == String.Empty)
                // If statement which checks each text box if it is empty
                {
                    MessageBox.Show("All Fields Required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Message box which will display if any of the text boxes are empty
                }

                else // else statement which will run instead of the if statment once all the requirements are met
                {
                    DataSet1TableAdapters.Customer_InfoTableAdapter customerTableAdapter = // Assigns the Custome_Info table adapter to customerTableAdapter
                            new DataSet1TableAdapters.Customer_InfoTableAdapter();

                    DataSet1TableAdapters.tblBookingConfirmationTableAdapter bookingTableAdapter = // Assigns the tblBookingConfirmation table adapter to bookingTableAdapter
                            new DataSet1TableAdapters.tblBookingConfirmationTableAdapter();

                    string Forename = txtName.Text; //Creates an instance variable for the text box Name
                    string Surname = txtLast.Text; //Creates an instance variable for the text box Last
                    string Email = txtEmail.Text; //Creates an instance variable for the text box Email
                    string Address = txtAddress.Text; //Creates an instance variable for the text box Address
                    string model = this.carList.GetItemText(this.carList.SelectedItem); // Assigns the selected combo box value to a string
                    int ID = Convert.ToInt32(txtID.Text); // Converts text into an int which is a requirement for the table

                    DateTime date = dtpDate.Value.Date; // DateTime function which allows the date to be used as a variable

                    customerTableAdapter.Insert(ID, Forename, Surname, Email, Address); // using the customerTableAdapter.Insert function which inserts into the corresponding table inside the database
                    bookingTableAdapter.Insert(ID, model, date); // using the bookingTableAdapter.Insert function which inserts values into the corresponding table

                    MessageBox.Show("Thank you for booking a car with us!"); // Message box which will display once the booking is saved

                }
            }
            catch (Exception ex) // Catch which will catch any errors from the if else statments
            {
                MessageBox.Show("Customer ID already exists. Enter a different ID please."); // error message which will display once an error is catched
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, "[^0-9]")) // formats the ID text box to only accept numbers
            {
                MessageBox.Show("Please enter only numbers."); // Message box which will display if any other characters are entered
                txtID.Text = txtID.Text.Remove(txtID.Text.Length - 1); // removes the entered character
            }
        }
    }
}
