using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class CRA
    {
        public int CRAId { get; set; }
        public string LIBELLE { get; set; }
        public string NUMCRA { get; set; }
        public string MOIS { get; set; }
        public int NBTOTALJOURS { get; set; }
        //public long NBTOTALJOURSTRAV { get; set; }
        //public long NBTOTALJOURSASTR { get; set; }
        //public long NBTOTALJOURSINTS { get; set; }
        public int FK_IDCONSULTANT { get; set; }        // created by
        public int FK_IDCLIENT { get; set; }
        public string LIB_CLIENT { get; set; }
        public long FK_IDRESPONSABLE { get; set; }
        public string LIB_RESPONSABLE { get; set; }
        public int FK_IDSTATUT { get; set; }
        public bool SIGNECONSULTANT { get; set; }
        public DateTime? DTSIGNECONSULTANT { get; set; }
        public bool SIGNECLIENTFINAL { get; set; }
        public DateTime? DTSIGNECLIENTFINAL { get; set; }
        public bool SIGNEAGENT { get; set; }
        public DateTime? DTSIGNEAGENT { get; set; }

        public virtual ICollection<CRA_Activite> ListeActivite { get; set; }
    }
}