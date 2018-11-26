using MCSolutions.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess.db
{
    public class CRA_ActiviteDetailDB
    {
        //declare connection string
        string cs = ConfigurationManager.ConnectionStrings["AuthenticationDB"].ConnectionString;

        //Return list of all CRAs
        public List<CRA_ActiviteDetailMODEL> GetActivitesListByCraId_OLD(int p_craId)
        {
            List<CRA_ActiviteDetailMODEL> lst = new List<CRA_ActiviteDetailMODEL>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_ActiviteDetail_sel", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@craId", p_craId);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new CRA_ActiviteDetailMODEL
                    {
                        CRAActiviteId = Convert.ToInt32(rdr["CRAActiviteId"] != DBNull.Value ? rdr["CRAActiviteId"].ToString() : "0"),
                        DateBegin = Convert.ToDateTime(rdr["DateBegin"] != DBNull.Value ? rdr["DateBegin"].ToString() : "01/01/1900"),
                        DateEnd = Convert.ToDateTime(rdr["DateEnd"] != DBNull.Value ? rdr["DateEnd"].ToString() : "01/01/1900"),
                        CRAlibeleColId = Convert.ToInt32(rdr["CRAlibeleColId"] != DBNull.Value ? rdr["CRAlibeleColId"].ToString() : "0"),
                        Quantity = Convert.ToDecimal(rdr["Quantity"] != DBNull.Value ? rdr["Quantity"].ToString() : "0"),
                        CreationDate = Convert.ToDateTime(rdr["CreationDate"] != DBNull.Value ? rdr["CreationDate"].ToString() : "01/01/1900"),
                        CreationBY = rdr["CreationBY"] != DBNull.Value ? rdr["CreationBY"].ToString() : string.Empty,
                        modificationDate = Convert.ToDateTime(rdr["modificationDate"] != DBNull.Value ? rdr["modificationDate"].ToString() : "01/01/1900"),
                        ModificationBY = rdr["ModificationBY"] != DBNull.Value ? rdr["ModificationBY"].ToString() : string.Empty
                    });
                }
                return lst;
            }
        }

        public DataTable GetActivitesListByCraId(int p_craId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_ActiviteDetail_sel_NEW", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@craId", p_craId);
                //SqlDataReader rdr = com.ExecuteReader();
                //while (rdr.Read())
                //{
                //    lst.Add(new CRA_ActiviteDetailMODEL
                //    {
                //        CRAActiviteId = Convert.ToInt32(rdr["CRAActiviteId"] != DBNull.Value ? rdr["CRAActiviteId"].ToString() : "0"),
                //        DateBegin = Convert.ToDateTime(rdr["DateBegin"] != DBNull.Value ? rdr["DateBegin"].ToString() : "01/01/1900"),
                //        DateEnd = Convert.ToDateTime(rdr["DateEnd"] != DBNull.Value ? rdr["DateEnd"].ToString() : "01/01/1900"),
                //        CRAlibeleColId = Convert.ToInt32(rdr["CRAlibeleColId"] != DBNull.Value ? rdr["CRAlibeleColId"].ToString() : "0"),
                //        Quantity = Convert.ToDecimal(rdr["Quantity"] != DBNull.Value ? rdr["Quantity"].ToString() : "0"),
                //        CreationDate = Convert.ToDateTime(rdr["CreationDate"] != DBNull.Value ? rdr["CreationDate"].ToString() : "01/01/1900"),
                //        CreationBY = rdr["CreationBY"] != DBNull.Value ? rdr["CreationBY"].ToString() : string.Empty,
                //        modificationDate = Convert.ToDateTime(rdr["modificationDate"] != DBNull.Value ? rdr["modificationDate"].ToString() : "01/01/1900"),
                //        ModificationBY = rdr["ModificationBY"] != DBNull.Value ? rdr["ModificationBY"].ToString() : string.Empty
                //    });
                //}

                //DataTable t1 = new DataTable();
                //using (SqlDataAdapter a = new SqlDataAdapter(com))
                //{
                //    a.Fill(t1);
                //}

                dt.Load(com.ExecuteReader());
                con.Close();

                return dt;
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