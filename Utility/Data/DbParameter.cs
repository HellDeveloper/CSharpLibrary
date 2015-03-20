using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Collections;
using Utility.Core;

namespace Utility.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbParameter
    {

        /// <summary>
        /// ParameterName的前缀
        /// </summary>
        internal static readonly char[] PARAMETER_NAME_PERFIX = { '@', ':' };

        /// <summary>
        /// ParameterName的前缀
        /// </summary>
        public static char[] ParameterNamePerfix
        {
            get { return PARAMETER_NAME_PERFIX; }
        }

        /// <summary>
        /// 在SourceColumn获取字段名。
        /// if (String.IsNullOrWhiteSpace(param.ParameterName)) return null;    
        /// </summary>
        /// <param name="param"></param>
        /// <returns>返回null，是获取不到</returns>
        public static string GetFieldName(IDataParameter param)
        {
            string[] array = param.SourceColumn.Split(Assist.WHITE_SPACE);
            return array.Length > 0 ? array[0] : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <param name="sourceColumn"></param>
        /// <param name="direction"></param>
        /// <returns>返回已经添加到集合里</returns>
        public static T Add<T>(this ICollection<T> collection, string parameterName, object value, string sourceColumn, ParameterDirection direction = ParameterDirection.Input) where T : IDataParameter, new()
        {
            T t = new T()
            {
                ParameterName = parameterName,
                Value = value,
                SourceColumn = sourceColumn,
                Direction = direction
            };
            collection.Add(t);
            return t;
        }

        
    }
}
