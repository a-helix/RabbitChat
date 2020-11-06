using System;
using System.Collections.Generic;

namespace RabbitChat
{
    public class RabbitServerEmulator
    {
        private static Dictionary<string, string> _users = new Dictionary<string, string>()

        {
            { "test", "test" }
        };
        private static Dictionary<string, string> _cache = new Dictionary<string, string>();

        public bool ValidUser(string userName, string password)
        {
            if (_users.TryGetValue(userName, out password))
            {
                return true;
            }
            throw new Exception("RabbitServerEmulator. Invalid login or password.");
        }

        public void Save(string key, string value)
        {
            _cache.Add(key, value);
        }

        public string Send(string key)
        {
            return _cache[key];
        }
    }
}
