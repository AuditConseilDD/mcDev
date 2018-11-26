using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess.db
{
    public class CRA_LibeleColDB
    {
        //declare connection string
        string cs = ConfigurationManager.ConnectionStrings["AuthenticationDB"].ConnectionString;

        //Return list of all CRAs
        public List<CRA_LibeleColMODEL> GetLibColList()
        {
            List<CRA_LibeleColMODEL> lst = new List<CRA_LibeleColMODEL>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_LibeleCol_List", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new CRA_LibeleColMODEL
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        LibShort = rdr["LibShort"] != DBNull.Value ? rdr["LibShort"].ToString() : string.Empty,
                        LibLong = rdr["LibLong"] != DBNull.Value ? rdr["LibLong"].ToString() : string.Empty,
                        Type = rdr["Type"] != DBNull.Value ? rdr["Type"].ToString() : string.Empty,
                        IsActive = Convert.ToBoolean(rdr["IsActive"] != DBNull.Value ? rdr["IsActive"] : "0"),
                        CreationDate = Convert.ToDateTime(rdr["CreationDate"] != DBNull.Value ? rdr["CreationDate"] : "01/01/1900"),
                        DeletionDate = Convert.ToDateTime(rdr["DeletionDate"] != DBNull.Value ? rdr["DeletionDate"] : "01/01/1900")
                    });
                }
                return lst;
            }
        }

        //Return list of all CRAs
        public List<CRA_LibeleColMODEL> GetLibColListByCraID(int p_craId)
        {
            List<CRA_LibeleColMODEL> lst = new List<CRA_LibeleColMODEL>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_LibeleCol_sel", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@craId", p_craId);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new CRA_LibeleColMODEL
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        LibShort = rdr["LibShort"] != DBNull.Value ? rdr["LibShort"].ToString() : string.Empty,
                        LibLong = rdr["LibLong"] != DBNull.Value ? rdr["LibLong"].ToString() : string.Empty,
                        Type = rdr["Type"] != DBNull.Value ? rdr["Type"].ToString() : string.Empty,
                        IsActive = Convert.ToBoolean(rdr["IsActive"] != DBNull.Value ? rdr["IsActive"] : "0"),
                        CreationDate = Convert.ToDateTime(rdr["CreationDate"] != DBNull.Value ? rdr["CreationDate"] : "01/01/1900"),
                        DeletionDate = Convert.ToDateTime(rdr["DeletionDate"] != DBNull.Value ? rdr["DeletionDate"] : "01/01/1900")
                    });
                }
                return lst;
            }
        }
    }
}