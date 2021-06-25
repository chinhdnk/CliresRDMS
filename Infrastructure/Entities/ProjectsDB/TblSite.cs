using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.ProjectsDB
{
    public partial class TblSite
    {
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string Country { get; set; }
        public int? Target { get; set; }
        public bool? Freeze { get; set; }
    }
}
