﻿using System;
using Microsoft.Win32.SafeHandles;
using Thinktecture.Runtime.InteropServices.Adapters;

namespace Thinktecture.Win32.SafeHandles.Adapters
{
	public class SafeWaitHandleAdapter : SafeHandleAdapter, ISafeWaitHandle
	{
		private readonly SafeWaitHandle _handle;

		/// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.SafeHandles.SafeWaitHandle" /> class. </summary>
		/// <param name="existingHandle">An <see cref="T:System.IntPtr" /> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">true to reliably release the handle during the finalization phase; false to prevent reliable release (not recommended).</param>
		public SafeWaitHandleAdapter(IntPtr existingHandle, bool ownsHandle)
			: this(new SafeWaitHandle(existingHandle, ownsHandle))
		{
		}

		public SafeWaitHandleAdapter(SafeWaitHandle handle)
			: base(handle)
		{
			if (handle == null)
				throw new ArgumentNullException(nameof(handle));

			_handle = handle;
		}

		/// <inheritdoc />
		SafeWaitHandle ISafeWaitHandle.ToImplementation()
		{
			return _handle;
		}
	}
}