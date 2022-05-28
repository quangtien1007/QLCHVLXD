using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.NewFolder1
{
    public class DataProvider1
    {
        private static DataProvider instance;
        SqlCommand command;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
        }

        private DataProvider1() { }

        private string connectionSTR = @"Data Source=TIEN-PC\SQLEXPRESS;Initial Catalog=QLCHVLXD1;Integrated Security=True";
        // private string connectionSTR = @"Data Source=DESKTOP-01UK3N8\SQLEXPRESS;Initial Catalog=QLNSu; Integrated Security=True";

        public DataTable ExcuteQuery(string query, object[] parameter = null) //Trả về giá trị được cung cấp bởi CSDL thông qua lệnh select
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))//sử dụng using thì kết nối sẽ tự động đóng lại ở cuối khối using, không cần gọi Close()
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExcuteNonQuery(string query, object[] parameter = null) //Truy vấn update, delete, insert, trả về hàng được thực thi
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExcuteScalar(string query, object[] parameter = null) //Trả về giá trị hàng đầu tiên và cột đầu tiên của kq
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
        public int GetIntValue(string query, object[] parameter = null)//lấy giá trị int, trả về 1 số duy nhất
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataReader data = command.ExecuteReader();
                if (data.HasRows)
                {
                    data.Read();
                    result = data.GetInt32(0);
                }
                connection.Close();
            }
            return result;
        }
    }
}
