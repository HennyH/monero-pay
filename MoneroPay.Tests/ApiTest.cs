using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using Xunit;
using Xunit.Abstractions;

namespace MoneroPay.Tests
{
    public abstract class ApiTestFixture : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly HttpClient _client;
        protected readonly ApiWebApplicationFactory _factory;
        protected readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web);
        protected readonly ITestOutputHelper _output;

        public ApiTestFixture(ITestOutputHelper outputHelper, ApiWebApplicationFactory factory)
        {
            this._factory = factory;
            this._factory.OutputHelper = outputHelper;
            this._client = factory.CreateClient();
            this._output = outputHelper;
        }

        protected T GetRequiredService<T>()
            where T : class
        {
            return this._factory.Services.GetRequiredService<T>();
        }
    }
}
