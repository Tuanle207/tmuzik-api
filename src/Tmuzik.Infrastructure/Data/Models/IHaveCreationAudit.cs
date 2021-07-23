using System;

namespace Tmuzik.Infrastructure.Data.Models
{
    public interface IHaveCreationAudit
    {
        DateTime CreationTime { get; set; }
        Guid? CreatorId { get; set; }
    }
}