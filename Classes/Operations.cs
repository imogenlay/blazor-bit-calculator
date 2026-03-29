namespace BitCalculator;

public static class Operations
{
	public static string GetButtonTextForOperator(OperatorType operatorType)
	{
		return operatorType switch
		{
			OperatorType.Equal => "=",
			OperatorType.Add => "+",
			OperatorType.Subtract => "-",
			OperatorType.Multiply => "×",
			OperatorType.Divide => "÷",
			OperatorType.Mod => "%",
			OperatorType.LeftShift => "«",
			OperatorType.RightShift => "»",
			OperatorType.AND => "&",
			OperatorType.OR => "|",
			OperatorType.XOR => "^",
			_ => "Unknown"
		};
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
		return integerSize switch
		{
			IntegerSize.int8 => value < sbyte.MinValue || value > sbyte.MaxValue,
			IntegerSize.uint8 => value < byte.MinValue || value > byte.MaxValue,
			IntegerSize.int16 => value < short.MinValue || value > short.MaxValue,
			IntegerSize.uint16 => value < ushort.MinValue || value > ushort.MaxValue,
			IntegerSize.int32 => value < int.MinValue || value > int.MaxValue,
			IntegerSize.uint32 => value < uint.MinValue || value > uint.MaxValue,
			IntegerSize.int64 => value < long.MinValue || value > long.MaxValue,
			IntegerSize.uint64 => value < ulong.MinValue || value > ulong.MaxValue,
			_ => false
		};
	}

	public static Int128 Increment(IntegerSize integerSize, Int128 value) => CastToType(integerSize, value + 1);
	public static Int128 Decrement(IntegerSize integerSize, Int128 value) => CastToType(integerSize, value - 1);

	public static Int128 GetMin(IntegerSize integerSize)
	{
		return integerSize switch
		{
			IntegerSize.int8 => sbyte.MinValue,
			IntegerSize.uint8 => byte.MinValue,
			IntegerSize.int16 => short.MinValue,
			IntegerSize.uint16 => ushort.MinValue,
			IntegerSize.int32 => int.MinValue,
			IntegerSize.uint32 => uint.MinValue,
			IntegerSize.int64 => long.MinValue,
			IntegerSize.uint64 => ulong.MinValue,
			_ => 0
		};
	}

	public static Int128 GetMax(IntegerSize integerSize)
	{
		return integerSize switch
		{
			IntegerSize.int8 => sbyte.MaxValue,
			IntegerSize.uint8 => byte.MaxValue,
			IntegerSize.int16 => short.MaxValue,
			IntegerSize.uint16 => ushort.MaxValue,
			IntegerSize.int32 => int.MaxValue,
			IntegerSize.uint32 => uint.MaxValue,
			IntegerSize.int64 => long.MaxValue,
			IntegerSize.uint64 => ulong.MaxValue,
			_ => 0
		};
	}
}
