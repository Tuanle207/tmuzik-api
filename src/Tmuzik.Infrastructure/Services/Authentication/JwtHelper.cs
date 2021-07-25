using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Tmuzik.Infrastructure.DependencyInjections;

namespace Tmuzik.Infrastructure.Services.Authentication
{
    public class JwtHelper : ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<JwtHelper> _logger;

        public JwtHelper(IConfiguration configuration, ILogger<JwtHelper> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public void TestDI()
        {
            _logger.LogInformation("hello from JwtHelper");
        }
    }
}