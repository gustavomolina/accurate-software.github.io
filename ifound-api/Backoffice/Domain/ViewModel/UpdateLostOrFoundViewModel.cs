using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ifound_api.Backoffice.Domain.ViewModel
{
    public class UpdateLostOrFoundViewModel
    {
        //ID Only for update
        public int ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string ObjectDescription { get; set; }
        public string ObjectStatus { get; set; }
        public string ObjectPhoto { get; set; }
        public string ObjectLostLocation { get; set; }
        public string ObjectFoundLocation { get; set; }
        public string ObjectCreationDate { get; set; }
        public string ObjectLastUpdate { get; set; }
        public int? CategoryId { get; set; }
        public int? PersonWhoFoundId { get; set; }
        public int? PersonWhoLostId { get; set; }
    }
}
