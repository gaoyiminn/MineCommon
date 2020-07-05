﻿
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace Ruanmou.MVC5.Utility
{
    public class DIFactory
    {
        public static IUnityContainer GetContainer()
        {
            IUnityContainer container = null;
            //container.RegisterType
            //Microsoft.Practices.Unity.Configuration.UnityConfigurationSection
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            container = new UnityContainer();
            section.Configure(container, "ruanmouContainer");

            return container;
        }
    }
}