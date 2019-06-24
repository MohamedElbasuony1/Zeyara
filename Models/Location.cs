using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Location
    {
        public string longt { get; set; }
        public string lat { get; set; }
        public override string ToString()
        {
            return ("longt="+longt+ " lat=" + lat);
        }
    }
}
