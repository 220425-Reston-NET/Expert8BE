using Expert8Model;
using Microsoft.Data.SqlClient;

namespace expert8DL
{
    public class patientDL : iexpert8DL<Patient>
    {
         private readonly string _connectionString;

        public patientDL(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void AddCus(Patient p_resource)
        {
            
            string SQLQuery = @"insert into Patient
                                values (@pID,@pFirstName,@pLastname,@pEmail,@pPhone,@pAddress,@pCity,@pState,@pZip,@pPassword)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@pID", p_resource.PID);
                command.Parameters.AddWithValue("@pFirstName", p_resource.FirstName);
                command.Parameters.AddWithValue("@pLastname", p_resource.LastName);
                command.Parameters.AddWithValue("@pEMail", p_resource.Email);
                command.Parameters.AddWithValue("@pPhone", p_resource.Phone);
                command.Parameters.AddWithValue("@pAddress", p_resource.Address);
                command.Parameters.AddWithValue("@pCity", p_resource.City);
                command.Parameters.AddWithValue("@pState", p_resource.State);
                command.Parameters.AddWithValue("@pZip", p_resource.Zip);
                command.Parameters.AddWithValue("@pPassword", p_resource.Password);

                command.ExecuteNonQuery();
            }
        }

        public List<Patient> GetAll()
        {
          string SQLQuery = @"select * from patient";
            List<Patient> listofpatients = new List<Patient>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofpatients.Add(new Patient(){

                        PID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                        Address = reader.GetString(5),
                        City = reader.GetString(6),
                        State = reader.GetString(7),
                        Zip = reader.GetString(8),
                        Password= reader.GetString(9),
                        Services = giveservicetopatient(reader.GetInt32(0))
                    });
                }
                
                return listofpatients;
            }  
        }

        private List<Service> giveservicetopatient(int p_pID)
        {
            string SQLQuery = @"select ms.* from Patient p
                                inner join JoinTable jt on p.pID = jt.pID
                                inner join MHPrice mh on jt.jtID = mh.mhpID
                                inner join MHServices ms on jt.mhsID = ms.mhsID
                                where p.pID = @pID;";

             List<Service> listOfservices = new List<Service>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@pID", p_pID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfservices.Add(new Service(){
                        SID = reader.GetInt32(0),
                        ServiceName = reader.GetString(1),
                        Prices = givepricetoservice(reader.GetInt32(0))

                    });
                }
            }

            return listOfservices;
        }

        private List<Price> givepricetoservice(int s_pID)
        {
            string SQLQuery = @"select mh.* from Patient p
                                inner join JoinTable jt on p.pID = jt.pID
                                inner join MHPrice mh on jt.jtID = mh.mhpID
                                inner join MHServices ms on jt.mhsID = ms.mhsID
                                where p.pID = @pID;";

             List<Price> listOfprices = new List<Price>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@pID", s_pID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfprices.Add(new Price(){
                        PrID = reader.GetInt32(0),
                        ServicePrice = reader.GetDouble(1),
                        

                    });
                }
            }

            return listOfprices;
        }
    }
}