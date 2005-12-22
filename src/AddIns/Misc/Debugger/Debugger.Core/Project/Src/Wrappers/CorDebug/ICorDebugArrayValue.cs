// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugArrayValue
	{
		
		private Debugger.Interop.CorDebug.ICorDebugArrayValue wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugArrayValue WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugArrayValue(Debugger.Interop.CorDebug.ICorDebugArrayValue wrappedObject)
		{
			this.wrappedObject = wrappedObject;
		}
		
		public static ICorDebugArrayValue Wrap(Debugger.Interop.CorDebug.ICorDebugArrayValue objectToWrap)
		{
			return new ICorDebugArrayValue(objectToWrap);
		}
		
		public bool Is<T>() where T: class
		{
			try {
				CastTo<T>();
				return true;
			} catch {
				return false;
			}
		}
		
		public T As<T>() where T: class
		{
			try {
				return CastTo<T>();
			} catch {
				return null;
			}
		}
		
		public T CastTo<T>() where T: class
		{
			return (T)Activator.CreateInstance(typeof(T), this.WrappedObject);
		}
		
		public static bool operator ==(ICorDebugArrayValue o1, ICorDebugArrayValue o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugArrayValue o1, ICorDebugArrayValue o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugArrayValue casted = o as ICorDebugArrayValue;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public uint Type
		{
			get
			{
				uint pType;
				this.WrappedObject.GetType(out pType);
				return pType;
			}
		}
		
		public uint Size
		{
			get
			{
				uint pSize;
				this.WrappedObject.GetSize(out pSize);
				return pSize;
			}
		}
		
		public ulong Address
		{
			get
			{
				ulong pAddress;
				this.WrappedObject.GetAddress(out pAddress);
				return pAddress;
			}
		}
		
		public ICorDebugValueBreakpoint CreateBreakpoint()
		{
			ICorDebugValueBreakpoint ppBreakpoint;
			Debugger.Interop.CorDebug.ICorDebugValueBreakpoint out_ppBreakpoint;
			this.WrappedObject.CreateBreakpoint(out out_ppBreakpoint);
			ppBreakpoint = ICorDebugValueBreakpoint.Wrap(out_ppBreakpoint);
			return ppBreakpoint;
		}
		
		public int IsValid
		{
			get
			{
				int pbValid;
				this.WrappedObject.IsValid(out pbValid);
				return pbValid;
			}
		}
		
		public ICorDebugValueBreakpoint CreateRelocBreakpoint()
		{
			ICorDebugValueBreakpoint ppBreakpoint;
			Debugger.Interop.CorDebug.ICorDebugValueBreakpoint out_ppBreakpoint;
			this.WrappedObject.CreateRelocBreakpoint(out out_ppBreakpoint);
			ppBreakpoint = ICorDebugValueBreakpoint.Wrap(out_ppBreakpoint);
			return ppBreakpoint;
		}
		
		public uint ElementType
		{
			get
			{
				uint pType;
				this.WrappedObject.GetElementType(out pType);
				return pType;
			}
		}
		
		public uint Rank
		{
			get
			{
				uint pnRank;
				this.WrappedObject.GetRank(out pnRank);
				return pnRank;
			}
		}
		
		public uint Count
		{
			get
			{
				uint pnCount;
				this.WrappedObject.GetCount(out pnCount);
				return pnCount;
			}
		}
		
		public void GetDimensions(uint cdim, System.IntPtr dims)
		{
			this.WrappedObject.GetDimensions(cdim, dims);
		}
		
		public int HasBaseIndicies()
		{
			int pbHasBaseIndicies;
			this.WrappedObject.HasBaseIndicies(out pbHasBaseIndicies);
			return pbHasBaseIndicies;
		}
		
		public void GetBaseIndicies(uint cdim, System.IntPtr indicies)
		{
			this.WrappedObject.GetBaseIndicies(cdim, indicies);
		}
		
		public ICorDebugValue GetElement(uint cdim, System.IntPtr indices)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetElement(cdim, indices, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public ICorDebugValue GetElementAtPosition(uint nPosition)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetElementAtPosition(nPosition, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
	}
}
