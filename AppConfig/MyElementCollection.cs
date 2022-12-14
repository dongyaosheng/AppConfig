using System.Configuration;

namespace AppConfig
{
    [ConfigurationCollection(typeof(MyElement))]
    public class MyElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as MyElement).Id;
        }
    }
}
