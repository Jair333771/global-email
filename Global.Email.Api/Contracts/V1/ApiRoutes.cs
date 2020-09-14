namespace Global.Email.Api.Contracts.V1
{
    public static class ApiRoutes
    {
        private static readonly string _baseUrl = "http://localhost:58994/api/";

        public static class SendHeader
        {
            private static readonly string _controllerUrl = string.Concat(_baseUrl, typeof(SendHeader).Name);

            public static readonly string GetAll = _controllerUrl;

            public static readonly string GetById = string.Concat(_controllerUrl, "/{id}");

            public static readonly string Add = _controllerUrl;
        }

        public static class NetCoreUser
        {
            private static readonly string _controllerUrl = string.Concat(_baseUrl, typeof(NetCoreUser).Name);

            public static readonly string Add = _controllerUrl;
        }

        public static class Token
        {
            private static readonly string _controllerUrl = string.Concat(_baseUrl, typeof(Token).Name);

            public static readonly string Authentication = _controllerUrl;

            public static readonly string GetUser = _controllerUrl;

            public static readonly string GenerateToken = _controllerUrl;
        }
    }
}