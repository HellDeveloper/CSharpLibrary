using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.WebForm
{
    /// <summary>
    /// 控件工具
    /// </summary>
    public static class ControlTool
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="prefix"></param>
        public static T ConvertToParameter<T>(string name, object value) where T : IDataParameter, new()
        {
            T t = new T();
            var array = name.Split('$');
            t.SourceColumn = array[0];
            t.Value = value;
            if (array.Length >= 2)
                Mapping(t, array[1]);
            else
                Mapping(t, String.Empty);
            return t;
        }

        private static void Mapping(IDataParameter Param, string name)
        {
            name = name ?? String.Empty;
            name = name.ToLower().Trim();
            if (name.Length == 1)
                MappingLength1(Param, name);
            else if(name.Length == 2)
                MappingLength2(Param, name);
            else if (name.Length == 3)
                MappingLength3(Param, name);
            else
                MappingLength0(Param);
        }

        private static void MappingLength0(IDataParameter Param)
        {
            Param.SourceColumn += " LIKE";
        }

        private static void MappingLength3(IDataParameter Param, string name)
        {
            switch (name)
            {
                case "lte":
                    Param.SourceColumn += " <=";
                    break;
                case "neq":
                    Param.SourceColumn += " <>";
                    break;
                case "gte":
                    Param.SourceColumn += " >=";
                    break;
            }
        }

        private static void MappingLength2(IDataParameter Param, string name)
        {
            switch (name)
            {
                case "lt":
                    Param.SourceColumn += " <";
                    break;
                case "eq":
                    Param.SourceColumn += " =";
                    break;
                case "gt":
                    Param.SourceColumn += " =";
                    break;
                case "lr":
                    Param.SourceColumn += " LIKE";
                    string value = Param.Value == null ? String.Empty : Param.Value.ToString();
                    Param.Value = String.Format("%{0}%", value);
                    break;
            }
        }

        private static void MappingLength1(IDataParameter Param, string name)
        {
            string value = Param.Value == null ? String.Empty : Param.Value.ToString();
            Param.SourceColumn += " LIKE";
            switch (name)
            {
                case "l":
                    value = String.Format("%{0}", value);
                    break;
                case "r":
                    value = String.Format("{0}%", value);
                    break;
            }
            Param.Value = value;
        }

    }
}
