﻿using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Enyim.Caching.Memcached
{
	public partial class MemcachedClient
	{
		private async Task<bool> PerformFlushAll(Expiration when)
		{
			try
			{
				var tasks = cluster.Broadcast((_, state) => new Operations.FlushOperation(state.allocator) { When = state.when }, (allocator, when));
				await Task.WhenAll(tasks).ConfigureAwait(false);

				return true;
			}
			catch (IOException) { return false; }
		}
	}
}

#region [ License information          ]

/*

Copyright (c) Attila Kiskó, enyim.com

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*/

#endregion
