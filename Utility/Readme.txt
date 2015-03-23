
IDataParameter.SourceColumn 规则
	作用是：条件Sql
if (String.IsNullOrWhiteSpace(IDataParameter.ParameterName))
{
	SourceColumn = "自定义ConditionSQL语句";
}
else
{
	SourceColumn = "FieldName Comparer"; // 空格是必须的
}

