using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace qlsv_nhom2
{

   public class truyxuat
    {

            public static string con = @"Data Source=DESKTOP-A6SQ2DP\SQLEXPRESS2008;Initial Catalog=qlsv;Integrated Security=True";
            public static DataTable laybang(string sql)
            {
                SqlConnection ketnoi = new SqlConnection(con);
                ketnoi.Open();
                SqlDataAdapter ad = new SqlDataAdapter(sql, ketnoi);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                ketnoi.Close();
                return dt;
            }
            public static void thaotac(string sql)
            {

                SqlConnection ketnoi = new SqlConnection(con);
                ketnoi.Open();
                SqlCommand cm = new SqlCommand(sql, ketnoi);
                cm.ExecuteNonQuery();
                ketnoi.Close();

            }
        }

    }
