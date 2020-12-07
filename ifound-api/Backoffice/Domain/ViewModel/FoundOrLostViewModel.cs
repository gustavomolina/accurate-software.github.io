using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ifound_api.Backoffice.Domain.ViewModel
{
    public class FoundOrLostViewModel : ViewModelBase
    {
        public ObjectViewModel Object { get; set; }
        public CategoryViewModel ObjectCategory { get; set; }
        public PersonViewModel? PersonWhoFound { get; set; }
        public PersonViewModel? PersonWhoLost { get; set; }
    }
    public class ObjectViewModel : ViewModelBase
    {
        public int ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string ObjectDescription { get; set; }
        public string ObjectStatus { get; set; }
        public string ObjectPhoto { get; set; }
        public string ObjectLostLocation { get; set; }
        public string ObjectFoundLocation { get; set; }        
        public string ObjectCreationDate { get; set; }
        public string ObjectLastUpdate { get; set; }
    }
    public class CategoryViewModel : ViewModelBase
    {
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }

    }

    public class PersonViewModel : ViewModelBase
    {
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Nationality { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
