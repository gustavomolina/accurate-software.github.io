using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ifound_api.Backoffice.Domain.ViewModel
{
    public class vw_GetAllLostOrFoundObjects : ModelBase
    {
        public int ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string ObjectDescription { get; set; }
        public string ObjectStatus { get; set; }
        public string ObjectPhoto { get; set; }
        public string ObjectFoundLocation { get; set; }
        public string ObjectLostLocation { get; set; }
        public string ObjectCreationDate { get; set; }
        public string ObjectLastUpdate { get; set; }
        public string CategoryDescription { get; set; }
        public int CategoryId { get; set; }
        public int PersonWhoLost_PersonId { get; set; }
        public string PersonWhoLost_Name { get; set; }
        public Nullable<int> PersonWhoLost_Age { get; set; }
        public string PersonWhoLost_Nationality { get; set; }
        public string PersonWhoLost_Telephone { get; set; }
        public string PersonWhoLost_Email { get; set; }
        public int PersonWhoFound_PersonId { get; set; }
        public string PersonWhoFound_Name { get; set; }
        public Nullable<int> PersonWhoFound_Age { get; set; }
        public string PersonWhoFound_Nationality { get; set; }
        public string PersonWhoFound_Telephone { get; set; }
        public string PersonWhoFound_Email { get; set; }
    }
}
