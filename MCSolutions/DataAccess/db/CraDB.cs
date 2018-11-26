using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess.db
{
    public class CraDB
    {
        //declare connection string
        string cs = ConfigurationManager.ConnectionStrings["AuthenticationDB"].ConnectionString;

        //Return list of all CRAs
        public List<CRA> GetListByUserId(int p_userId, int? p_craId = null)
        {
            List<CRA> lst = new List<CRA>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_GetListByUserId", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@userId", p_userId);
                com.Parameters.AddWithValue("@craId", p_craId);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new CRA
                    {
                        CRAId = Convert.ToInt32(rdr["CRAId"]),
                        LIBELLE = rdr["LIBELLE"] != DBNull.Value ? rdr["LIBELLE"].ToString() : string.Empty,
                        NUMCRA = rdr["NUMCRA"] != DBNull.Value ? rdr["NUMCRA"].ToString() : string.Empty,
                        MOIS = rdr["MOIS"] != DBNull.Value ? rdr["MOIS"].ToString() : string.Empty,
                        NBTOTALJOURS = Convert.ToInt32(rdr["NBTOTALJOURS"] != DBNull.Value ? rdr["NBTOTALJOURS"] : "0"),
                        FK_IDCONSULTANT = Convert.ToInt32(rdr["FK_IDCONSULTANT"] != DBNull.Value ? rdr["FK_IDCONSULTANT"] : "0"),
                        FK_IDCLIENT = Convert.ToInt32(rdr["FK_IDCLIENT"] != DBNull.Value ? rdr["FK_IDCLIENT"] : "0"),
                        LIB_CLIENT = rdr["LIB_CLIENT"] != DBNull.Value ? rdr["LIB_CLIENT"].ToString() : string.Empty,
                        FK_IDRESPONSABLE = Convert.ToInt32(rdr["FK_IDRESPONSABLE"] != DBNull.Value ? rdr["FK_IDRESPONSABLE"] : "0"),
                        LIB_RESPONSABLE = rdr["LIB_RESPONSABLE"] != DBNull.Value ? rdr["LIB_RESPONSABLE"].ToString() : string.Empty,
                        FK_IDSTATUT = Convert.ToInt32(rdr["FK_IDSTATUT"] != DBNull.Value ? rdr["FK_IDSTATUT"] : "0"),
                        SIGNECONSULTANT = Convert.ToBoolean(rdr["SIGNECONSULTANT"] != DBNull.Value ? rdr["SIGNECONSULTANT"] : "0"),
                        DTSIGNECONSULTANT = Convert.ToDateTime(rdr["DTSIGNECONSULTANT"] != DBNull.Value ? rdr["DTSIGNECONSULTANT"] : "01/01/1900"),
                        SIGNECLIENTFINAL = Convert.ToBoolean(rdr["SIGNECLIENTFINAL"] != DBNull.Value ? rdr["SIGNECLIENTFINAL"] : "0"),
                        DTSIGNECLIENTFINAL = Convert.ToDateTime(rdr["DTSIGNECLIENTFINAL"] != DBNull.Value ? rdr["DTSIGNECLIENTFINAL"] : "01/01/1900"),
                        SIGNEAGENT = Convert.ToBoolean(rdr["SIGNEAGENT"] != DBNull.Value ? rdr["SIGNEAGENT"] : "0"),
                        DTSIGNEAGENT = Convert.ToDateTime(rdr["DTSIGNEAGENT"] != DBNull.Value ? rdr["DTSIGNEAGENT"] : "01/01/1900"),
                        AddedDate = Convert.ToDateTime(rdr["AddedDate"] != DBNull.Value ? rdr["AddedDate"] : "01/01/1900"),
                        ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"] != DBNull.Value ? rdr["ModifiedDate"] : "01/01/1900"),
                        IPAddress = rdr["IPAddress"] != DBNull.Value ? rdr["IPAddress"].ToString() : string.Empty,
                    });
                }
                return lst;
            }
        }


        //Method for Adding an new CRA or updating a new one
        public int Add(CRA p_cra)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_InsertUpdate", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@CRAId", p_cra.CRAId);
                com.Parameters.AddWithValue("@LIBELLE", p_cra.LIBELLE);
                com.Parameters.AddWithValue("@NUMCRA", p_cra.NUMCRA);
                com.Parameters.AddWithValue("@MOIS", p_cra.MOIS);
                com.Parameters.AddWithValue("@NBTOTALJOURS", p_cra.NBTOTALJOURS);
                com.Parameters.AddWithValue("@FK_IDCONSULTANT", p_cra.FK_IDCONSULTANT);
                com.Parameters.AddWithValue("@FK_IDCLIENT", p_cra.FK_IDCLIENT);
                com.Parameters.AddWithValue("@LIB_CLIENT", p_cra.LIB_CLIENT);
                com.Parameters.AddWithValue("@FK_IDRESPONSABLE", p_cra.FK_IDRESPONSABLE);
                com.Parameters.AddWithValue("@LIB_RESPONSABLE", p_cra.LIB_RESPONSABLE);
                com.Parameters.AddWithValue("@FK_IDSTATUT", p_cra.FK_IDSTATUT);
                com.Parameters.AddWithValue("@SIGNECONSULTANT", p_cra.SIGNECONSULTANT);
                com.Parameters.AddWithValue("@DTSIGNECONSULTANT", p_cra.DTSIGNECONSULTANT);
                com.Parameters.AddWithValue("@SIGNECLIENTFINAL", p_cra.SIGNECLIENTFINAL);
                com.Parameters.AddWithValue("@DTSIGNECLIENTFINAL", p_cra.DTSIGNECLIENTFINAL);
                com.Parameters.AddWithValue("@SIGNEAGENT", p_cra.SIGNEAGENT);
                com.Parameters.AddWithValue("@DTSIGNEAGENT", p_cra.DTSIGNEAGENT);
                com.Parameters.AddWithValue("@AddedDate", p_cra.AddedDate);
                com.Parameters.AddWithValue("@ModifiedDate", p_cra.ModifiedDate);
                com.Parameters.AddWithValue("@IPAddress", p_cra.IPAddress);
                com.Parameters.AddWithValue("@Action", "insert");

                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Method for Adding an new CRA or updating a new one
        public int AddActivite(CRA_ActiviteDetailMODEL p_craAD)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_ActiviteDetail__InsertUpdate", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@CRAActiviteId", p_craAD.CRAActiviteId	);
                com.Parameters.AddWithValue("@DateBegin", p_craAD.DateBegin		);
                com.Parameters.AddWithValue("@DateEnd", p_craAD.DateEnd		);
                com.Parameters.AddWithValue("@CRAlibeleColId", p_craAD.CRAlibeleColId );
                com.Parameters.AddWithValue("@Quantity", p_craAD.Quantity		);
                com.Parameters.AddWithValue("@CreationBY", p_craAD.CreationBY		);
                com.Parameters.AddWithValue("@ModificationBY", p_craAD.ModificationBY );
                com.Parameters.AddWithValue("@Action", "insert");

                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Method for Adding an new CRA or updating a new one
        public int UpdateActivite(CRA_ActiviteDetailMODEL p_craAD)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_ActiviteDetail__InsertUpdate", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@CRAActiviteId", p_craAD.CRAActiviteId	);
                com.Parameters.AddWithValue("@DateBegin", p_craAD.DateBegin		);
                com.Parameters.AddWithValue("@DateEnd", p_craAD.DateEnd);
                com.Parameters.AddWithValue("@CRAlibeleColId", p_craAD.CRAlibeleColId );
                com.Parameters.AddWithValue("@Quantity", p_craAD.Quantity		);
                com.Parameters.AddWithValue("@CreationBY", p_craAD.CreationBY		);
                com.Parameters.AddWithValue("@ModificationBY", p_craAD.ModificationBY );
                com.Parameters.AddWithValue("@Action", "update");

                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Method for Adding an new CRA or updating a new one
        public int Update(CRA p_cra)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_InsertUpdate", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@CRAId", p_cra.CRAId);
                com.Parameters.AddWithValue("@LIBELLE", p_cra.LIBELLE);
                com.Parameters.AddWithValue("@NUMCRA", p_cra.NUMCRA);
                com.Parameters.AddWithValue("@MOIS", p_cra.MOIS);
                com.Parameters.AddWithValue("@NBTOTALJOURS", p_cra.NBTOTALJOURS);
                com.Parameters.AddWithValue("@FK_IDCONSULTANT", p_cra.FK_IDCONSULTANT);
                com.Parameters.AddWithValue("@FK_IDCLIENT", p_cra.FK_IDCLIENT);
                com.Parameters.AddWithValue("@LIB_CLIENT", p_cra.LIB_CLIENT);
                com.Parameters.AddWithValue("@FK_IDRESPONSABLE", p_cra.FK_IDRESPONSABLE);
                com.Parameters.AddWithValue("@LIB_RESPONSABLE", p_cra.LIB_RESPONSABLE);
                com.Parameters.AddWithValue("@FK_IDSTATUT", p_cra.FK_IDSTATUT);
                com.Parameters.AddWithValue("@SIGNECONSULTANT", p_cra.SIGNECONSULTANT);
                com.Parameters.AddWithValue("@DTSIGNECONSULTANT", p_cra.DTSIGNECONSULTANT);
                com.Parameters.AddWithValue("@SIGNECLIENTFINAL", p_cra.SIGNECLIENTFINAL);
                com.Parameters.AddWithValue("@DTSIGNECLIENTFINAL", p_cra.DTSIGNECLIENTFINAL);
                com.Parameters.AddWithValue("@SIGNEAGENT", p_cra.SIGNEAGENT);
                com.Parameters.AddWithValue("@DTSIGNEAGENT", p_cra.DTSIGNEAGENT);
                com.Parameters.AddWithValue("@AddedDate", p_cra.AddedDate);
                com.Parameters.AddWithValue("@ModifiedDate", p_cra.ModifiedDate);
                com.Parameters.AddWithValue("@IPAddress", p_cra.IPAddress);
                com.Parameters.AddWithValue("@Action", "update");

                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting a CRA 
        public int Delete(int p_IDCRA)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_CRA_Delete", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", p_IDCRA);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}