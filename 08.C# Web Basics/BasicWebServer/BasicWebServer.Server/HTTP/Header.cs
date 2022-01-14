using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            NullValidator.Validate(name, nameof(name));
            NullValidator.Validate(value, nameof(value));

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; init; }

        public string Value { get; init; }
    }
}
