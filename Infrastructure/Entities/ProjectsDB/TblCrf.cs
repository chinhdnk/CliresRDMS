using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.ProjectsDB
{
    public partial class TblCrf
    {
        public string Crfid { get; set; }
        public byte? Entrymode { get; set; }
        public byte? Isrepeat { get; set; }
        public string Relativecrf { get; set; }
        public int? Crforder { get; set; }
        public bool? Needcustom { get; set; }
        public string Crfformat { get; set; }
        public string Keyfields { get; set; }
    }
}
