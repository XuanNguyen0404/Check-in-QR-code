using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseAss.dao
{
    public class UserJoinToEventDao:DB
    {
        public bool Create(UserJoinToEventDto dto)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert Into tblUserJoinToEvent(id,userID,eventID) VALUES(@id,@userID,@eventID);", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = dto.Id;
            cmd.Parameters.Add("@userID", SqlDbType.VarChar).Value = dto.UserID;
            cmd.Parameters.Add("@eventID", SqlDbType.Int).Value = dto.EventID;
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count == 1;
        }

        public bool Update(UserJoinToEventDto dto)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update tblUserJoinToEvent set userID=@userID, eventID=@eventID where id=@id;", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = dto.Id;
            cmd.Parameters.Add("@userID", SqlDbType.VarChar).Value = dto.UserID;
            cmd.Parameters.Add("@eventID", SqlDbType.Int).Value = dto.EventID;
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count == 1;
        }

        public bool DeleteById(int Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM tblUserJoinToEvent where id=@id", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count == 1;
        }

        public DataTable Read_data()
        {
            string query = "Select * from tblUserJoinToEvent";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtTable = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                da.Fill(dtTable);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                con.Close();
            }
            return dtTable;
        }
    }
}
