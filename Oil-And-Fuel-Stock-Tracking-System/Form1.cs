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
using System.IO;
using System.Globalization;

namespace Oil_And_Fuel_Stock_Tracking_System
{
    public partial class Form1 : Form
    {

        public SqlConnection sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OilAndFuelStockDB; Integrated Security = True");
        public int FakeFillSt1Cnt = 0;
        private bool isFinish = false;

        public Form1()
        {
            InitializeComponent();
            
        }
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
                LblPBFSG.Text = drFSGasoline[4].ToString();
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand cmdVPGasoline = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='V-Power Gasoline'", sqlConnection);
            SqlDataReader drVPGasoline = cmdVPGasoline.ExecuteReader();

            while (drVPGasoline.Read())
            {
                LblVPGasoline.Text = drVPGasoline[3].ToString();
                PbVPGasoline.Value = int.Parse(drVPGasoline[4].ToString());
                LblPBVPG.Text = drVPGasoline[4].ToString();
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand cmdFSDiesel = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='FuelSave Diesel'", sqlConnection);
            SqlDataReader drFSDiesel = cmdFSDiesel.ExecuteReader();

            while (drFSDiesel.Read())
            {
                LblFSDiesel.Text = drFSDiesel[3].ToString();
                PbFSDiesel.Value = int.Parse(drFSDiesel[4].ToString());
                LblPBFSD.Text = drFSDiesel[4].ToString();
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand cmdVPDiesel = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='V-Power Diesel'", sqlConnection);
            SqlDataReader drVPDiesel = cmdVPDiesel.ExecuteReader();

            while (drVPDiesel.Read())
            {
                LblVPDiesel.Text = drVPDiesel[3].ToString();
                PbVPDiesel.Value = int.Parse(drVPDiesel[4].ToString());
                LblPBVPD.Text = drVPDiesel[4].ToString();
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand cmdAutogas = new SqlCommand("SELECT * FROM GasolineTable WHERE OilType='Autogas LPG'", sqlConnection);
            SqlDataReader drAutogas = cmdAutogas.ExecuteReader();

            while (drAutogas.Read())
            {
                LblLPG.Text = drAutogas[3].ToString();
                PbLPG.Value = int.Parse(drAutogas[4].ToString());
                LblPBLPG.Text = drAutogas[4].ToString();
            }
            sqlConnection.Close();
        }
        public void CbxOilTypeFill(ComboBox comboBox)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT GasolineId,OilType FROM GasolineTable", sqlConnection);
            sqlDataAdapter.Fill(dataTable);
            comboBox.ValueMember = "GasolineId";
            comboBox.DisplayMember = "OilType";
            comboBox.DataSource = dataTable;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            { 
                PriceList();
                CbxOilTypeFill(CbxOilType);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtGetRecord_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ActionTable", sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            DgvActionRecords.DataSource = dataTable;
            sqlConnection.Close();
        }

        #region STATION 1

        #endregion

        private void FillingTimer_Tick(object sender, EventArgs e)
        {
            FakeFillSt1Cnt++;
            LblSt1Liter.Text= FakeFillSt1Cnt.ToString();

            if (FakeFillSt1Cnt >= Convert.ToDecimal(CbxLiter.SelectedItem.ToString()))
            {
                if (!isFinish)
                {
                    Insert();
                    isFinish = true;
                    FillingTimer.Stop();
                    FillingTimer.Enabled = false;
                    FakeFillSt1Cnt = 0;
                }
            }
        }

        public bool Insert()
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO ActionTable(NumberPlate,OilType,Liter,Payment,StationNo) VALUES (@p1,@p2,@p3,@p4,@p5)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@p1", TbxNumberPlate.Text.ToUpper());
                sqlCommand.Parameters.AddWithValue("@p2", CbxOilType.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@p3", Convert.ToDecimal(CbxLiter.SelectedItem.ToString()));
                sqlCommand.Parameters.AddWithValue("@p4", Convert.ToDecimal(Convert.ToDecimal(CbxLiter.SelectedItem.ToString()) * 5));
                sqlCommand.Parameters.AddWithValue("@p5", int.Parse(CbxStation.SelectedItem.ToString()));
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void BtFillTheTank_Click(object sender, EventArgs e)
        {
            FillingTimer.Enabled = true;
            FillingTimer.Start();
        }
    }
}
