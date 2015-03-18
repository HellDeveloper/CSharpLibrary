using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Core
{
	/// <summary>
    /// 类型工具类
    /// </summary>
	public partial class TypeTool
    {
										
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B;
			return o is A || o is B;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C;
			return o is A || o is B || o is C;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D;
			return o is A || o is B || o is C || o is D;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E;
			return o is A || o is B || o is C || o is D || o is E;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F;
			return o is A || o is B || o is C || o is D || o is E || o is F;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F, G>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F && o is G;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F, G>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F, G>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F && o is G;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F, G, H>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F, G, H>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F, G, H>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F, G, H, I>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F, G, H, I>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F, G, H, I>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F, G, H, I, J>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F, G, H, I, J>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F, G, H, I, J>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F, G, H, I, J, K>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J && o is K;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F, G, H, I, J, K>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J || o is K;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F, G, H, I, J, K>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J && o is K;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J || o is K;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F, G, H, I, J, K, L>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J && o is K && o is L;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F, G, H, I, J, K, L>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J || o is K || o is L;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F, G, H, I, J, K, L>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J && o is K && o is L;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J || o is K || o is L;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F, G, H, I, J, K, L, M>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J && o is K && o is L && o is M;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F, G, H, I, J, K, L, M>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J || o is K || o is L || o is M;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F, G, H, I, J, K, L, M>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J && o is K && o is L && o is M;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J || o is K || o is L || o is M;
		}
		
		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAll<A, B, C, D, E, F, G, H, I, J, K, L, M, N>(object o)
		{
			if (o == null)
                return false;
			return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J && o is K && o is L && o is M && o is N;
		}

		/// <summary>
        /// 类型判断
        /// </summary>
		public static bool IsAny<A, B, C, D, E, F, G, H, I, J, K, L, M, N>(object o)
		{
			if (o == null)
                return false;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J || o is K || o is L || o is M || o is N;
		}

		/// <summary>
        /// 类型判断 true = and, false = any
        /// </summary>
		public static bool Is<A, B, C, D, E, F, G, H, I, J, K, L, M, N>(object o, bool condition)
		{
			if (o == null)
                return false;
			else if(condition)
				return o is A && o is B && o is C && o is D && o is E && o is F && o is G && o is H && o is I && o is J && o is K && o is L && o is M && o is N;
			return o is A || o is B || o is C || o is D || o is E || o is F || o is G || o is H || o is I || o is J || o is K || o is L || o is M || o is N;
		}
		
	}

	/// <summary>
    /// 类型工具类
    /// </summary>
	public partial class TypeTool
    {

		/// <summary>
        /// 判断是否关键字类型（不包括object）
        /// </summary>
        public static bool IsKeyType(Type type)
        {
            if (type == null)
                return false;
            int type_code = (int)System.Type.GetTypeCode(type);
            if (type_code == (int)TypeCode.String)
                return true;
            else if (type_code >= (int)TypeCode.Boolean && type_code <= (int)TypeCode.Decimal)
                return true;
            return false;
        }

        /// <summary>
        /// 判断是否关键字类型（不包括object）
        /// </summary>
        public static bool IsKeyType(object o)
        {
            if (o == null)
                return false;
            return IsKeyType(o.GetType());
        }

        /// <summary>
        /// 判断是否基本数据类型（不包括object）
        /// </summary>
        public static bool IsBaseType(Type type)
        {
            if (type == null)
                return false;
            int type_code = (int)System.Type.GetTypeCode(type);
            if (type_code == (int)TypeCode.String)
                return true;
            else if (type_code >= (int)TypeCode.DBNull && type_code <= (int)TypeCode.DateTime)
                return true;
            return false;
        }

        /// <summary>
        /// 判断是否基本数据类型（不包括object）
        /// </summary>
        public static bool IsBaseType(object o)
        {
            if (o == null)
                return false;
            return IsBaseType(o.GetType()); 
        }
	}
}