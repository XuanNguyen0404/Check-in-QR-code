using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseAss.dao
{
    public class UserDao:DB
    {
        public bool Create(UserDto dto)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert Into tblUser(name,userName,password) VALUES(@name,@userName,@password);", con);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = dto.Name;
            cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = dto.UserName;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = dto.Password;
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count == 1;
        }




        public string CheckLogin(String userName, string pass)
        {
            string name="";
            SqlCommand cmd = new SqlCommand("Select name from tblUser where userName=@userName and password=@password", con);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = pass;
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                name = dataReader.GetString(0);
            }
            
            con.Close();
            return name;
        }

       
    }
}
