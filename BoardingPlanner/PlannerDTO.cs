using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardingPlanner
{
    public class PlannerDTO
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public int HKID { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Vessel { get; set; }
        public string TechnicalGroup { get; set; }
        public DateTime COC { get; set; }
        public string Replacement { get; set; }
        public string Remarks { get; set; }

        public string COCStr
        {
            get
            {
                return COC.ToString("dd-MM-yyyy");
            }

        }
    }

    public class BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RankDTO : BaseDTO
    {

    }

    public class TechnicalGroupDTO : BaseDTO
    {

    }

    public class VesselDTO : BaseDTO
    {

    }

    public class StaffDTO : BaseDTO
    {
        public int HKID { get; set; }

    }
}
