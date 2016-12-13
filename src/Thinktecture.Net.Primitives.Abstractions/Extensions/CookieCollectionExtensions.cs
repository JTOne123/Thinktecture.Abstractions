using System.Net;
using Thinktecture.Net;
using Thinktecture.Net.Adapters;

namespace Thinktecture
{
	/// <summary>
	/// Extensions for <see cref="CookieCollection"/>.
	/// </summary>
	public static class CookieCollectionExtensions
	{
		/// <summary>
		/// Converts provided collection to <see cref="ICookieCollection"/>.
		/// </summary>
		/// <param name="collection">Collection to convert.</param>
		/// <returns>Converted collection.</returns>
		public static ICookieCollection ToInterface(this CookieCollection collection)
		{
			return (collection == null) ? null : new CookieCollectionAdapter(collection);
		}
	}
}