using Core.Exception;
using Core.IOC;
using ifound_api.Backoffice.Domain.Business;
using ifound_api.Backoffice.Domain.ViewModel;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ifound_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LostOrFoundController : Controller
    {
        [EnableQuery]
        [HttpGet]
        [AllowAnonymous]
        [Route("GetAllObjects")]
        public IEnumerable<FoundOrLostViewModel> GetAllObjects()
        {
            if (ModelState.IsValid)
            {
                ILostOrFoundBusiness queryLostOrFoundObjects = DependencyResolution.Instance.GetInstance<ILostOrFoundBusiness>();
                return queryLostOrFoundObjects.GetAllLostOrFoundObjects();
            }
            else
                throw new ApiValidationException(ModelState);                    
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("AddObject")]
        public async Task<ActionResult> AddObject([FromBody] AddFoundOrLostViewModel model)
        {
            if (ModelState.IsValid)
            {
                ILostOrFoundBusiness lostOrFoundObjectsBusiness = DependencyResolution.Instance.GetInstance<ILostOrFoundBusiness>();
                Boolean success = lostOrFoundObjectsBusiness.AddLostOrFoundObject(model);
                if(success)
                    return Ok();
                else
                    throw new ApiValidationException("Error to add object in the database!");
            }
            else
                throw new ApiValidationException(ModelState);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("UpdateObject")]
        public async Task<ActionResult> UpdateObject([FromBody] UpdateLostOrFoundViewModel model)
        {
            if (ModelState.IsValid)
            {
                ILostOrFoundBusiness lostOrFoundObjectsBusiness = DependencyResolution.Instance.GetInstance<ILostOrFoundBusiness>();
                Boolean success = lostOrFoundObjectsBusiness.UpdateLostOrFoundObject(model);
                if(success)
                    return Ok();
                else
                    throw new ApiValidationException("Error to update object in the database!");
            }
            else
                throw new ApiValidationException(ModelState);
        }
    }
}
