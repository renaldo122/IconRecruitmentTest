using IconRecruitmentTest.Common.Common;
using IconRecruitmentTest.Web.Common;
using IconRecruitmentTest.Web.ViewModel;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using IconRecruitmentTest.Services.Translate;

namespace IconRecruitmentTest.Web.Extensions
{
    public static class HtmlExtensions
    {

        /// <summary>
        /// Create label html content 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static IHtmlContent LabelDisplayName(this IHtmlHelper html, string id, string displayName)
        {
            var builder = new TagBuilder("label");
            builder.MergeAttribute("id", id);
            builder.InnerHtml.Append(displayName);
            string result;
            using (var writer = new StringWriter()) {
                builder.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = writer.ToString();
            }
            return new HtmlString(result);
        }

        /// <summary>
        /// Create Input element html content with different attributes
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IHtmlContent InputElementNumber(this IHtmlHelper html, string id, string name, LogisticsCompanyViewModel model, int parcelType,float defaultValue)
        {
            var builder = new TagBuilder("input");

            builder.MergeAttribute("id", id);
            builder.MergeAttribute("type", "number");
            builder.MergeAttribute("name", id);
            builder.MergeAttribute("class", "form-control");
            builder.MergeAttribute("placeholder", Resources.GetString("PleaseEnterYour")+" " + name.ToLower() + " *");
            builder.MergeAttribute("required", "required");
            builder.MergeAttribute("data-msg", "");
            if(parcelType== (int)ParcelType.Weight)  {
                var minValue = LogisticsCompanyCalculationData.GetMinValueBasedOnLogisticCompany(model,(int)MinMaxType.Min);
                var maxValue = LogisticsCompanyCalculationData.GetMinValueBasedOnLogisticCompany(model, (int)MinMaxType.Max);
                builder.MergeAttribute("min", minValue.ToString());
                builder.MergeAttribute("max", maxValue.ToString());
            }
            builder.MergeAttribute("value", defaultValue.ToString());
            builder.MergeAttribute("oninput", "LogisticsCompany.OnChangeInputElementNumber()");
            string result;
            using (var writer = new StringWriter())
            {
                builder.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = writer.ToString();
            }
            return new HtmlString(result);

        }



        /// <summary>
        /// Create button html element for display information based on validation
        /// </summary>
        /// <param name="html"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IHtmlContent ButtonInfoElement(this IHtmlHelper html, string Id,LogisticsCompanyViewModel model, int parcelType,int companyInfo)
        {
            var dataContent = LogisticsCompanyCalculationData.GetContentInfo(model.inputData.logisticsCompany, parcelType, companyInfo);

            var builder = new TagBuilder("button");
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("id", Id);
            builder.MergeAttribute("class", companyInfo == (int)CompanyInfo.ParcelInfo ? "CssButtonPopover" : "CssButtonPopover CssLabelValidation");
            builder.MergeAttribute("data-toggle", "popover");
            builder.MergeAttribute("data-html", "true");
            builder.MergeAttribute("title", companyInfo==(int)CompanyInfo.ParcelInfo ? Resources.GetString("Prices") : Resources.GetString("Validation"));
            builder.MergeAttribute("data-content", dataContent);
            TagBuilder icon = new TagBuilder("i");
            icon.MergeAttribute("class", companyInfo == (int)CompanyInfo.ParcelInfo ? "fa fa-info-circle" : "fa fa-exclamation-triangle");
            builder.InnerHtml.AppendHtml(icon);
            string result;
            using (var writer = new StringWriter()) {
                builder.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = writer.ToString();
            }
            return new HtmlString(result); 
        }

    }
}
