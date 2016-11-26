﻿#if NETSTANDARD1_3 || NET45 || NET46

using System.ComponentModel;
using System.Net;
using System.Net.Sockets;

namespace Thinktecture.Net
{
	/// <summary>Provides an Internet Protocol (IP) address.</summary>
	// ReSharper disable once InconsistentNaming
	public interface IIPAddress
	{
		/// <summary>
		/// Gets inner instance of <see cref="IPAddress"/>.
		/// It is not intended to be used directly. Use <see cref="IPAddressExtensions.ToImplementation"/> instead.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		IPAddress UnsafeConvert();

		/// <summary>Gets the address family of the IP address.</summary>
		/// <returns>Returns <see cref="F:System.Net.Sockets.AddressFamily.InterNetwork" /> for IPv4 or <see cref="F:System.Net.Sockets.AddressFamily.InterNetworkV6" /> for IPv6.</returns>
		AddressFamily AddressFamily { get; }

		/// <summary>Gets whether the IP address is an IPv4-mapped IPv6 address.</summary>
		/// <returns>Returns <see cref="T:System.Boolean" />.true if the IP address is an IPv4-mapped IPv6 address; otherwise, false.</returns>
		bool IsIPv4MappedToIPv6 { get; }

		/// <summary>Gets whether the address is an IPv6 link local address.</summary>
		/// <returns>true if the IP address is an IPv6 link local address; otherwise, false.</returns>
		bool IsIPv6LinkLocal { get; }

		/// <summary>Gets whether the address is an IPv6 multicast global address.</summary>
		/// <returns>true if the IP address is an IPv6 multicast global address; otherwise, false.</returns>
		bool IsIPv6Multicast { get; }

		/// <summary>Gets whether the address is an IPv6 site local address.</summary>
		/// <returns>true if the IP address is an IPv6 site local address; otherwise, false.</returns>
		bool IsIPv6SiteLocal { get; }

		/// <summary>Gets whether the address is an IPv6 Teredo address.</summary>
		/// <returns>true if the IP address is an IPv6 Teredo address; otherwise, false.</returns>
		bool IsIPv6Teredo { get; }

		/// <summary>Gets or sets the IPv6 address scope identifier.</summary>
		/// <returns>A long integer that specifies the scope of the address.</returns>
		/// <exception cref="T:System.Net.Sockets.SocketException">AddressFamily = InterNetwork. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// <see name="ScopeId" /> &lt; 0- or -<see name="ScopeId" /> &gt; 0x00000000FFFFFFFF  </exception>
		long ScopeId { get; set; }

		/// <summary>Compares two IP addresses.</summary>
		/// <returns>true if the two addresses are equal; otherwise, false.</returns>
		/// <param name="comparand">An <see cref="T:System.Net.IPAddress" /> instance to compare to the current instance. </param>
		bool Equals(object comparand);

		/// <summary>Provides a copy of the <see cref="T:System.Net.IPAddress" /> as an array of bytes.</summary>
		/// <returns>A <see cref="T:System.Byte" /> array.</returns>
		byte[] GetAddressBytes();

		/// <summary>Returns a hash value for an IP address.</summary>
		/// <returns>An integer hash value.</returns>
		/// <PermissionSet>
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		int GetHashCode();

		/// <summary>Maps the <see cref="T:System.Net.IPAddress" /> object to an IPv4 address.</summary>
		/// <returns>Returns <see cref="T:System.Net.IPAddress" />.An IPv4 address.</returns>
		IIPAddress MapToIPv4();

		/// <summary>Maps the <see cref="T:System.Net.IPAddress" /> object to an IPv6 address.</summary>
		/// <returns>Returns <see cref="T:System.Net.IPAddress" />.An IPv6 address.</returns>
		IIPAddress MapToIPv6();

		/// <summary>Converts an Internet address to its standard notation.</summary>
		/// <returns>A string that contains the IP address in either IPv4 dotted-quad or in IPv6 colon-hexadecimal notation.</returns>
		/// <exception cref="T:System.Net.Sockets.SocketException">The address family is <see cref="F:System.Net.Sockets.AddressFamily.InterNetworkV6" /> and the address is bad. </exception>
		/// <PermissionSet>
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		string ToString();
	}
}

#endif