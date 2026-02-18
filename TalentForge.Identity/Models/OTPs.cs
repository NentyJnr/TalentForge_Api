using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain.Common;

namespace TalentForge.Identity.Models
{
    public class OTPs : BaseObject
    {
        public string? OTP { get; set; }
        public string? Email { get; set; }
        public string? OTPType { get; set; }
        public string? Token { get; set; }
    }
}
