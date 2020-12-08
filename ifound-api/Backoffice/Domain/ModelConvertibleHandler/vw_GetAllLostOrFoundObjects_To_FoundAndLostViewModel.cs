using ifound_api.Backoffice.Domain.ViewModel;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ifound_api.Backoffice.Domain.ModelConvertibleHandler
{
    public class vw_GetAllLostOrFoundObjects_To_FoundAndLostViewModel : IModelConvertibleHandler<vw_GetAllLostOrFoundObjects, FoundOrLostViewModel>
    {
        public FoundOrLostViewModel Convert(vw_GetAllLostOrFoundObjects model)
        {
            return new FoundOrLostViewModel
            {
                Object = new ObjectViewModel { 
                    ObjectId = model.ObjectId,
                    ObjectName = model.ObjectName,
                    ObjectDescription = model.ObjectDescription,
                    ObjectStatus = model.ObjectStatus,
                    ObjectPhoto = model.ObjectPhoto,
                    ObjectLostLocation = model.ObjectLostLocation,
                    ObjectFoundLocation = model.ObjectFoundLocation,
                    ObjectCreationDate = model.ObjectCreationDate,
                    ObjectLastUpdate = model.ObjectLastUpdate
                },

                ObjectCategory = new CategoryViewModel
                {
                    CategoryId = model.CategoryId,
                    CategoryDescription = model.CategoryDescription
                },

                PersonWhoLost = new PersonViewModel
                {
                    PersonId = model.PersonWhoLost_PersonId,
                    Name = model.PersonWhoLost_Name,
                    Age = model.PersonWhoLost_Age,
                    Nationality = model.PersonWhoLost_Nationality,
                    Telephone = model.PersonWhoLost_Telephone,
                    Email = model.PersonWhoLost_Email
                },

                PersonWhoFound = new PersonViewModel
                {
                    PersonId = model.PersonWhoFound_PersonId,
                    Name = model.PersonWhoFound_Name,
                    Age = model.PersonWhoFound_Age,
                    Nationality = model.PersonWhoFound_Nationality,
                    Telephone = model.PersonWhoFound_Telephone,
                    Email = model.PersonWhoFound_Email
                }
            };
        }
    }
}
