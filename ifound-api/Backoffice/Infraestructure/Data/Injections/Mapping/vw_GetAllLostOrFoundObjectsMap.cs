using ifound_api.Backoffice.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ifound_api.Backoffice.Infraestructure.Data.Injections.Mapping
{
    public class vw_GetAllLostOrFoundObjectsMap : ISGPDataEntityTypesConfiguration<vw_GetAllLostOrFoundObjects>
    {
        public void Configure(EntityTypeBuilder<vw_GetAllLostOrFoundObjects> builder)
        {
            builder.ToTable("vw_GetAllLostOrFoundObjects");
            builder.HasNoKey();
        }
    }
}
