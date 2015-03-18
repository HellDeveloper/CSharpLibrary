using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Core
{
	/// <summary>
    /// 类型转换工具类
    /// </summary>
	public static partial class TryTo
    {
	
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static short? TryToShort(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is short)
				return (short)obj;
			short result;
			if(short.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static short? TryToShort(this string str)
		{
			short result;
			if(short.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static int? TryToInt(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is int)
				return (int)obj;
			int result;
			if(int.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static int? TryToInt(this string str)
		{
			int result;
			if(int.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static long? TryToLong(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is long)
				return (long)obj;
			long result;
			if(long.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static long? TryToLong(this string str)
		{
			long result;
			if(long.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static ushort? TryToUShort(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is ushort)
				return (ushort)obj;
			ushort result;
			if(ushort.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static ushort? TryToUShort(this string str)
		{
			ushort result;
			if(ushort.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static uint? TryToUInt(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is uint)
				return (uint)obj;
			uint result;
			if(uint.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static uint? TryToUInt(this string str)
		{
			uint result;
			if(uint.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static ulong? TryToULong(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is ulong)
				return (ulong)obj;
			ulong result;
			if(ulong.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static ulong? TryToULong(this string str)
		{
			ulong result;
			if(ulong.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static float? TryToFloat(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is float)
				return (float)obj;
			float result;
			if(float.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static float? TryToFloat(this string str)
		{
			float result;
			if(float.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static double? TryToDouble(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is double)
				return (double)obj;
			double result;
			if(double.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static double? TryToDouble(this string str)
		{
			double result;
			if(double.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static decimal? TryToDecimal(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is decimal)
				return (decimal)obj;
			decimal result;
			if(decimal.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static decimal? TryToDecimal(this string str)
		{
			decimal result;
			if(decimal.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static char? TryToChar(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is char)
				return (char)obj;
			char result;
			if(char.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static char? TryToChar(this string str)
		{
			char result;
			if(char.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static bool? TryToBool(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is bool)
				return (bool)obj;
			bool result;
			if(bool.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool? TryToBool(this string str)
		{
			bool result;
			if(bool.TryParse(str, out result))
				return result;
			return null;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>转换失败返回null</returns>
		public static System.DateTime? TryToDateTime(this object obj)
		{
			if (obj == null)
				return null;
			else if (obj is System.DateTime)
				return (System.DateTime)obj;
			System.DateTime result;
			if(System.DateTime.TryParse(obj.ToString(), out result))
				return result;
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static System.DateTime? TryToDateTime(this string str)
		{
			System.DateTime result;
			if(System.DateTime.TryParse(str, out result))
				return result;
			return null;
		}
		
		

	}
}