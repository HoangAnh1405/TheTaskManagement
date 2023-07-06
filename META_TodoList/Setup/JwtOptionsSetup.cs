using META_TodoList.Models.Jwt_Model;
using Microsoft.Extensions.Options;

namespace META_TodoList.Setup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _config;
        public JwtOptionsSetup(IConfiguration config)
        {
            _config = config;
        }

        public void Configure(JwtOptions options)
        {
            _config.GetSection(SectionName).Bind(options);
        }
    }
}
