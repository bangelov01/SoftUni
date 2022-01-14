namespace BasicWebServer.Server.Common
{
    public static class NullValidator
    {
        public static void Validate(object value, string name = null)
        {
            if (value == null)
            {
                name ??= "Value";

                throw new ArgumentException($"{name} cannot be null!");
            }
        }
    }
}
