using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tmuzik.Core.Interfaces;

namespace Tmuzik.Core.Services
{
    public class AppService : IAppService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private ICurrentUser _currentUser;
        private IServiceProvider _serviceProvider;

        public AppService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMapper Mapper =>
            _mapper ?? (_mapper = _serviceProvider.GetRequiredService<IMapper>());

        public IUnitOfWork UnitOfWork =>
            _unitOfWork ?? (_unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>());

        public ICurrentUser CurrentUser =>
            _currentUser ?? (_currentUser = _serviceProvider.GetRequiredService<ICurrentUser>());
    }
}