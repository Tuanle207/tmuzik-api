using System;

namespace Tmuzik.Infrastructure.Models
{
    public interface IHaveCreationAudit
    {
        DateTime CreationTime { get; set; }
        Guid? CreatorId { get; set; }
    }
}