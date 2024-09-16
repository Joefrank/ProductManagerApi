
namespace ProductManager.WebApi.IntegrationTests.Model.Constants
{
    public static class URI
    {
        public const string ProductGetAllEndPoint = "/api/product/GetAll";
        public const string ProductGetAllByColorAsyncEndPoint = "/api/Product/GetAllByColor?color={0}";
        public const string ProductCreateAsyncEndPoint = "/api/Product/CreateAsync";

        public const string HealthCheckEndPoint = "/api/HealthCheck/IsAlive";
    }
}
