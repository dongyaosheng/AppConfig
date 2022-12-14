using System.Configuration;

namespace AppConfig
{
    public class MyGroup : ConfigurationSectionGroup
    {
        [ConfigurationProperty(nameof(MySection))]
        public MySection MySection { get => this.Sections[nameof(MySection)] as MySection; }
    }
}