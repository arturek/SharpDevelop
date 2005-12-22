// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugObjectValue
	{
		
		private Debugger.Interop.CorDebug.ICorDebugObjectValue wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugObjectValue WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugObjectValue(Debugger.Interop.CorDebug.ICorDebugObjectValue wrappedObject)
		{
			this.wrappedObject = wrappedObject;
		}
		
		public static ICorDebugObjectValue Wrap(Debugger.Interop.CorDebug.ICorDebugObjectValue objectToWrap)
		{
			return new ICorDebugObjectValue(objectToWrap);
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
		
		public static bool operator ==(ICorDebugObjectValue o1, ICorDebugObjectValue o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugObjectValue o1, ICorDebugObjectValue o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugObjectValue casted = o as ICorDebugObjectValue;
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
		
		public ICorDebugClass Class
		{
			get
			{
				ICorDebugClass ppClass;
				Debugger.Interop.CorDebug.ICorDebugClass out_ppClass;
				this.WrappedObject.GetClass(out out_ppClass);
				ppClass = ICorDebugClass.Wrap(out_ppClass);
				return ppClass;
			}
		}
		
		public ICorDebugValue GetFieldValue(ICorDebugClass pClass, uint fieldDef)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetFieldValue(pClass.WrappedObject, fieldDef, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public ICorDebugFunction GetVirtualMethod(uint memberRef)
		{
			ICorDebugFunction ppFunction;
			Debugger.Interop.CorDebug.ICorDebugFunction out_ppFunction;
			this.WrappedObject.GetVirtualMethod(memberRef, out out_ppFunction);
			ppFunction = ICorDebugFunction.Wrap(out_ppFunction);
			return ppFunction;
		}
		
		public ICorDebugContext Context
		{
			get
			{
				ICorDebugContext ppContext;
				Debugger.Interop.CorDebug.ICorDebugContext out_ppContext;
				this.WrappedObject.GetContext(out out_ppContext);
				ppContext = ICorDebugContext.Wrap(out_ppContext);
				return ppContext;
			}
		}
		
		public int IsValueClass
		{
			get
			{
				int pbIsValueClass;
				this.WrappedObject.IsValueClass(out pbIsValueClass);
				return pbIsValueClass;
			}
		}
		
		public object ManagedCopy
		{
			get
			{
				object ppObject;
				this.WrappedObject.GetManagedCopy(out ppObject);
				return ppObject;
			}
		}
		
		public void SetFromManagedCopy(object pObject)
		{
			this.WrappedObject.SetFromManagedCopy(pObject);
		}
	}
}
