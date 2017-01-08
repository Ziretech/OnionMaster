using System;
using System.IO;
using System.Reflection;

namespace OnionMaster
{
    class ResourceFile
    {
        public static string ReadResourceFile(string filename)
        {
            var resourceName = "OnionMaster.Resources." + filename;
            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                var found = String.Join(", ", Assembly.GetExecutingAssembly().GetManifestResourceNames());
                var message = $"Could not find resource: { resourceName }. Found resources: { found }.";
                throw new ArgumentNullException(message, e);
            }
        }
    }
}