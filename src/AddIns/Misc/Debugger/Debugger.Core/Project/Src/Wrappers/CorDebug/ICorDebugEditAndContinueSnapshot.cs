// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugEditAndContinueSnapshot
	{
		
		private Debugger.Interop.CorDebug.ICorDebugEditAndContinueSnapshot wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugEditAndContinueSnapshot WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugEditAndContinueSnapshot(Debugger.Interop.CorDebug.ICorDebugEditAndContinueSnapshot wrappedObject)
		{
			this.wrappedObject = wrappedObject;
		}
		
		public static ICorDebugEditAndContinueSnapshot Wrap(Debugger.Interop.CorDebug.ICorDebugEditAndContinueSnapshot objectToWrap)
		{
			return new ICorDebugEditAndContinueSnapshot(objectToWrap);
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
		
		public static bool operator ==(ICorDebugEditAndContinueSnapshot o1, ICorDebugEditAndContinueSnapshot o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugEditAndContinueSnapshot o1, ICorDebugEditAndContinueSnapshot o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugEditAndContinueSnapshot casted = o as ICorDebugEditAndContinueSnapshot;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public System.Guid CopyMetaData(IStream pIStream)
		{
			System.Guid pMvid;
			this.WrappedObject.CopyMetaData(pIStream.WrappedObject, out pMvid);
			return pMvid;
		}
		
		public System.Guid Mvid
		{
			get
			{
				System.Guid pMvid;
				this.WrappedObject.GetMvid(out pMvid);
				return pMvid;
			}
		}
		
		public uint RoDataRVA
		{
			get
			{
				uint pRoDataRVA;
				this.WrappedObject.GetRoDataRVA(out pRoDataRVA);
				return pRoDataRVA;
			}
		}
		
		public uint RwDataRVA
		{
			get
			{
				uint pRwDataRVA;
				this.WrappedObject.GetRwDataRVA(out pRwDataRVA);
				return pRwDataRVA;
			}
		}
		
		public void SetPEBytes(IStream pIStream)
		{
			this.WrappedObject.SetPEBytes(pIStream.WrappedObject);
		}
		
		public void SetILMap(uint mdFunction, uint cMapSize, ref Debugger.Interop.CorDebug._COR_IL_MAP map)
		{
			this.WrappedObject.SetILMap(mdFunction, cMapSize, ref map);
		}
		
		public void SetPESymbolBytes(IStream pIStream)
		{
			this.WrappedObject.SetPESymbolBytes(pIStream.WrappedObject);
		}
	}
}
