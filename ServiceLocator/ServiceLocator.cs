using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandLineTool
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, List<object>> services = new Dictionary<Type, List<object>>();

        public void Register<TService>(TService service)
        {
            var key = typeof(TService);
            if (!services.ContainsKey(key))
                services.Add(key, new List<object>());
            services[key].Add(service);
        }

        public TService Get<TService>()
        {
            var type = typeof(TService);
            if (services.ContainsKey(type))
                return (TService)services[type].Single();
            else
                throw new InvalidOperationException("Can't resolve service " + type);
        }

        public IEnumerable<TService> GetAll<TService>()
        {
            return services[typeof(TService)].Cast<TService>();
        }
    }
}