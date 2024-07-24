using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College
{
    internal class Collegemeneger
    {
        public static List<string> getcourses()
        {
            string sql = "select * from Courses";

            SqlDataReader reader = Dbconnection.RunSQLAllResults(sql);

            List<string> courses = new List<string>(); //[reader.GetSchemaTable().Rows.Count];

            for (int i = 0; reader.Read(); i++)
            {
                courses.Add(reader.GetString(1));
            }
            reader.Close();

            return courses;
        }

        public static DataTable getbycategory(string cours)
        {
            string sql = "\r\n SELECT \r\n    c.days_in_week,\r\n    c.course_price,\r\n    s.subject_name,\r\n\ts.subject_hours,\r\n    l.lecturer_name,\r\n    l.lecturer_selelry,\r\n    COUNT(DISTINCT lt.student_id) AS 'Registered students'\r\n    --SUM(p.payment) AS total_payments\r\nFROM \r\n    Courses c\r\nLEFT JOIN Subjects s ON c.cuorse_id = s.subject_cours\r\nLEFT JOIN lecturers l ON s.subject_lecturers = l.lecturer_id\r\nLEFT JOIN linking_table lt ON c.cuorse_id = lt.cours\r\nLEFT JOIN Payments p ON lt.student_id = p.student_id\r\nWHERE \r\n    c.cuorse_name =  @name \r\nGROUP BY \r\n   c.days_in_week, c.course_price,\r\n    s.subject_id, s.subject_hours,\r\n    l.lecturer_id, l.lecturer_name, l.lecturer_selelry,s.subject_name";

            string[] parameters = { "@name" };
            string[] values = { cours };
            //SqlDataReader reader = Dbconnaction.RunSQLAllResults(sql, parameters, values );
            //DataTable dataTable = new DataTable();
            //dataTable.Load(reader);
            DataTable dataTable = Dbconnection.SRunSQLAllResults2(sql, parameters, values);
            return dataTable;

        }
        public static List<string> search(string char1)
        {
            string sql = "select cuorse_name from Courses where cuorse_name like  @Search + '%'\r\n";
            string[] parameters = { "@Search" };
            string[] values = { char1 };
            SqlDataReader reader = Dbconnection.RunSQLAllResults(sql, parameters, values);

            List<string> categories = new List<string>();
            while (reader.Read())
            {
                categories.Add(reader.GetString(0));
            }
            reader.Close();
            return categories;
        }
        public static void addcourse(string word, string houers, string price)
        {
            string sql = "insert into Courses values (@course,@houers,@price )\r\n\t";
            string[] parameters = { "@course", "@houers" , "@price" };
            string[] values = { word, houers, price };
            Dbconnection.RunSQLvoid(sql, parameters, values);
        }

        public static void addlecturer(string name,string selery)
        {
            string sql = "insert into lecturers values (@name, @selery)\r\n\t";
            string[] parameters = { "@name" , "@selery" };
            string[] values = { name , selery};
            Dbconnection.RunSQLvoid(sql, parameters, values);
        }

        public static void addsubject(string l_name, string c_name, string subject, string houers )
        {
            string sql = "declare @lecturers_id int, @cours_id int \r\n\r\n select @lecturers_id = (select lecturer_id from lecturers where lecturer_name = @l_name )\r\n select @cours_id = (select cuorse_id from Courses where cuorse_name = @c_name)\r\n insert into Subjects values (@name, @lecturers_id, @cours_id, @hours)";
            string[] parameters = { "@l_name", "@c_name", "@name", "@hours" };
            string[] values = { l_name, c_name, subject, houers };
            Dbconnection.RunSQLvoid(sql, parameters, values);
        }
    }
}
