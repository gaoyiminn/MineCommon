using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace SOA.WebTest.Utility
{
    public class ContainerFactory
    {

        public static IUnityContainer BuildContainer()
        {
            return _unityContainer; 
        }

        private static IUnityContainer _unityContainer = null;

        static ContainerFactory()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");//找配置文件的路径
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            _unityContainer = new UnityContainer();
            section.Configure(_unityContainer, "WebApiContainer");
        }
    }

}
