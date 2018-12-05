using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess.db
{
    public class CRA_ActiviteDB
    {
        //declare connection string
        string cs = ConfigurationManager.ConnectionStrings["AuthenticationDB"].ConnectionString;

        ////Return list of all CRAs
        public List<CRA_ActiviteMODEL> GetCRAActiviteById(int p_id)
        {
            List<CRA_ActiviteMODEL> lst = new List<CRA_ActiviteMODEL>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_Activite__ById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", p_id);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new CRA_ActiviteMODEL
                    {
                        Id = Convert.ToInt32(rdr["Id"] != DBNull.Value ? rdr["Id"].ToString() : "0"),
                        UsersId = Convert.ToInt32(rdr["UsersId"] != DBNull.Value ? rdr["UsersId"].ToString() : "0"),
                        CRATypeId = Convert.ToInt32(rdr["CRATypeId"] != DBNull.Value ? rdr["CRATypeId"].ToString() : "0"),
                        Period = rdr["Period"] != DBNull.Value ? rdr["Period"].ToString() : string.Empty,
                        CreationDate = Convert.ToDateTime(rdr["CreationDate"] != DBNull.Value ? rdr["CreationDate"].ToString() : "01/01/1900"),
                        CreatedBy = rdr["CreatedBy"] != DBNull.Value ? rdr["CreatedBy"].ToString() : string.Empty,
                        ModificaitonDate = Convert.ToDateTime(rdr["ModificaitonDate"] != DBNull.Value ? rdr["ModificaitonDate"].ToString() : "01/01/1900"),
                        ModificaitonBy = rdr["ModificaitonBy"] != DBNull.Value ? rdr["ModificaitonBy"].ToString() : string.Empty,
                        PeriodBegin = Convert.ToDateTime(rdr["PeriodBegin"] != DBNull.Value ? rdr["PeriodBegin"].ToString() : "01/01/1900"),
                        PeriodEnd = Convert.ToDateTime(rdr["PeriodEnd"] != DBNull.Value ? rdr["PeriodEnd"].ToString() : "01/01/1900")
                    });
                }
                return lst;
            }
        }

        ////Return list of all CRAs
        public List<CRA_ActiviteMODEL> GetCRAActiviteListByUserId(int p_userId)
        {
            List<CRA_ActiviteMODEL> lst = new List<CRA_ActiviteMODEL>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_Activite__List", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UsersId", p_userId);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new CRA_ActiviteMODEL
                    {
                        Id = Convert.ToInt32(rdr["Id"] != DBNull.Value ? rdr["Id"].ToString() : "0"),
                        UsersId = Convert.ToInt32(rdr["UsersId"] != DBNull.Value ? rdr["UsersId"].ToString() : "0"),
                        CRATypeId = Convert.ToInt32(rdr["CRATypeId"] != DBNull.Value ? rdr["CRATypeId"].ToString() : "0"),
                        Period = rdr["Period"] != DBNull.Value ? rdr["Period"].ToString() : string.Empty,
                        CreationDate = Convert.ToDateTime(rdr["CreationDate"] != DBNull.Value ? rdr["CreationDate"].ToString() : "01/01/1900"),
                        CreatedBy = rdr["CreatedBy"] != DBNull.Value ? rdr["CreatedBy"].ToString() : string.Empty,
                        ModificaitonDate = Convert.ToDateTime(rdr["ModificaitonDate"] != DBNull.Value ? rdr["ModificaitonDate"].ToString() : "01/01/1900"),
                        ModificaitonBy = rdr["ModificaitonBy"] != DBNull.Value ? rdr["ModificaitonBy"].ToString() : string.Empty,
                        PeriodBegin = Convert.ToDateTime(rdr["PeriodBegin"] != DBNull.Value ? rdr["PeriodBegin"].ToString() : "01/01/1900"),
                        PeriodEnd = Convert.ToDateTime(rdr["PeriodEnd"] != DBNull.Value ? rdr["PeriodEnd"].ToString() : "01/01/1900")
                    });
                }
                return lst;
            }
        }


        //Method for Adding an new CRA or updating a new one
        public int AddCRAActivite(CRA_ActiviteMODEL p_craACT)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_Activite__InsertUpdate", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Id", p_craACT.Id);
                com.Parameters.AddWithValue("@UsersId", p_craACT.UsersId);
                com.Parameters.AddWithValue("@CRATypeId", p_craACT.CRATypeId);
                com.Parameters.AddWithValue("@Period", p_craACT.Period);
                com.Parameters.AddWithValue("@CreationDate", p_craACT.CreationDate);
                com.Parameters.AddWithValue("@CreatedBy", p_craACT.CreatedBy);
                com.Parameters.AddWithValue("@ModificaitonDate", p_craACT.ModificaitonDate);
                com.Parameters.AddWithValue("@ModificaitonBy", p_craACT.ModificaitonBy);
                com.Parameters.AddWithValue("@PeriodBegin", p_craACT.PeriodBegin);
                com.Parameters.AddWithValue("@PeriodEnd", p_craACT.PeriodEnd);
                com.Parameters.AddWithValue("@Action", "insert");

                i = com.ExecuteNonQuery();
            }
            return i;
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