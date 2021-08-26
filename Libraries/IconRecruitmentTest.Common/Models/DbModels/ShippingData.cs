using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IconRecruitmentTest.Common.Models.DbModels
{
   public class ShippingData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public int companyType { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public float depth { get; set; }
        public float weight { get; set; }
        public float totaVolume { get; set; }
        public float totalPrice { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
