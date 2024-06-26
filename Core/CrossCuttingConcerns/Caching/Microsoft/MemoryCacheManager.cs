﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chinook_Backend.CrossCuttingConcerns.Caching.Microsoft
{
	public class MemoryCacheManager : ICacheManager
	{
		private IMemoryCache _memoryCache;
		private readonly List<string> _cacheKeys;
		public MemoryCacheManager(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
			_cacheKeys = new List<string>();
		}

		public void Add(string key, object value, int duration)
		{
			_memoryCache.Set(key,value,TimeSpan.FromMinutes(duration));
			
		}

		public T Get<T>(string key)
		{
			return _memoryCache.Get<T>(key);
		}

		public object Get(string key)
		{
			return _memoryCache.Get(key);
		}

		public bool IsAdd(string key)
		{
			return _memoryCache.TryGetValue(key, out _);
		}

		public void Remove(string key)
		{
			_memoryCache.Remove(key);
			_cacheKeys.Remove(key);
		}

		public void RemoveByPattern(string pattern)
		{
			var regex = new Regex(pattern, RegexOptions.Compiled|RegexOptions.IgnoreCase|RegexOptions.Singleline);
			var keysToRemove = _cacheKeys.Where(key => regex.IsMatch(key)).ToList();

			foreach (var key in keysToRemove)
			{
				_memoryCache.Remove(key);
				_cacheKeys.Remove(key);
			}
		}
	}
}
