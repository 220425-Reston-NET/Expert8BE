using expert8DL;
using Expert8Model;
using Microsoft.Data.SqlClient;

namespace Expert8DL
{
    public class specialistDL : iexpert8DL<JoinTable>
    {
        private readonly string _connectionString;

        public specialistDL(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void AddCus(JoinTable p_resource)
        {
            string SQLQuery = @"insert into JoinTable
                                values (@pID,@mhsID,@mhpID,@ssID,@wID)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@pID", p_resource.pID);
                command.Parameters.AddWithValue("@mhsID", p_resource.mhsID);
                command.Parameters.AddWithValue("@mhpID", p_resource.mhpID);
                command.Parameters.AddWithValue("@ssID", p_resource.ssID);
                command.Parameters.AddWithValue("@wID", p_resource.wID);

                command.ExecuteNonQuery();
            }
        }

        public List<JoinTable> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}