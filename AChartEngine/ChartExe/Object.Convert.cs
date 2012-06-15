//namespace Java.Lang // java exception!!
namespace Core.Android.Interop
{
	using System;
	using Java.Lang;
	
	internal class JavaHolder : Java.Lang.Object
	{
		public readonly object Instance;
		
		public JavaHolder(object instance)
		{
			this.Instance = instance;
		}
	}	
	
	public static class ObjectExtensions
	{
		public static TObject ToNetObject<TObject>(this Java.Lang.Object value)
		{
			if(value == null)
				return default(TObject);

			if (!(value is JavaHolder))
			{
				string msg = 
					"Unable to convert to .NET object."
					+
					"Only Java.Lang.Object created with .ToJavaObject() can be converted.";
				throw new InvalidOperationException(msg);
			}
			
			return 
				(TObject)((JavaHolder)value).Instance;
		}
		
		public static Java.Lang.Object ToJavaObject<TObject>(this TObject value)
		{
			if(value == null)
				return null;
			
			var holder = new JavaHolder(value);					

			return 
				(Java.Lang.Object)holder;
		}
	}
}
