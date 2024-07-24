using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orderingfood
{
    internal class Hostmeneger
    {
        public static List<string> getcategory() 
        {
            string sql = "select * from categories";

            SqlDataReader reader = Dbconnaction.RunSQLAllResults(sql);

            List<string> catgories = new List<string>(); //[reader.GetSchemaTable().Rows.Count];
        
            for (int i = 0; reader.Read(); i++)
            {
                catgories.Add(reader.GetString(1));
            }
            reader.Close();

            return catgories;
        }

        public static DataTable getbycategory(string category)
        {
            string sql = @"select guest_name,catgory_name, itam_name, count(itam_name) as 'מספר הזמנות' 
                            from itams
                            join guests on itams.guest_code = guests.guest_code
                            join categories on itams.catgory_code = categories.code
                            where categories.catgory_name = @name
                            group by itam_name, guest_name, catgory_name
                            order by guest_name";

            string[] parameters = { "@name" };
            string[] values = { category };
            //SqlDataReader reader = Dbconnaction.RunSQLAllResults(sql, parameters, values );
            //DataTable dataTable = new DataTable();
            //dataTable.Load(reader);
            DataTable dataTable = Dbconnaction.SRunSQLAllResults2(sql, parameters, values);
            return dataTable;

        }

        public static List<string> search(string char1)
        {
            string sql = "select catgory_name from categories where catgory_name like  @Search + '%'\r\n";
            string[] parameters = { "@Search" };
            string[] values = { char1};
            SqlDataReader reader = Dbconnaction.RunSQLAllResults(sql, parameters, values);

            List<string> categories = new List<string>();
            while (reader.Read())
            {
                categories.Add(reader.GetString(0));
            }
            reader.Close();
            return categories;
        }

        public static void addcatgory(string word)
        {
            string sql = "insert into categories values (@category)\r\n\t";
            string[] parameters = { "@category" };
            string[] values = { word };
            Dbconnaction.RunSQLvoid(sql, parameters, values);
        }
        public static void removecatgory(string word)
        {
            string sql = "DELETE FROM categories \r\nWHERE catgory_name = @category;\r\n";
            string[] parameters = { "@category" };
            string[] values = { word };
            Dbconnaction.RunSQLvoid(sql, parameters, values);

        }
    }
}
