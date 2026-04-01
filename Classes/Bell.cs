namespace BitCalculator;
using System.Text;

public static class Bell
{
	public static string GetDecimal(IntegerSize type, Int128 value)
	{
		return Operations.CastToType(type, value).ToString();
	}

	public static string GetBinary(IntegerSize type, Int128 value) => BuildString(type, value, "B");
	public static string GetBinary(IntegerSize type, string value)
	{
		if (Int128.TryParse(value, out Int128 result))
			return GetBinary(type, result);
		return "Unknown Binary Value";
	}

	public static string GetHexidecimal(IntegerSize type, Int128 value) => BuildString(type, value, "X");
	public static string GetHexidecimal(IntegerSize type, string value)
	{
		if (Int128.TryParse(value, out Int128 result))
			return GetHexidecimal(type, result);
		return "Unknown Hex Value";
	}

	private static string BuildString(IntegerSize type, Int128 value, string format)
	{
		string text = unchecked(type switch
		{
			IntegerSize.int8 => ((sbyte)value).ToString(format),
			IntegerSize.uint8 => ((byte)value).ToString(format),
			IntegerSize.int16 => ((short)value).ToString(format),
			IntegerSize.uint16 => ((ushort)value).ToString(format),
			IntegerSize.int32 => ((int)value).ToString(format),
			IntegerSize.uint32 => ((uint)value).ToString(format),
			IntegerSize.int64 => ((long)value).ToString(format),
			IntegerSize.uint64 => ((ulong)value).ToString(format),
			_ => "0"
		});

		return SpaceNumber(text, 4, '_');
	}

	public static string SpaceNumber(string number, int split, char character)
	{
		StringBuilder sb = new StringBuilder();
		int check = (number.Length - 1) % split;
		for (int i = 0; i < number.Length; i++)
		{
			sb.Append(number[i]);

			if (number[i] != '-' &&
				i + 1 < number.Length &&
				check == i % split)
				sb.Append(character);
		}

		return sb.ToString();
	}
}
