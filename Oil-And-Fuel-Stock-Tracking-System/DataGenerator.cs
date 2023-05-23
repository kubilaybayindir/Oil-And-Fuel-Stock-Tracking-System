using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MFramework.Services.FakeData;

namespace Oil_And_Fuel_Stock_Tracking_System
{
    public class DataGenerator
    {
        
        public double FakeFillingGenerator()
        {

            Random random = new Random();

            return NumberData.GetDouble();

        }
    }
}
