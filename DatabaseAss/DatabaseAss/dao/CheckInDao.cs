using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseAss.dao
{
    public class CheckInDao : DB
    {
        public bool Create(CheckInDto dto)
        {
            SqlCommand cmd = new SqlCommand("Insert Into tblCheckIn(name,email,other,eventID,checked) VALUES(@name,@email,@other,@eventID,@checked);", con);
            cmd.Parameters.AddWithValue("@name", dto.Name);
            cmd.Parameters.AddWithValue("@email", dto.Email);
            cmd.Parameters.AddWithValue("@other", dto.Other);
            cmd.Parameters.AddWithValue("@eventID", dto.EventID);
            cmd.Parameters.AddWithValue("@checked", false);
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

        public bool Update(CheckInDto dto)
        {
            SqlCommand cmd = new SqlCommand("Update tblCheckIn set name=@name,email=@email,other=@other where eventAttendeesID=@eventAttendeesID;", con);
            cmd.Parameters.AddWithValue("@eventAttendeesID", dto.EventAttendeesID);
            cmd.Parameters.AddWithValue("@name", dto.Name);
            cmd.Parameters.AddWithValue("@email", dto.Email);
            cmd.Parameters.AddWithValue("@other", dto.Other);
            int count=0;
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

        public bool DeleteById(int EventAttendeesID)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tblCheckIn where eventAttendeesID=@eventAttendeesID;", con);
            cmd.Parameters.AddWithValue("@eventAttendeesID",  EventAttendeesID);
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

        public List<CheckInDto> ReadData(int eventId, string search)
        {
            string query = "SELECT eventAttendeesID,name,email,other,checked FROM dbo.tblCheckIn WHERE eventID=@id AND name LIKE @search";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", eventId);
            cmd.Parameters.AddWithValue("@search", "%"+search+"%");
            List<CheckInDto> checkInDtos = new List<CheckInDto>();
            try
            {
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    CheckInDto checkInDto = new CheckInDto();
                    checkInDto.EventAttendeesID = dataReader.GetInt32(0);
                    checkInDto.Name = dataReader.GetString(1);
                    checkInDto.Email = dataReader.GetString(2);
                    checkInDto.Other = dataReader.GetString(3);
                    checkInDto.Check = dataReader.GetBoolean(4);
                    checkInDtos.Add(checkInDto);
                }
            }
            finally
            {
                con.Close();
            }
            return checkInDtos;
        }

        public bool UpdateStatus(int eventAttendeesID, bool isChecked)
        {
            SqlCommand cmd = new SqlCommand("Update tblCheckIn set checked=@Checked where eventAttendeesID=@eventAttendeesID;", con);
            cmd.Parameters.AddWithValue("@eventAttendeesID", eventAttendeesID);
            cmd.Parameters.AddWithValue("@Checked", isChecked);
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

        public CheckInDto CheckInByAttendeesID(int eventAttendeesID)
        {
            SqlCommand cmd = new SqlCommand("SELECT name,email,other,checked FROM tblCheckIn where eventAttendeesID=@eventAttendeesID;", con);
            cmd.Parameters.AddWithValue("@eventAttendeesID", eventAttendeesID);
            try
            {
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CheckInDto checkInDto = new CheckInDto();
                    checkInDto.EventAttendeesID = eventAttendeesID;
                    checkInDto.Name = dataReader.GetString(0);
                    checkInDto.Email = dataReader.GetString(1);
                    checkInDto.Other = dataReader.GetString(2);
                    checkInDto.Check = dataReader.GetBoolean(3);
                    return checkInDto;
                }
            }
            finally
            {
                con.Close();
            }
            return null;
        }
    }
}
