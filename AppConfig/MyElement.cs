using System.Configuration;

namespace AppConfig
{
    public class MyElement : ConfigurationElement
    {
        [ConfigurationProperty(nameof(Id))]
        public string Id
        {
            get => this[nameof(Id)].ToString();
        }
    }
}