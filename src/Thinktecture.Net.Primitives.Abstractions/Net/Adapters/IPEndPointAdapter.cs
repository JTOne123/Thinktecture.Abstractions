#if NETSTANDARD1_3 || NET45 || NET46

using System;
using System.ComponentModel;
using System.Net;

namespace Thinktecture.Net.Adapters
{
	/// <summary>Represents a network endpoint as an IP address and a port number.</summary>
	// ReSharper disable once InconsistentNaming
	public class IPEndPointAdapter : EndPointAdapter, IIPEndPoint
	{
		private readonly IPEndPoint _endpoint;

		/// <summary>Specifies the maximum value that can be assigned to the <see cref="P:System.Net.IPEndPoint.Port" /> property. The MaxPort value is set to 0x0000FFFF. This field is read-only.</summary>
		// ReSharper disable once InconsistentNaming
		public const int MaxPort = 65535;

		/// <summary>Specifies the minimum value that can be assigned to the <see cref="P:System.Net.IPEndPoint.Port" /> property. This field is read-only.</summary>
		// ReSharper disable once InconsistentNaming
		public const int MinPort = 0;

		/// <inheritdoc />
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new IPEndPoint UnsafeConvert()
		{
			return _endpoint;
		}

		/// <inheritdoc />
		public IIPAddress Address
		{
			get => _endpoint.Address.ToInterface();
			set => _endpoint.Address = value.ToImplementation();
		}

		/// <inheritdoc />
		public int Port
		{
			get => _endpoint.Port;
			set => _endpoint.Port = value;
		}

		/// <summary>Initializes a new instance of the <see cref="IPEndPointAdapter" /> class with the specified address and port number.</summary>
		/// <param name="address">The IP address of the Internet host. </param>
		/// <param name="port">The port number associated with the <paramref name="address" />, or 0 to specify any available port. <paramref name="port" /> is in host order.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <paramref name="port" /> is less than <see cref="F:System.Net.IPEndPoint.MinPort" />.-or- <paramref name="port" /> is greater than <see cref="F:System.Net.IPEndPoint.MaxPort" />.-or- <paramref name="address" /> is less than 0 or greater than 0x00000000FFFFFFFF. </exception>
		public IPEndPointAdapter(long address, int port)
			: this(new IPEndPoint(address, port))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="IPEndPointAdapter" /> class with the specified address and port number.</summary>
		/// <param name="address">An <see cref="T:System.Net.IPAddress" />. </param>
		/// <param name="port">The port number associated with the <paramref name="address" />, or 0 to specify any available port. <paramref name="port" /> is in host order.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// <paramref name="address" /> is null.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <paramref name="port" /> is less than <see cref="F:System.Net.IPEndPoint.MinPort" />.-or- <paramref name="port" /> is greater than <see cref="F:System.Net.IPEndPoint.MaxPort" />.-or- <paramref name="address" /> is less than 0 or greater than 0x00000000FFFFFFFF. </exception>
		public IPEndPointAdapter(IPAddress address, int port)
			: this(new IPEndPoint(address, port))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="IPEndPointAdapter" /> class with the specified address and port number.</summary>
		/// <param name="address">An <see cref="T:System.Net.IPAddress" />. </param>
		/// <param name="port">The port number associated with the <paramref name="address" />, or 0 to specify any available port. <paramref name="port" /> is in host order.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// <paramref name="address" /> is null.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <paramref name="port" /> is less than <see cref="F:System.Net.IPEndPoint.MinPort" />.-or- <paramref name="port" /> is greater than <see cref="F:System.Net.IPEndPoint.MaxPort" />.-or- <paramref name="address" /> is less than 0 or greater than 0x00000000FFFFFFFF. </exception>
		public IPEndPointAdapter(IIPAddress address, int port)
			: this(new IPEndPoint(address.ToImplementation(), port))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="IPEndPointAdapter" /> class.</summary>
		/// <param name="endpoint">Endpoint to be used by the adapter.</param>
		public IPEndPointAdapter(IPEndPoint endpoint)
			: base(endpoint)
		{
			_endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
		}
	}
}

#endif
