using AutoMapper;

namespace Tmuzik.Core.Interfaces
{
    public interface IAppService
    {
        IMapper Mapper { get; }
        IUnitOfWork UnitOfWork { get; }
        ICurrentUser CurrentUser { get; }
    }
}