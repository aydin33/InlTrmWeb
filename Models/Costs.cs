using System;
using System.Collections.Generic;

namespace InlTrmWeb.Models
{
    public partial class Costs
    {
        public int CostId { get; set; }
        public int CostTypeId { get; set; }
        public int CostEmpId { get; set; }
        public DateTime CostDate { get; set; }
        public string CostDescription { get; set; }
        public decimal CostAmount { get; set; }
        public int? AttachId { get; set; }
        public DateTime Created { get; set; }

        public virtual Attachments Attach { get; set; }
        public virtual Employee CostEmp { get; set; }
        public virtual CostTypes CostType { get; set; }
    }
}
