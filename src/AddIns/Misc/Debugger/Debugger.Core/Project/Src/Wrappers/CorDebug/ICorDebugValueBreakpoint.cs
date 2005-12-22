// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugValueBreakpoint
	{
		
		private Debugger.Interop.CorDebug.ICorDebugValueBreakpoint wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugValueBreakpoint WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugValueBreakpoint(Debugger.Interop.CorDebug.ICorDebugValueBreakpoint wrappedObject)
		{
			this.wrappedObject = wrappedObject;
		}
		
		public static ICorDebugValueBreakpoint Wrap(Debugger.Interop.CorDebug.ICorDebugValueBreakpoint objectToWrap)
		{
			return new ICorDebugValueBreakpoint(objectToWrap);
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
		
		public static bool operator ==(ICorDebugValueBreakpoint o1, ICorDebugValueBreakpoint o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugValueBreakpoint o1, ICorDebugValueBreakpoint o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugValueBreakpoint casted = o as ICorDebugValueBreakpoint;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public void Activate(int bActive)
		{
			this.WrappedObject.Activate(bActive);
		}
		
		public int IsActive
		{
			get
			{
				int pbActive;
				this.WrappedObject.IsActive(out pbActive);
				return pbActive;
			}
		}
		
		public ICorDebugValue Value
		{
			get
			{
				ICorDebugValue ppValue;
				Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
				this.WrappedObject.GetValue(out out_ppValue);
				ppValue = ICorDebugValue.Wrap(out_ppValue);
				return ppValue;
			}
		}
	}
}
