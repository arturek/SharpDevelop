// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugCode
	{
		
		private Debugger.Interop.CorDebug.ICorDebugCode wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugCode WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugCode(Debugger.Interop.CorDebug.ICorDebugCode wrappedObject)
		{
			this.wrappedObject = wrappedObject;
		}
		
		public static ICorDebugCode Wrap(Debugger.Interop.CorDebug.ICorDebugCode objectToWrap)
		{
			return new ICorDebugCode(objectToWrap);
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
		
		public static bool operator ==(ICorDebugCode o1, ICorDebugCode o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugCode o1, ICorDebugCode o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugCode casted = o as ICorDebugCode;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public int IsIL
		{
			get
			{
				int pbIL;
				this.WrappedObject.IsIL(out pbIL);
				return pbIL;
			}
		}
		
		public ICorDebugFunction Function
		{
			get
			{
				ICorDebugFunction ppFunction;
				Debugger.Interop.CorDebug.ICorDebugFunction out_ppFunction;
				this.WrappedObject.GetFunction(out out_ppFunction);
				ppFunction = ICorDebugFunction.Wrap(out_ppFunction);
				return ppFunction;
			}
		}
		
		public ulong Address
		{
			get
			{
				ulong pStart;
				this.WrappedObject.GetAddress(out pStart);
				return pStart;
			}
		}
		
		public uint Size
		{
			get
			{
				uint pcBytes;
				this.WrappedObject.GetSize(out pcBytes);
				return pcBytes;
			}
		}
		
		public ICorDebugFunctionBreakpoint CreateBreakpoint(uint offset)
		{
			ICorDebugFunctionBreakpoint ppBreakpoint;
			Debugger.Interop.CorDebug.ICorDebugFunctionBreakpoint out_ppBreakpoint;
			this.WrappedObject.CreateBreakpoint(offset, out out_ppBreakpoint);
			ppBreakpoint = ICorDebugFunctionBreakpoint.Wrap(out_ppBreakpoint);
			return ppBreakpoint;
		}
		
		public uint GetCode(uint startOffset, uint endOffset, uint cBufferAlloc, System.IntPtr buffer)
		{
			uint pcBufferSize;
			this.WrappedObject.GetCode(startOffset, endOffset, cBufferAlloc, buffer, out pcBufferSize);
			return pcBufferSize;
		}
		
		public uint VersionNumber
		{
			get
			{
				uint nVersion;
				this.WrappedObject.GetVersionNumber(out nVersion);
				return nVersion;
			}
		}
		
		public void GetILToNativeMapping(uint cMap, out uint pcMap, System.IntPtr map)
		{
			this.WrappedObject.GetILToNativeMapping(cMap, out pcMap, map);
		}
		
		public void GetEnCRemapSequencePoints(uint cMap, out uint pcMap, System.IntPtr offsets)
		{
			this.WrappedObject.GetEnCRemapSequencePoints(cMap, out pcMap, offsets);
		}
	}
}
