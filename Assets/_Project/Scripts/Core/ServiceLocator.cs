using System;
using System.Collections.Generic;

namespace NexusForge.Core
{
    /// <summary>
    /// Lightweight service locator for global system access without tight coupling.
    /// Register services at boot, resolve them anywhere.
    /// </summary>
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        /// <summary>Register a service instance for the given type.</summary>
        public static void Register<T>(T service) where T : class
        {
            _services[typeof(T)] = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>Resolve a registered service. Throws if not found.</summary>
        public static T Get<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var service))
                return (T)service;
            throw new InvalidOperationException($"Service of type {typeof(T).Name} is not registered.");
        }

        /// <summary>Try to resolve a service without throwing.</summary>
        public static bool TryGet<T>(out T service) where T : class
        {
            if (_services.TryGetValue(typeof(T), out var obj))
            {
                service = (T)obj;
                return true;
            }
            service = null;
            return false;
        }

        /// <summary>Clear all registered services. Call on application quit.</summary>
        public static void Reset() => _services.Clear();
    }
}
