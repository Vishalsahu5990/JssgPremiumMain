using System;
using System.Collections.Generic;

namespace PortableLibrary.Models
{
    public class MemberModel
    {
        public string id { get; set; }
        public string memName { get; set; }
        public string memBG { get; set; }
        public string memPhoto { get; set; }
        public string memMobile { get; set; }
        public List<child> child { get; set; }
    }
    public class child
    {
        public string childName { get; set; }
        public string childClass { get; set; }
        public string childDOB { get; set; }
    }
}
