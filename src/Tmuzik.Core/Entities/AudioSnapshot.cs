using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class AudioSnapshot : Entity
    {
        public Guid AudioId { get; set; }
        public int Plays { get; set; }
        public int Loves { get; set; }

        public Audio Audio { get; set; }
    }
}