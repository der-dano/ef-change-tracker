using YamlDotNet.Serialization;
using System.IO;
using System;

namespace DerDano.EntityFrameworkChangeTracker
{
    public class Yaml<T> where T : class
    {
        public static T GetModel(string yamlPath)
        {
            T model = null;

            try
            {
                using (var reader = new StreamReader(yamlPath))
                {
                    var deserializer = new DeserializerBuilder().Build();
                    model = deserializer.Deserialize<T>(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deserializing input model from " + yamlPath);
                Console.WriteLine(ex);
                model = null;
            }

            if (model == null)
            {
                Console.WriteLine("Error reading " + yamlPath);
            }

            return model;
        }
    }
}