using System;

namespace Tmuzik.Common.Models
{
    public interface IHaveCreationAudit
    {
        DateTime CreationTime { get; set; }
        Guid CreatorId { get; set; }
    }
}