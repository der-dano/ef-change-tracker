using System.Reflection;

namespace DerDano.EntityFrameworkChangeTracker
{
    internal static class ReflectionExtensions
    {
        internal static T GetFieldValue<T>(this object obj, string name)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var field = obj.GetType().GetField(name, bindingFlags);
            return (T)field?.GetValue(obj);
        }
    }
}