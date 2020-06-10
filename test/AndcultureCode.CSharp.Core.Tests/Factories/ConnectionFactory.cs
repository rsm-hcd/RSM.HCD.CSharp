using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Testing.Factories;
using Bogus;

namespace AndcultureCode.CSharp.Core.Tests.Factories
{
    public class ConnectionFactory : Factory
    {
        public override void Define()
        {
            var faker = new Faker();

            this.DefineFactory(() => new Connection
            {
                AdditionalParameters = $"test-additionalparameters-{faker.Random.String()}",
                Database = $"test-database-{faker.Random.String()}",
                Datasource = $"test-datasource-{faker.Random.String()}",
                Password = $"test-password-{faker.Random.String()}",
                UserId = $"test-userid-{faker.Random.String()}"
            });
        }
    }
}
