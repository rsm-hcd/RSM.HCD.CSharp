using RSM.HCD.CSharp.Core.Models;
using RSM.HCD.CSharp.Testing.Factories;
using Bogus;

namespace RSM.HCD.CSharp.Core.Tests.Factories
{
    public class ConnectionFactory : Factory
    {
        public override void Define()
        {
            var faker = new Faker(); // TODO: Abstract into our base Factory in RSM.HCD.CSharp.Testing

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
