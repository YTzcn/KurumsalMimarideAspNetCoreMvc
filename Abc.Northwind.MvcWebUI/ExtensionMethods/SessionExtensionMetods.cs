﻿using Microsoft.AspNetCore.Razor.Language.Extensions;
using Newtonsoft.Json;

namespace Abc.Northwind.MvcWebUI.ExtensionMethods
{
    public static class SessionExtensionMetods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            T value = JsonConvert.DeserializeObject<T>(objectString);
            return value;
        }
    }
}
