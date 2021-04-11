using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseAss.dao
{
    public class EventAttendeesDao : DB
    {
        public bool Create(EventAttendeesDto dto)
        {
            SqlCommand cmd = new SqlCommand("Insert Into tblEventAttendees(groupID,name,email,other) VALUES(@groupID,@name,@email,@other);", con);
            cmd.Parameters.AddWithValue("@groupID", dto.GroupID);
            cmd.Parameters.AddWithValue("@name",  dto.Name);
            cmd.Parameters.AddWithValue("@email", dto.Email);
            cmd.Parameters.AddWithValue("@other", dto.Other);
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

        public bool Update(EventAttendeesDto dto)
        {
            SqlCommand cmd = new SqlCommand("Update tblEventAttendees set name=@name,email=@email,other=@other where id=@id;", con);
            cmd.Parameters.AddWithValue("@id", dto.Id);
            cmd.Parameters.AddWithValue("@name", dto.Name);
            cmd.Parameters.AddWithValue("@email", dto.Email);
            cmd.Parameters.AddWithValue("@other", dto.Other);
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
            SqlCommand cmd = new SqlCommand("DELETE FROM tblEventAttendees where id=@id;", con);
            cmd.Parameters.AddWithValue("@id", Id);
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

        public List<EventAttendeesDto> ReadData(int groupId,string search)
        {
            string query = "SELECT id,name,email,other  FROM dbo.tblEventAttendees WHERE name LIKE @search AND groupID=@groupId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.Parameters.AddWithValue("@search", "%"+search+"%");
            List<EventAttendeesDto> eventAttendeesDtos = new List<EventAttendeesDto>();
            try
            {
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    EventAttendeesDto eventAttendeesDto = new EventAttendeesDto();
                    eventAttendeesDto.Id = dataReader.GetInt32(0);
                    eventAttendeesDto.Name = dataReader.GetString(1);
                    eventAttendeesDto.Email = dataReader.GetString(2);
                    eventAttendeesDto.Other = dataReader.GetString(3);
                    eventAttendeesDtos.Add(eventAttendeesDto);
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
            return eventAttendeesDtos;
        }

       
    }
}
