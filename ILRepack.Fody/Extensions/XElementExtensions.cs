using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Fody;

internal static class XElementExtensions
{
    public static bool ReadBoolAttribute(this XElement config, string nodeName, bool @default)
    {
        return config.ReadBoolAttribute(nodeName) ?? @default;
    }

    public static bool? ReadBoolAttribute(this XElement config, string nodeName)
    {
        var attribute = config.Attribute(nodeName);
        if (attribute is not null)
        {
            try
            {
                return XmlConvert.ToBoolean(attribute.Value.ToLowerInvariant());
            }
            catch
            {
                throw new WeavingException(
                    $"Could not parse '{nodeName}' from '{attribute.Value}'."
                );
            }
        }

        return null;
    }

    public static int ReadIntegerAttribute(this XElement config, string nodeName, int @default)
    {
        return config.ReadIntegerAttribute(nodeName) ?? @default;
    }

    public static int? ReadIntegerAttribute(this XElement config, string nodeName)
    {
        var attribute = config.Attribute(nodeName);
        if (attribute is not null)
        {
            try
            {
                return XmlConvert.ToInt32(attribute.Value.ToLowerInvariant());
            }
            catch
            {
                throw new WeavingException(
                    $"Could not parse '{nodeName}' from '{attribute.Value}'."
                );
            }
        }

        return null;
    }
}
