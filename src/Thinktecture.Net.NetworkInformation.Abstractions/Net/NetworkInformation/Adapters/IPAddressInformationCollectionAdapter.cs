#if NETSTANDARD1_3 || NETSTANDARD2_0 || NET45 || NET46

using System.Net.NetworkInformation;
using JetBrains.Annotations;
using Thinktecture.Collections.Generic;

namespace Thinktecture.Net.NetworkInformation.Adapters
{
	/// <summary>
	/// Stores a set of IPAddressInformation types.
	/// </summary>
	// ReSharper disable once InconsistentNaming
	public class IPAddressInformationCollectionAdapter : CollectionAbstractionAdapter<IIPAddressInformation, IPAddressInformation, IPAddressInformationCollection>, IIPAddressInformationCollection
	{
		/// <inheritdoc />
		public IIPAddressInformation this[int index] => Implementation[index].ToInterface();

		/// <summary>
		/// Initializes new instance of <see cref="IPAddressInformationCollectionAdapter"/>
		/// </summary>
		/// <param name="collection">Collection to be used by the adapter.</param>
		public IPAddressInformationCollectionAdapter([NotNull] IPAddressInformationCollection collection)
			: base(collection, information => information.ToInterface())
		{
		}
	}
}

#endif
