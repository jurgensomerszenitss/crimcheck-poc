using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Grader.Api.Infrastructure
{
    public class SchemaNameResolver
    {
        public static string GetSchemaName(Type type)
        {
            if ( type.Attributes.HasFlag(TypeAttributes.NestedPublic) )
            {
                return $"{type.DeclaringType.Name}{type.Name}";
            }
            else
            {
                return type.Name;
            }
        }
    }
}
