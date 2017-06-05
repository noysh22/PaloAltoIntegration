using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Siemplify.Integrations.PaloAlto.API
{
    public static class PaloAltoApiUrlBuilder
    {
        private static string PaloaltoApiRequestFormat = @"?type={0}&{1}";

        private static string BuildApiCmdXml(List<string> commandList)
        {
            var commandXml = new XElement(commandList.First());
            var root = commandXml;
            foreach (var cmd in commandList.Skip(1))
            {
                var nextElement = new XElement(cmd);
                root.Add(nextElement);
                root = nextElement;
            }

            return commandXml.ToString(SaveOptions.DisableFormatting);
            ;        }

        public static string BuildApiRequest(ApiRequestTypes type,
            params KeyValuePair<string, object>[] additionalParams)
        {
            string additionalParamsString;

            switch (type)
            {
                case ApiRequestTypes.OP:
                    additionalParamsString = string.Join("&",
                        additionalParams.Select(pair =>
                        {
                            if (pair.Key.Equals("cmd"))
                            {
                                return string.Format("{0}={1}", pair.Key, BuildApiCmdXml((List<string>) pair.Value));

                            }
                            return string.Format("{0}={1}", pair.Key, pair.Value);
                        }));
                    break;
                default:
                    additionalParamsString = string.Join("&",
                        additionalParams.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value)));
                    break;

            }

            var request = string.Format(PaloaltoApiRequestFormat, type.ToString().ToLower(),
                additionalParamsString);

            return request;
        }
    }
}