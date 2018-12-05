using MCSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class CRA_ActiviteDetailMODEL
    {
        public int CRAActiviteId { get; set; }
        public System.DateTime DateBegin { get; set; }
        public System.DateTime DateEnd { get; set; }
        public int CRAlibeleColId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string CreationBY { get; set; }
        public Nullable<System.DateTime> modificationDate { get; set; }
        public string ModificationBY { get; set; }

        public virtual CRA_Activite CRA_Activite { get; set; }
        public virtual CRA_LibeleCol CRA_LibeleCol { get; set; }

        public string DateBeginString { get => this.DateBegin.ToShortDateString(); }
        public string DateEndString { get => this.DateEnd.ToShortDateString(); }
    }
}