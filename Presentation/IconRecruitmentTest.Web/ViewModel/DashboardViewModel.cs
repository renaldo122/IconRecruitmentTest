using IconRecruitmentTest.Common.Models;
using System;
using System.Collections.Generic;

namespace IconRecruitmentTest.Web.ViewModel
{
    public class DashboardViewModel
    {
        public DashboardViewModel() {
            companyOrderData = new List<CompanyOrderData>();
            language = new List<Language>();
        }
        public List<CompanyOrderData> companyOrderData { get; set; }
        public List<Language> language { get; set; }
    }

    public class CompanyOrderData
    {
        public String companyName { get; set; }
        public int numberOfOrders { get; set; }
        public float totalPrice { get; set; }
    }   
  }
