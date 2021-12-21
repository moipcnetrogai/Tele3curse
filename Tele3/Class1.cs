using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace Tele3
{
    class Connection
    {
        static string connect = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user32_db;user id=user32_db;password=user32;MultipleActiveResultSets=True;App=EntityFramework";
        public static SqlConnection MyConnection = new SqlConnection(@connect);
        public static int On(int x)
        {
            try { MyConnection.Open(); }
            catch (System.Data.SqlClient.SqlException) { return x = 1; }
            return x = 0;
        }
        public static void Off()
        {
            MyConnection.Close();
        }
    }
    class myclass
    {
        public static string number { get; set; }
        public static bool password_set { get; set; }
        public static int CurrentUser { get; set; }
    }

}
