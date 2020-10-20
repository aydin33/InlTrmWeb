using System;
using System.Collections.Generic;

namespace InlTrmWeb.Models
{
    public partial class Attachments
    {
        public Attachments()
        {
            Costs = new HashSet<Costs>();
        }

        public int AttachId { get; set; }
        public byte[] File { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Costs> Costs { get; set; }
    }
}
