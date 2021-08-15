using System;

namespace Tmuzik.Common.Models
{
    public interface IHaveObjectAudit : IHaveCreationAudit
    {
        DateTime LastUpdationTime { get; set; }
        Guid LastUpdator { get; set; }
    }
}