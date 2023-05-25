using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MFramework.Services.FakeData;
using System.IO;
using System.Threading;

namespace Oil_And_Fuel_Stock_Tracking_System
{
    public class DataGenerator
    {
        public double FakeFillingGenerator()
        {
            Random random = new Random();
            return NumberData.GetDouble();
        }

        public void StartFilling(int target)
        {           
            DataTable dt = new DataTable();
            dt.Columns.Add("");
        }

    }
}
