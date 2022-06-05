using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault_TecSettlerManager.Models
{
    public record Buff
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public SPECIALStat SpecialStat { get; set; } = SPECIALStat.UNSET;
        public int ValueModifier { get; set; } = 0;
    }
}
