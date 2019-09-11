﻿using Microsoft.Extensions.Configuration;
using Penguin.Configuration.Abstractions;
using Penguin.Extensions.String;
using System.Collections.Generic;

namespace Penguin.Configuration.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class IConfigurationProviderExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        #region Methods
        /// <summary>
        /// Calls TryGet on an IConfiguration provider
        /// </summary>
        /// <param name="provider">The source provider</param>
        /// <param name="key">The gey to search for</param>
        /// <returns>The value (or null) of the key</returns>
        public static string Get(this IConfigurationProvider provider, string key)
        {
            if (provider.TryGet(key, out string value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a string value from an IConfigurationProvider as a Dictionary, assuming its delimited in Key=Value; notation
        /// </summary>
        /// <param name="provider">The provider to use as a source</param>
        /// <param name="key">The Key to search for</param>
        /// <returns>A dictionary representing the key value pairs found in the configuration value</returns>
        public static Dictionary<string, string> GetDictionary(this IConfigurationProvider provider, string key)
        {
            string v = provider.Get(key);

            if (v is null)
            {
                return null;
            }
            else
            {
                return v.ToDictionary();
            }
        }

        /// <summary>
        /// Returns a string value from an IProvideConfigurations as a Dictionary, assuming its delimited in Key=Value; notation
        /// </summary>
        /// <param name="provider">The provider to use as a source</param>
        /// <param name="key">The Key to search for</param>
        /// <returns>A dictionary representing the key value pairs found in the configuration value</returns>
        public static Dictionary<string, string> GetDictionary(this IProvideConfigurations provider, string key)
        {
            string v = provider.GetConfiguration(key);

            if (v is null)
            {
                return null;
            }
            else
            {
                return v.ToDictionary();
            }
        }

        #endregion Methods
    }
}