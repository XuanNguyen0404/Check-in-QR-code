using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseAss.dao
{
    public class GroupDao:DB
    {
        public bool Create(GroupDto dto)
        {
            SqlCommand cmd = new SqlCommand("Insert Into tblGroup(name,description,userID, status) VALUES(@name,@description,@userID, 'new');", con);
            cmd.Parameters.AddWithValue("@name", dto.Name);
            cmd.Parameters.AddWithValue("@description",  dto.Description);
            cmd.Parameters.AddWithValue("@userID", dto.UserID);
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

        public bool Update(GroupDto dto)
        {
            SqlCommand cmd = new SqlCommand("Update tblGroup set name=@name,description=@description where id=@id;", con);
            cmd.Parameters.AddWithValue("@id", dto.Id);
            cmd.Parameters.AddWithValue("@name", dto.Name);
            cmd.Parameters.AddWithValue("@description", dto.Description);
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
            SqlCommand cmd = new SqlCommand("UPDATE dbo.tblGroup SET status='deleted' WHERE id=@id", con);
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

        public List<GroupDto> ReadData(string userId, string search)
        {
            string query = "SELECT id,name,description FROM dbo.tblGroup WHERE userID=@userId AND name like @search AND status!='deleted' ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@search", "%"+search+"%");
            List<GroupDto> groups = new List<GroupDto>();
            try
            {
                con.Open();
                SqlDataReader dataReader= cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    GroupDto groupDto = new GroupDto();
                    groupDto.Id = dataReader.GetInt32(0);
                    groupDto.Name = dataReader.GetString(1);
                    groupDto.Description = dataReader.GetString(2);
                    groups.Add(groupDto);
                }

            }
            finally
            {
                con.Close();
            }
            return groups;
        }

        public List<GroupDto> LoadListGroupName(string userId)
        {
            string query = "SELECT id,name FROM dbo.tblGroup WHERE userID=@userId AND status!='deleted' ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", userId);
            List<GroupDto> groups = new List<GroupDto>();
            try
            {
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    GroupDto groupDto = new GroupDto();
                    groupDto.Id = dataReader.GetInt32(0);
                    groupDto.Name = dataReader.GetString(1);
                    groups.Add(groupDto);
                }

            }
            finally
            {
                con.Close();
            }
            return groups;
        }

    }
}
