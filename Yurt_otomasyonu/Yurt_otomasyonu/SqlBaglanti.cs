using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Yurt_otomasyonu
{
   public class SqlBaglanti
    {
        public SqlConnection baglan()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Yurtkayit;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
