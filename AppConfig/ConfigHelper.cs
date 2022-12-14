using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AppConfig
{
    public class ConfigHelper
    {
        public string GetAppSettingValue(string appSettingName)
        {
            return ConfigurationManager.AppSettings.AllKeys.FirstOrDefault(item =>
                  item.Equals(appSettingName)) != null ? ConfigurationManager.AppSettings[appSettingName] : null;

        }
        /// <summary>
        /// 获取所有的Appsetting
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAppSettingValue()
        {
            var result = new Dictionary<string, string>();
            foreach (var appSettingKey in ConfigurationManager.AppSettings.AllKeys)
            {
                result[appSettingKey] = ConfigurationManager.AppSettings[appSettingKey];
            }

            return result;
        }

        public string GetConnectString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
            ;
        }

        public string GetMySectionCode()
        {
            return (ConfigurationManager.GetSection("MySection") as MySection)?.Code;
        }
        public string GetMySectionMember()
        {
            return (ConfigurationManager.GetSection("MySection") as MySection)?.Member?.Id;
        }

        public int GetMySectionMembers()
        {
            return (int)(ConfigurationManager.GetSection("MySection") as MySection)?.Members?.Count;
        }

        public int GetMySectionMembersInGroup()
        {
            return (int)(ConfigurationManager.GetSection("MyGroup/MySection") as MySection)?.Members?.Count;
        }
        public int GetMySectionMembersInGroupByOpenConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
            var group = (MyGroup)config.GetSectionGroup
                ("MyGroup");
            return group.MySection.Members.Count;
        }

        public int GetMySectionMembersInGroupByOpenOtherConfig()
        {
            ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap() { ExeConfigFilename = @".\App1.config" };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap,
                ConfigurationUserLevel.None);
            var group = (MyGroup)config.GetSectionGroup
                ("MyGroup");
            return group.MySection.Members.Count;
        }
    }
}
