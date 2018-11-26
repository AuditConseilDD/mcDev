using MCSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class CRA_ActiviteDetailMODEL : CRA_ActiviteDetail
    {
        public string DateBeginString { get => this.DateBegin.ToShortDateString(); }
        public string DateEndString { get => this.DateEnd.ToShortDateString(); }
    }
}