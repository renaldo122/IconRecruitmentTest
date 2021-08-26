using IconRecruitmentTest.Common.Message;
using IconRecruitmentTest.Common.Models.DbModels;
using IconRecruitmentTest.Data.IconDbContext;
using System;
using IconRecruitmentTest.Services.Translate;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace IconRecruitmentTest.Services.Shipping
{
    public class ShippingServices : BaseService, IShippingServices
    {
        private ApplicationDbContext _applicationDbContext;
        public ShippingServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IResponseMessage> SaveShippingData(ShippingData shippingData)
        {
            var response = new ResponseMessage { Success = true,Message= Resources.GetString("SavedSuccessfully") };
            try
            {
                _applicationDbContext.ShippingData.Add(shippingData);
                await  _applicationDbContext.SaveChangesAsync();

            }
            catch(Exception ex){
                response.Success = false;
                response.Message = Resources.GetString("AnErrorOccurredPleaseTryAgain");
                Logger.Error("Save shipping data", "SaveShippingData", ex);
            }
            return response;
        }

        public IList<ShippingData> GetShippingData()
        {
            var data = _applicationDbContext.ShippingData.ToList();
            return data;
        }
    }
}
