using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public  class Cookie
    {
        public Cookie(string name, string value)
        {
            NullValidator.Validate(name, nameof(name));
            NullValidator.Validate(value, nameof(value));

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; init; }
        public string Value { get; init; }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}
