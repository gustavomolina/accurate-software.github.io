using ifound_api.Backoffice.Domain.Entity;
using ifound_api.Backoffice.Domain.ViewModel;
using Core.Business;
using Core.IOC;
using Core.Model;
using Core.Repository.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoredProcedureEFCore;
using Core.Exception;

namespace ifound_api.Backoffice.Domain.Business
{
    public interface ILostOrFoundBusiness
    {
        public IEnumerable<FoundOrLostViewModel> GetAllLostOrFoundObjects();
        public void AddLostOrFoundObject(AddFoundOrLostViewModel objectData);
        public void UpdateLostOrFoundObject(UpdateLostOrFoundViewModel objectData);
    }

    public class LostOrFoundBusiness : ILostOrFoundBusiness
    {
        public readonly IUnitOfWork _unitOfWork;
        public LostOrFoundBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddLostOrFoundObject(AddFoundOrLostViewModel objectData)
        {
            _unitOfWork.Context.LoadStoredProc("dbo.sp_AddFoundOrLost")
                                                               .AddParam("ObjectName", objectData.ObjectName)
                                                               .AddParam("ObjectDescription", objectData.ObjectDescription)
                                                               .AddParam("ObjectStatus", objectData.ObjectStatus)
                                                               .AddParam("ObjectPhoto", objectData.ObjectPhoto)
                                                               .AddParam("ObjectFoundLocation", objectData.ObjectFoundLocation)
                                                               .AddParam("ObjectLostLocation", objectData.ObjectLostLocation)
                                                               .AddParam("ObjectCreationDate", objectData.ObjectCreationDate)
                                                               .AddParam("ObjectLastUpdate", objectData.ObjectLastUpdate)
                                                               .AddParam("Category_FK", objectData.CategoryId)
                                                               .AddParam("PersonWhoFound_FK", objectData.PersonWhoFoundId)
                                                               .AddParam("PersonWhoLost_FK", objectData.PersonWhoLostId)
                                                               .AddParam("SuccessOnAdding", out IOutParam<int?> SuccessOnAdding)
                                                               .ExecNonQuery();
            if(SuccessOnAdding.Value == 0)
                throw new ApiValidationException("Erro no processo de inserção do objeto no sistema. Verifique os dados do mesmo!");

        }

        public void UpdateLostOrFoundObject(UpdateLostOrFoundViewModel objectData)
        {
            _unitOfWork.Context.LoadStoredProc("dbo.sp_UpdateFoundOrLost")
                                                               .AddParam("ObjectId", objectData.ObjectId)
                                                               .AddParam("ObjectName", objectData.ObjectName)
                                                               .AddParam("ObjectDescription", objectData.ObjectDescription)
                                                               .AddParam("ObjectStatus", objectData.ObjectStatus)
                                                               .AddParam("ObjectPhoto", objectData.ObjectPhoto)
                                                               .AddParam("ObjectFoundLocation", objectData.ObjectFoundLocation)
                                                               .AddParam("ObjectLostLocation", objectData.ObjectLostLocation)
                                                               .AddParam("ObjectCreationDate", objectData.ObjectCreationDate)
                                                               .AddParam("ObjectLastUpdate", objectData.ObjectLastUpdate)
                                                               .AddParam("Category_FK", objectData.CategoryId)
                                                               .AddParam("PersonWhoFound_FK", objectData.PersonWhoFoundId)
                                                               .AddParam("PersonWhoLost_FK", objectData.PersonWhoLostId)
                                                               .AddParam("SuccessOnUpdating", out IOutParam<int?> SuccessOnUpdating)
                                                               .ExecNonQuery();
            if (SuccessOnUpdating.Value == 0)
                throw new ApiValidationException("Erro no processo de atualização dos dados do objeto no sistema!");
        }

        public IEnumerable<FoundOrLostViewModel> GetAllLostOrFoundObjects()
        {
            IQueryBusiness<vw_GetAllLostOrFoundObjects> queryLostOrFoundObjects = DependencyResolution.Instance.GetInstance<IQueryBusiness<vw_GetAllLostOrFoundObjects>>();
            var lostOrFoundObjectList = queryLostOrFoundObjects.List().ToList();
            IEnumerable<FoundOrLostViewModel> lostOrFoundViewModelList = lostOrFoundObjectList.Select(i => i.Convert<vw_GetAllLostOrFoundObjects, FoundOrLostViewModel>());
            return lostOrFoundViewModelList;
        }        
    }
}
