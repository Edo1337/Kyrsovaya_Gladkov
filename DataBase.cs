using System.Data.SqlClient;

namespace Kyrsovaya_Gladkov
{
    internal class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-L8UGEGP;Initial Catalog=Kyrsovaya;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed) 
            { 
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open) 
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
