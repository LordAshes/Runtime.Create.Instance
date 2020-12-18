using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Runtime
{
    public static class Create
    {
        /// <summary>
        /// Method for getting a class instance based on a interface name specification and a DLL specification. With support for optional construction parameters.
        /// </summary>
        /// <param name="interfaceName">Full Name of the interface to be instanced</param>
        /// <param name="dll">Path and file name of the external DLL containing the interface instance</param>
        /// <param name="construction">Optional array of objects holding the construction parameters (defaults to null)</param>
        /// <returns>Dynamic object holding a implementation instance of the specified interface</returns>
        public static dynamic Instance(string interfaceName, string dll, object[] construction = null)
        {
            // Load the specified assembly
            Assembly aby = Assembly.LoadFrom(dll);
            // Search through the exposed types
            foreach (Type type in aby.GetExportedTypes())
            {
                // Search through the type interfaces
                foreach (Type iface in type.GetInterfaces())
                {
                    // Check for a match against the specified interface
                    if (iface.FullName == interfaceName)
                    {
                        // Attempt to instance the type using the provided constructor parameters (or null if not provided). Return type as a dynamic.
                        return Activator.CreateInstance(type, construction);
                    }
                }
            }
            return null;
        }
    }

    /// <summary>
    /// Method for getting a class instance based on a interface specification and a DLL specification. With support for optional construction parameters.
    /// </summary>
    /// <typeparam name="T">Interface specification</typeparam>
    public static class Create<T>
    {
        /// <summary>
        /// Method for getting a class instance based on a interface specification and a DLL specification. With support for optional construction parameters.
        /// </summary>
        /// <param name="dll">Path and file name of the external DLL containing the interface instance</param>
        /// <param name="construction">Optional array of objects holding the construction parameters (defaults to null)</param>
        /// <returns>Dynamic object holding a implementation instance of the specified interface</returns>
        public static T Instance(string dll, object[] construction = null)
        {
            // Process getting interface implementation instance the same way as when the interface name is specified but then cast it to the appropriate type
            return (T)Runtime.Create.Instance(typeof(T).FullName, dll, construction);
        }
    }
}
