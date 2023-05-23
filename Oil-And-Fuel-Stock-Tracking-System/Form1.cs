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

namespace Oil_And_Fuel_Stock_Tracking_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataGenerator dataGenerator = new DataGenerator();
        public SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OilAndFuelStockDB; Integrated Security = True");
         
       public void PriceList()
        {
            //FuelSave Gasoline
            sqlConnection.Open();
            SqlCommand cmdFSGasoline = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='FuelSave Gasoline'", sqlConnection); 
            SqlDataReader drFSGasoline = cmdFSGasoline.ExecuteReader();

            while (drFSGasoline.Read())
            {
                LblFSGasoline.Text = drFSGasoline[3].ToString();
                PbFSGasoline.Value = int.Parse(drFSGasoline[4].ToString());
                LblPBFSG.Text = drFSGasoline[4].ToString() + " LT";
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand cmdVPGasoline = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='V-Power Gasoline'", sqlConnection);
            SqlDataReader drVPGasoline = cmdVPGasoline.ExecuteReader();

            while (drVPGasoline.Read())
            {
                LblVPGasoline.Text = drVPGasoline[3].ToString();
                PbVPGasoline.Value = int.Parse(drVPGasoline[4].ToString());
                LblPBVPG.Text = drVPGasoline[4].ToString() + " LT";
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand cmdFSDiesel = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='FuelSave Diesel'", sqlConnection);
            SqlDataReader drFSDiesel = cmdFSDiesel.ExecuteReader();

            while (drFSDiesel.Read())
            {
                LblFSDiesel.Text = drFSDiesel[3].ToString();
                PbFSDiesel.Value = int.Parse(drFSDiesel[4].ToString());
                LblPBFSD.Text = drFSDiesel[4].ToString() + " LT";
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand cmdVPDiesel = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='V-Power Diesel'", sqlConnection);
            SqlDataReader drVPDiesel = cmdVPDiesel.ExecuteReader();

            while (drVPDiesel.Read())
            {
                LblVPDiesel.Text = drVPDiesel[3].ToString();
                PbVPDiesel.Value = int.Parse(drVPDiesel[4].ToString());
                LblPBVPD.Text = drVPDiesel[4].ToString() + " LT";
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand cmdAutogas = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='Autogas LPG'", sqlConnection);
            SqlDataReader drAutogas = cmdAutogas.ExecuteReader();

            while (drAutogas.Read())
            {
                LblLPG.Text = drAutogas[3].ToString();
                PbLPG.Value = int.Parse(drAutogas[4].ToString());
                LblPBLPG.Text = drAutogas[4].ToString() + " LT";
            }

            sqlConnection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            { 
                PriceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
