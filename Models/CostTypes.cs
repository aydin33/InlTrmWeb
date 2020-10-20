using System;
using System.Collections.Generic;

namespace InlTrmWeb.Models
{
    public partial class CostTypes
    {
        public CostTypes()
        {
            Costs = new HashSet<Costs>();
        }

        public int CostTypeId { get; set; }
        public string CostName { get; set; }

        public virtual ICollection<Costs> Costs { get; set; }
    }
}
