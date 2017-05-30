using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemplify.Common;
using Siemplify.Common.Extensions;

namespace Siemplify.Integrations.PaloAlto
{
    public class PaloAltoMetadataProvider : MetadataProviderBase
    {
        public const string ProviderIdentifier = "PaloAlto";
        private List<ModuleSettingsProperty> _requiredSettings = null;

        public PaloAltoMetadataProvider()
        {
            ProviderIcon = "Siemplify.Integrations.PaloAlto.Resources.paloalto.png";
        }

        public override Stream IconStream
        {
            get
            {
                var data = Convert.FromBase64String(IconBase64);
                var ms = new MemoryStream(data);
                return ms;
            }
        }

        public override string Identifier
        {
            get { return ProviderIdentifier; }
        }

        public override string DisplayName
        {
            get { return ProviderIdentifier; }
        }


        public override string Description
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine("https://www.paloaltonetworks.com/");
                sb.AppendLine(
                    @"Breach prevention, with threat information shared across security functions system-wide, and designed to operate in increasingly mobile, modern networks.");
                return sb.ToString();
            }
        }

        public override List<ModuleSettingsProperty> RequiredSettings
        {
            get
            {
                if (_requiredSettings == null)
                {
                    _requiredSettings = new List<ModuleSettingsProperty>
                    {
                        new ModuleSettingsProperty
                        {
                            ModuleName = Identifier,
                            PropertyName = Settings.ApiBaseHost,
                            PropertyDisplayName = Settings.ApiBaseHost,
                            PropertyType = ParamTypeEnum.String
                        },
                        new ModuleSettingsProperty
                        {
                            ModuleName = Identifier,
                            PropertyName = Settings.ApiUserName,
                            PropertyDisplayName = Settings.ApiUserName,
                            PropertyType = ParamTypeEnum.String
                        },
                        new ModuleSettingsProperty
                        {
                            ModuleName = Identifier,
                            PropertyName = Settings.ApiKey,
                            PropertyDisplayName = Settings.ApiKey,
                            PropertyType = ParamTypeEnum.Password
                        }
                    };
                }

                return _requiredSettings;
            }
        }

        public override Task Test(Dictionary<string, string> paramsWithValues)
        {
            var apiBaseHost = paramsWithValues.GetOrDefault(Settings.ApiBaseHost);
            if (apiBaseHost.IsEmpty())
            {
                throw new Exception(string.Format("Not found <{0}> Field.", Settings.ApiBaseHost));
            }

            var apiUsername = paramsWithValues.GetOrDefault(Settings.ApiUserName);
            if (apiUsername.IsEmpty())
            {
                throw new Exception(string.Format("Not found <{0}> Field.", Settings.ApiUserName));
            }

            var apiKey = paramsWithValues.GetOrDefault(Settings.ApiKey);
            if (apiKey.IsEmpty())
            {
                throw new Exception(string.Format("Not found <{0}> Field.", Settings.ApiKey));
            }

            throw new NotImplementedException();
        }
    }
}
