using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.CrossCutting.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);

        bool IsAdd(string key);

        void Remove(string key);
        void RemoveByPattern(string pattern); 
    }
}