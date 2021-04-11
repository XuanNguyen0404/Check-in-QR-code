using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseAss.dao
{
    public class EventDao:DB
    {
        public bool Create(EventDto dto)
        {
            SqlCommand cmd = new SqlCommand("Insert Into tblEvent(name,description,emailContent,userID, status) VALUES(@name,@description,@emailContent,@userID,@status);", con);
            cmd.Parameters.AddWithValue("@name", dto.Name);
            cmd.Parameters.AddWithValue("@description",dto.Description);
            cmd.Parameters.AddWithValue("@emailContent", dto.EmailContent);
            cmd.Parameters.AddWithValue("@userID", dto.UserID);
            cmd.Parameters.AddWithValue("@status", "new");
            int count = 0;
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            
            return count == 1;
        }

        public bool Update(EventDto dto)
        {
            
            SqlCommand cmd = new SqlCommand("Update tblEvent set name=@name,description=@description where id=@id;", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = dto.Id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = dto.Name;
            cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = dto.Description;
            int count = 0;
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            
            return count == 1;
        }

        public bool UpdateStatus(int id, string status)
        {
            
            SqlCommand cmd = new SqlCommand("Update tblEvent set status=@status where id=@id;", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@status", status);
            int count = 0;
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            
            return count == 1;
        }
        public bool DeleteById(int Id)
        {
            SqlCommand cmd = new SqlCommand("UPDATE dbo.tblEvent SET status='deleted' WHERE id=@id", con);
            cmd.Parameters.AddWithValue( "@id",Id);
            int count = 0;
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            
            return count == 1;
        }

        public int GetLastId()
        {
            string query = "SELECT MAX(id) FROM dbo.tblEvent";
            SqlCommand cmd = new SqlCommand(query, con);
            int id = -1;
            try
            {
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    id = dataReader.GetInt32(0);
                }
            }
            finally
            {
                con.Close();
            }
            return id;
        }

        public List<EventDto> ReadData(string userName,string search)
        {
            List<EventDto> events = null;
            string query = "SELECT id,name,description,status FROM dbo.tblEvent WHERE userID=@userName And status!='deleted' And name like @search And status != 'checked in'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userName",userName);
            cmd.Parameters.AddWithValue("@search", "%"+search+"%");
            try
            {
                con.Open();
                SqlDataReader dataReader= cmd.ExecuteReader();
                events = new List<EventDto>();
                while (dataReader.Read())
                {
                    EventDto eventDto = new EventDto();
                    eventDto.Id = dataReader.GetInt32(0);
                    eventDto.Name = dataReader.GetString(1);
                    eventDto.Description = dataReader.GetString(2);
                    eventDto.Status = dataReader.GetString(3);
                    events.Add(eventDto);
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                con.Close();
            }
            return events;
        }

        public List<EventDto> ReadOldEventData(string userName, string search)
        {
            List<EventDto> events = null;
            string query = "SELECT id,name,description,status FROM dbo.tblEvent WHERE userID=@userName And name like @search And status = 'checked in'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
            try
            {
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                events = new List<EventDto>();
                while (dataReader.Read())
                {
                    EventDto eventDto = new EventDto();
                    eventDto.Id = dataReader.GetInt32(0);
                    eventDto.Name = dataReader.GetString(1);
                    eventDto.Description = dataReader.GetString(2);
                    eventDto.Status = dataReader.GetString(3);
                    events.Add(eventDto);
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                con.Close();
            }
            return events;
        }


    }
}
