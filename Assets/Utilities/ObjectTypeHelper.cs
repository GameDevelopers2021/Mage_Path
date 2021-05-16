using System;
using System.Collections.Generic;
using System.Linq;
using CommonInterfaces;

namespace Utilities
{
    public static class ObjectTypeHelper
    {
        private static readonly Dictionary<string, ObjectType> TypeByName;
        private static readonly string[] TypesNames;

        static ObjectTypeHelper()
        {
            TypeByName = new Dictionary<string, ObjectType>();
            var enumType = typeof(ObjectType);
            TypesNames = Enum.GetNames(enumType);
            TypeByName = TypesNames
                .ToDictionary(name => name, name =>
                {
                    Enum.TryParse<ObjectType>(name, out var value);
                    return value;
                });
        }

        public static bool TryIdentifyObjectType(string objectName, out ObjectType type)
        {
            var typeName = TypesNames.FirstOrDefault(name => objectName.IndexOf(name, StringComparison.Ordinal) != -1);
            
            type = ObjectType.Null;
            
            return typeName != null && Enum.TryParse(typeName, out type);
        }
    }
}