using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblAccessLog
    {
        public int LogId { get; set; }
        public string Username { get; set; }
        public byte? Action { get; set; }
        public byte? Status { get; set; }
        public DateTime? LogDate { get; set; }
        public string Ip { get; set; }
    }
}
