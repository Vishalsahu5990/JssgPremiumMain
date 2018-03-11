using System;
using System.Collections.Generic;

namespace PortableLibrary.Models
{
    public class MembersDetailsModel
    {
        public string id { get; set; }
        public string memName { get; set; }
        public string memMobile { get; set; }
        public string memBG { get; set; }
        public string memPhoto { get; set; }
        public string merrageAnyver { get; set; }
        public string dob_Husband { get; set; }
        public string dob_Wife { get; set; }
        public string business { get; set; }
        public string businessAddr { get; set; }
        public string residenceAddr { get; set; }
        public string businessNum { get; set; }
        public string residenceNum { get; set; }
        public string husbendContact { get; set; }
        public string wifeContact { get; set; }
        public string email{ get; set; }
        public string website { get; set; }
        public string wifeBG { get; set; }

        public List<child> child { get; set; }
    }
   
}
