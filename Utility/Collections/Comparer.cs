using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Collections
{
    /// <summary>
    /// 辅助
    /// </summary>
    /// <typeparam name="T">要比较的对象的类型</typeparam>
    class Comparer<T> : IComparer<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        public Comparer(Func<T, T, int> callback)
        {
            this.Callback = callback;
        }

        /// <summary>
        /// 比较两个对象回调方法(CompareTo的实现方法)
        /// </summary>
        public Func<T, T, int> Callback { get; set; }

        /// <summary>
        /// 比较两个对象并返回一个值，指示一个对象是小于、等于还是大于另一个对象
        /// </summary>
        /// <param name="x">要比较的第一个对象</param>
        /// <param name="y">要比较的第二个对象</param>
        /// <returns>-1:x&lt;y, 0:x==y, 1:x&gt;y; </returns>
        int IComparer<T>.Compare(T x, T y)
        {
            if (this.Callback == null)
                return 0;
            return this.Callback(x, y);
        }
    }

    


}
