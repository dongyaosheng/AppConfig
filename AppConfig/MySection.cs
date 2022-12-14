using System.Configuration;

namespace AppConfig
{
    public class MySection : ConfigurationSection
    {


        [ConfigurationProperty(nameof(Code))]
        public string Code
        {
            get => base[nameof(Code)].ToString();

        }

        [ConfigurationProperty(nameof(Member))]
        public MyElement Member
        {
            get => base[nameof(Member)] as MyElement;

        }
        [ConfigurationProperty(nameof(Members)), ConfigurationCollection(typeof(MyElement))]
        public MyElementCollection Members
        {
            get => base[nameof(Members)] as MyElementCollection;

        }
    }
}
