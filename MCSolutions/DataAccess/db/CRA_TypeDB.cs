using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess.db
{
    public class CRA_TypeDB
    {
        //declare connection string
        string cs = ConfigurationManager.ConnectionStrings["AuthenticationDB"].ConnectionString;

        public List<CRA_TypeMODEL> GetCRATypeList()
        {
            List<CRA_TypeMODEL> lst = new List<CRA_TypeMODEL>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_Type__List", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new CRA_TypeMODEL
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        NbrColTotal = Convert.ToInt32(rdr["NbrColTotal"] != DBNull.Value ? rdr["NbrColTotal"].ToString() : "0"),
                        CRAName = rdr["CRAName"] != DBNull.Value ? rdr["CRAName"].ToString() : string.Empty,
                        CRADescription = rdr["CRADescription"] != DBNull.Value ? rdr["CRADescription"].ToString() : string.Empty,
                        IsActive = Convert.ToBoolean(rdr["IsActive"] != DBNull.Value ? rdr["IsActive"] : "0"),
                        CreationDate = Convert.ToDateTime(rdr["CreationDate"] != DBNull.Value ? rdr["CreationDate"] : "01/01/1900"),
                        DeletionDate = Convert.ToDateTime(rdr["DeletionDate"] != DBNull.Value ? rdr["DeletionDate"] : "01/01/1900")
                    });
                }
                return lst;
            }
        }


        ////Method for Adding an new CRA or updating a new one
        //public int InsertUpdate(CRA p_cra, string p_action)
        //{
        //    int i;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand com = new SqlCommand("sp_CRA_InsertUpdate", con);
        //        com.CommandType = CommandType.StoredProcedure;

        //        com.Parameters.AddWithValue("@CRAId", p_cra.CRAId);
        //        com.Parameters.AddWithValue("@LIBELLE", p_cra.LIBELLE);
        //        com.Parameters.AddWithValue("@NUMCRA", p_cra.NUMCRA);
        //        com.Parameters.AddWithValue("@MOIS", p_cra.MOIS);
        //        com.Parameters.AddWithValue("@NBTOTALJOURS", p_cra.NBTOTALJOURS);
        //        com.Parameters.AddWithValue("@FK_IDCONSULTANT", p_cra.FK_IDCONSULTANT);
        //        com.Parameters.AddWithValue("@FK_IDCLIENT", p_cra.FK_IDCLIENT);
        //        com.Parameters.AddWithValue("@LIB_CLIENT", p_cra.LIB_CLIENT);
        //        com.Parameters.AddWithValue("@FK_IDRESPONSABLE", p_cra.FK_IDRESPONSABLE);
        //        com.Parameters.AddWithValue("@LIB_RESPONSABLE", p_cra.LIB_RESPONSABLE);
        //        com.Parameters.AddWithValue("@FK_IDSTATUT", p_cra.FK_IDSTATUT);
        //        com.Parameters.AddWithValue("@SIGNECONSULTANT", p_cra.SIGNECONSULTANT);
        //        com.Parameters.AddWithValue("@DTSIGNECONSULTANT", p_cra.DTSIGNECONSULTANT);
        //        com.Parameters.AddWithValue("@SIGNECLIENTFINAL", p_cra.SIGNECLIENTFINAL);
        //        com.Parameters.AddWithValue("@DTSIGNECLIENTFINAL", p_cra.DTSIGNECLIENTFINAL);
        //        com.Parameters.AddWithValue("@SIGNEAGENT", p_cra.SIGNEAGENT);
        //        com.Parameters.AddWithValue("@DTSIGNEAGENT", p_cra.DTSIGNEAGENT);
        //        com.Parameters.AddWithValue("@AddedDate", p_cra.AddedDate);
        //        com.Parameters.AddWithValue("@ModifiedDate", p_cra.ModifiedDate);
        //        com.Parameters.AddWithValue("@IPAddress", p_cra.IPAddress);
        //        com.Parameters.AddWithValue("@Action", p_action);

        //        i = com.ExecuteNonQuery();
        //    }
        //    return i;
        //}

        ////Method for Deleting a CRA 
        //public int Delete(int p_IDCRA)
        //{
        //    int i;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand com = new SqlCommand("sp_CRA_Delete", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@Id", p_IDCRA);
        //        i = com.ExecuteNonQuery();
        //    }
        //    return i;
        //}
    }
}