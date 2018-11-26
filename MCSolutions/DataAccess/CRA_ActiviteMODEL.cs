using MCSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class CRA_ActiviteMODEL : CRA_Activite
    {
        public string CreationDateString { get => this.CreationDate.ToShortDateString(); }
        public string PeriodBeginString { get => this.PeriodBegin.HasValue? this.PeriodBegin.Value.ToShortDateString() : string.Empty; }
        public string PeriodEndString { get => this.PeriodEnd.HasValue? this.PeriodEnd.Value.ToShortDateString() : string.Empty; }
    }
}