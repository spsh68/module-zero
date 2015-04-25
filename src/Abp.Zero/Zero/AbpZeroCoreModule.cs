﻿using System.Reflection;
using Abp.Localization.Sources;
using Abp.Localization.Sources.Xml;
using Abp.Modules;
using Abp.Zero.Configuration;

namespace Abp.Zero
{
    /// <summary>
    /// ABP zero core module.
    /// </summary>
    public class AbpZeroCoreModule : AbpModule
    {
        /// <summary>
        /// Current version of the zero module.
        /// </summary>
        public const string CurrentVersion = "0.5.15.3";

        public override void PreInitialize()
        {
            IocManager.Register<IRoleManagementConfig, RoleManagementConfig>();
            IocManager.Register<IAbpZeroConfig, AbpZeroConfig>();

            Configuration.Settings.Providers.Add<AbpZeroSettingProvider>();

            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    AbpZeroConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(), "Abp.Zero.Localization.Source"
                        )));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

    public class AbpZeroConsts
    {
        /// <summary>
        /// "AbpZero"
        /// </summary>
        public const string LocalizationSourceName = "AbpZero";
    }
}
