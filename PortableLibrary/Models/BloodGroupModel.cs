using System;
using System.Collections.Generic;

namespace PortableLibrary.Models
{
    public class BloodGroupModel
    {
        public string memName { get; set; }
        public string memMobile { get; set; }
        public string memBG { get; set; }
        public string BloodGroup { get; set; }
        public string id { get; set; }
        public List<DatesModel> groupList { get; set; } 
        public double ListHeight { get; set; }


    }
}
