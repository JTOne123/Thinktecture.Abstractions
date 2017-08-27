﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Thinktecture.Runtime.InteropServices.Adapters
{
	/// <summary>
	/// Adapter for <see cref="SafeHandle"/>.
	/// </summary>
	public class SafeHandleAdapter : AbstractionAdapter, ISafeHandle
	{
		/// <inheritdoc />
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new SafeHandle UnsafeConvert()
		{
			return _instance;
		}

		private readonly SafeHandle _instance;

		/// <inheritdoc />
		public bool IsClosed => _instance.IsClosed;

		/// <inheritdoc />
		public bool IsInvalid => _instance.IsInvalid;

		/// <summary>
		/// Initializes a new instance of the <see cref="CriticalHandleAdapter"/> class.
		/// </summary>
		/// <param name="handle">Handle to be use by the adapter.</param>
		public SafeHandleAdapter(SafeHandle handle)
			: base(handle)
		{
			_instance = handle ?? throw new ArgumentNullException(nameof(handle));
		}

		/// <inheritdoc />
		public void DangerousAddRef(ref bool success)
		{
			_instance.DangerousAddRef(ref success);
		}

		/// <inheritdoc />
		public IntPtr DangerousGetHandle()
		{
			return _instance.DangerousGetHandle();
		}

		/// <inheritdoc />
		public void DangerousRelease()
		{
			_instance.DangerousRelease();
		}

		/// <inheritdoc />
		public void SetHandleAsInvalid()
		{
			_instance.SetHandleAsInvalid();
		}

		/// <inheritdoc />
		public void Dispose()
		{
			_instance.Dispose();
		}
	}
}
