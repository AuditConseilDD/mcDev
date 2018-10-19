using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class CRA_Activite
    {
        public int ActiviteId { get; set; }
        public string LIBELLE { get; set; }
        public DateTime JOURTRAVAILLE { get; set; }
        public float NBHEURES { get; set; }
        public float TAUX { get; set; }
        //public long FK_IDTAUXCRA { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime? DTCREATION { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? DTMODIF { get; set; }
        public long FK_IDCRA { get; set; }
        public long FK_IDTYPEACTIVITE { get; set; }

        public virtual CRA Cra { get; set; }
    }
}