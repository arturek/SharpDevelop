// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugILFrame2
	{
		
		private Debugger.Interop.CorDebug.ICorDebugILFrame2 wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugILFrame2 WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugILFrame2(Debugger.Interop.CorDebug.ICorDebugILFrame2 wrappedObject)
		{
			this.wrappedObject = wrappedObject;
		}
		
		public static ICorDebugILFrame2 Wrap(Debugger.Interop.CorDebug.ICorDebugILFrame2 objectToWrap)
		{
			return new ICorDebugILFrame2(objectToWrap);
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
		
		public static bool operator ==(ICorDebugILFrame2 o1, ICorDebugILFrame2 o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugILFrame2 o1, ICorDebugILFrame2 o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugILFrame2 casted = o as ICorDebugILFrame2;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public void RemapFunction(uint newILOffset)
		{
			this.WrappedObject.RemapFunction(newILOffset);
		}
		
		public ICorDebugTypeEnum EnumerateTypeParameters()
		{
			ICorDebugTypeEnum ppTyParEnum;
			Debugger.Interop.CorDebug.ICorDebugTypeEnum out_ppTyParEnum;
			this.WrappedObject.EnumerateTypeParameters(out out_ppTyParEnum);
			ppTyParEnum = ICorDebugTypeEnum.Wrap(out_ppTyParEnum);
			return ppTyParEnum;
		}
	}
}
