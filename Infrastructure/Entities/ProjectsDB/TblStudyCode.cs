using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.ProjectsDB
{
    public partial class TblStudyCode
    {
        public string Studycode { get; set; }
        public string Batchid { get; set; }
        public DateTime? Enrolldate { get; set; }
        public string Addedby { get; set; }
        public int? Freezed { get; set; }
    }
}
