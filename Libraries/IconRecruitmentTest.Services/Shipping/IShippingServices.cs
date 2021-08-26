using IconRecruitmentTest.Common.Message;
using IconRecruitmentTest.Common.Models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IconRecruitmentTest.Services.Shipping
{
    public interface IShippingServices
    {

        /// <summary>
        /// SaveShippingData
        /// </summary>
        /// <param name="shippingData"></param>
        /// <returns></returns>
         Task<IResponseMessage> SaveShippingData(ShippingData shippingData);


        /// <summary>
        /// GetShippingData
        /// </summary>
        /// <returns></returns>
        IList<ShippingData> GetShippingData();
    }
}
