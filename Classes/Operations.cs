namespace BitCalculator;

public static class Operations
{
	public static string GetButtonTextForOperator(OperatorType operatorType)
	{
		switch (operatorType)
		{
			case OperatorType.Equal: return "=";
			case OperatorType.Add: return "+";
			case OperatorType.Subtract: return "-";
			case OperatorType.Multiply: return "×";
			case OperatorType.Divide: return "÷";
			case OperatorType.Mod: return "%";
			case OperatorType.LeftShift: return "«";
			case OperatorType.RightShift: return "»";
			case OperatorType.AND: return "&";
			case OperatorType.OR: return "|";
			case OperatorType.NOT: return "~";
			case OperatorType.XOR: return "^";
			default: return "Unknown operator";
		}
	}

	public static object CastToType(IntegerSize integerSize, long value) => integerSize switch
	{
		IntegerSize.int8 => unchecked((sbyte)value),
		IntegerSize.uint8 => unchecked((byte)value),
		IntegerSize.int16 => unchecked((short)value),
		IntegerSize.uint16 => unchecked((ushort)value),
		IntegerSize.int32 => unchecked((int)value),
		IntegerSize.uint32 => unchecked((uint)value),
		IntegerSize.int64 => value,
		IntegerSize.uint64 => unchecked((ulong)value),
		_ => throw new ArgumentException("Unsupported type")
	};

	public static object CastToType(IntegerSize integerSize, ulong value) => integerSize switch
	{
		IntegerSize.int8 => unchecked((sbyte)value),
		IntegerSize.uint8 => unchecked((byte)value),
		IntegerSize.int16 => unchecked((short)value),
		IntegerSize.uint16 => unchecked((ushort)value),
		IntegerSize.int32 => unchecked((int)value),
		IntegerSize.uint32 => unchecked((uint)value),
		IntegerSize.int64 => unchecked((long)value),
		IntegerSize.uint64 => value,
		_ => throw new ArgumentException("Unsupported type")
	};
}
