using System;

namespace Tmuzik.Infrastructure.Models
{
    public interface IHaveObjectAudit : IHaveCreationAudit
    {
        DateTime LastUpdationTime { get; set; }
        Guid LastUpdator { get; set; }
    }
}