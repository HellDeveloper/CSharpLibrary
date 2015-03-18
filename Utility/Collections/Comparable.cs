using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Comparable<T> : IComparer<T> where T : IComparable
    {

        /// <summary>
        /// 比较两个对象并返回一个值，指示一个对象是小于、等于还是大于另一个对象
        /// </summary>
        /// <param name="x">要比较的第一个对象</param>
        /// <param name="y">要比较的第二个对象</param>
        /// <returns>-1:x&lt;y, 0:x==y, 1:x&gt;y; </returns>
        int IComparer<T>.Compare(T x, T y)
        {
            if (x != null)
                return x.CompareTo(y);
            else if (y != null)
                return y.CompareTo(x);
            return 0;
        }
    }
}
