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
        /// 默认比较运算符
        /// </summary>
        public const string DEFAULT_COMPARER = "=";

        /// <summary>
        /// ParameterName的前缀
        /// </summary>
        internal static readonly char[] PARAMETER_NAME_PERFIX =
        {
            '@', ':'
        };

        /// <summary>
        /// 调整SourceColumn。
        /// if (String.IsNullOrWhiteSpace(param.ParameterName)) return
        /// </summary>
        /// <param name="param"></param>
        /// <param name="field"></param>
        /// <param name="comparer"></param>
        internal static void AdjustmentSourceColumn(IDataParameter param, string field = null, string comparer = null)
        {
            if (String.IsNullOrWhiteSpace(param.ParameterName))
                return;
            if (String.IsNullOrWhiteSpace(param.SourceColumn))
            {
                field = field ?? param.ParameterName.TrimStart(PARAMETER_NAME_PERFIX);
                comparer = comparer ?? DbParameter.DEFAULT_COMPARER;
                param.SourceColumn = String.Format("{0}{1}{2}", field, Assist.WHITE_SPACE, comparer);
            }
            else
            {
                string[] array = param.SourceColumn.Split(Assist.WHITE_SPACE);
                if (array.Length == 1)
                    param.SourceColumn = String.Format("{0}{1}{2}", array[0], Assist.WHITE_SPACE, comparer ?? DbParameter.DEFAULT_COMPARER);
            }
        }

        /// <summary>
        /// 在SourceColumn获取字段名。
        /// if (String.IsNullOrWhiteSpace(param.ParameterName)) return null;    
        /// </summary>
        /// <param name="param"></param>
        /// <returns>返回null，是获取不到</returns>
        public static string GetFieldName(IDataParameter param)
        {
            if (String.IsNullOrWhiteSpace(param.ParameterName))
                return null;
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
        /// <returns></returns>
        public static T Add<T>(this ICollection<T> collection, string parameterName, object value, string sourceColumn = null, ParameterDirection direction = ParameterDirection.Input) where T : IDataParameter, new()
        {
            sourceColumn = sourceColumn ?? (parameterName != null ? parameterName.TrimStart(PARAMETER_NAME_PERFIX) + " " + DEFAULT_COMPARER : null);
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
