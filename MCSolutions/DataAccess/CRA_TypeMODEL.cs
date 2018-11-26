using MCSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class CRA_TypeMODEL : CRA_Type
    {
        public string CreationDateString { get => this.CreationDate.ToShortDateString(); }
        public string DeletionDateString { get => this.DeletionDate.HasValue? this.DeletionDate.Value.ToShortDateString() : string.Empty; }
    }
}