using System;
using System.Collections.Generic;

namespace PortableLibrary.Models
{
    public class BirthdayListModel
    {
        public int date { get; set; }
        public string month { get; set; }
        public string merrageAnyver { get; set; }
        public string memName { get; set; }
        public string memMobile { get; set; }
        public List<DatesModel> Dates { get; set; }
        public double ListHeight { get; set; }
    }
    public class DatesModel
    {
        public string merrageAnyver { get; set; }
        public string memName { get; set; }
        public string memMobile { get; set; }

    }

}
