using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.ProjectsDB
{
    public partial class TblField
    {
        public string Crfid { get; set; }
        public string Controltype { get; set; }
        public string Pformat { get; set; }
        public string Questionid { get; set; }
        public string Submissionvalue { get; set; }
        public int? Blind { get; set; }
        public string Isrequired { get; set; }
        public byte? Ispk { get; set; }
        public string Gridname { get; set; }
        public int? Gridorder { get; set; }
        public string Qn0 { get; set; }
        public string Minvalue { get; set; }
        public string Maxvalue { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }
        public int? Splitrow { get; set; }
        public string Page { get; set; }
        public string Esection { get; set; }
        public int? Qorder { get; set; }
        public string Defaultvalue { get; set; }
        public float? Plabelwidth { get; set; }
        public float? Pctrlwidth { get; set; }
        public string Pstyle { get; set; }
        public string Estyle { get; set; }
        public float? Elabelwidth { get; set; }
        public float? Ectrlwidth { get; set; }
        public string Defunit { get; set; }
        public string Height { get; set; }
        public string Lines { get; set; }
        public string VariableName { get; set; }
    }
}
