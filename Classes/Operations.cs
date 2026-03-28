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
			default: return "Unknown";
		}
	}

	public static Int128 CastToType(IntegerSize integerSize, Int128 value) => integerSize switch
	{
		IntegerSize.int8 => (sbyte)value,
		IntegerSize.uint8 => (byte)value,
		IntegerSize.int16 => (short)value,
		IntegerSize.uint16 => (ushort)value,
		IntegerSize.int32 => (int)value,
		IntegerSize.uint32 => (uint)value,
		IntegerSize.int64 => (long)value,
		IntegerSize.uint64 => (ulong)value,
		_ => 0
	};

	public static bool IsOutOfBounds(IntegerSize integerSize, Int128 value)
	{
		switch (integerSize)
		{
			case IntegerSize.int8: return value < sbyte.MinValue || value > sbyte.MaxValue;
			case IntegerSize.uint8: return value < byte.MinValue || value > byte.MaxValue;
			case IntegerSize.int16: return value < short.MinValue || value > short.MaxValue;
			case IntegerSize.uint16: return value < ushort.MinValue || value > ushort.MaxValue;
			case IntegerSize.int32: return value < int.MinValue || value > int.MaxValue;
			case IntegerSize.uint32: return value < uint.MinValue || value > uint.MaxValue;
			case IntegerSize.int64: return value < long.MinValue || value > long.MaxValue;
			case IntegerSize.uint64: return value < ulong.MinValue || value > ulong.MaxValue;
			default:
				return false;
		}
	}

	public static Int128 Increment(IntegerSize integerSize, Int128 value) => CastToType(integerSize, value + 1);
	public static Int128 Decrement(IntegerSize integerSize, Int128 value) => CastToType(integerSize, value - 1);

	public static Int128 GetMin(IntegerSize integerSize)
	{
		switch (integerSize)
		{
			case IntegerSize.int8: return sbyte.MinValue;
			case IntegerSize.uint8: return byte.MinValue;
			case IntegerSize.int16: return short.MinValue;
			case IntegerSize.uint16: return ushort.MinValue;
			case IntegerSize.int32: return int.MinValue;
			case IntegerSize.uint32: return uint.MinValue;
			case IntegerSize.int64: return long.MinValue;
			case IntegerSize.uint64: return ulong.MinValue;
			default:
				return 0;
		}
	}

	public static Int128 GetMax(IntegerSize integerSize)
	{
		switch (integerSize)
		{
			case IntegerSize.int8: return sbyte.MaxValue;
			case IntegerSize.uint8: return byte.MaxValue;
			case IntegerSize.int16: return short.MaxValue;
			case IntegerSize.uint16: return ushort.MaxValue;
			case IntegerSize.int32: return int.MaxValue;
			case IntegerSize.uint32: return uint.MaxValue;
			case IntegerSize.int64: return long.MaxValue;
			case IntegerSize.uint64: return ulong.MaxValue;
			default:
				return 0;
		}
	}
}
