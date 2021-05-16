using System;
using System.Linq;
using System.Reflection;

namespace MoneroPay.API.Configuration
{
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class CliParameterAttribute : System.Attribute
    {
        // See the attribute guidelines at
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string name;
        
        // This is a positional argument
        public CliParameterAttribute(string name)
        {
            this.name = name;
        }
        
        public string Name
        {
            get { return name; }
        }
    }

    public static class CliParameterHelpers
    {
        public static string[] FormatCliParameter(CliParameterAttribute parameter, object? value)
        {
            if (value == null) return new string[0];
            if (value is bool boolValue) return boolValue ? new string[] { parameter.Name } : new string[0];
            return new string[] { parameter.Name, value.ToString() ?? string.Empty };
        }

        public static string[] ToArgumentList<T>(T obj)
        {
            var propertieValueAndCliParameterPairs = typeof(T)
                .GetProperties()
                .Select(p => (Property: p, CliParameterAttr: p.GetCustomAttribute<CliParameterAttribute>()))
                .Where(x => x.CliParameterAttr != null)
                .Select(x => (Value: x.Property.GetValue(obj), CliParameterAttr: x.CliParameterAttr!));
            var fieldValueAndCliParameterPairs = typeof(T)
                .GetFields()
                .Select(f => (Field: f, CliParameterAttr: f.GetCustomAttribute<CliParameterAttribute>()))
                .Where(x => x.CliParameterAttr != null)
                .Select(x => (Value: x.Field.GetValue(obj), CliParameterAttr: x.CliParameterAttr!));;
            var valueAndCliparamterPairs = propertieValueAndCliParameterPairs.Concat(fieldValueAndCliParameterPairs);
            return valueAndCliparamterPairs
                .SelectMany(x => FormatCliParameter(x.CliParameterAttr, x.Value))
                .ToArray();
        }
    }
}