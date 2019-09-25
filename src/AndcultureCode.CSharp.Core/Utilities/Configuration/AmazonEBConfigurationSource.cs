using Microsoft.Extensions.Configuration;

namespace AndcultureCode.CSharp.Core.Utilities.Configuration
{
    public class AmazonEBConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder) => new AmazonEBConfigurationProvider();
    }
}