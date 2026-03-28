using System.Text;

namespace BitCalculator;

public static class Bell
{
	public static string GetBinary(IntegerSize type, object prev) => BuildString(type, prev, "B");
	public static string GetHexidecimal(IntegerSize type, object prev) => BuildString(type, prev, "X");

	private static string BuildString(IntegerSize type, object prev, string format)
	{
		if (prev is string prevString && Int128.TryParse(prevString, out Int128 result))
			prev = result;

		string value = type switch
		{
			IntegerSize.int8 => ((sbyte)prev).ToString(format),
			IntegerSize.uint8 => ((byte)prev).ToString(format),
			IntegerSize.int16 => ((short)prev).ToString(format),
			IntegerSize.uint16 => ((ushort)prev).ToString(format),
			IntegerSize.int32 => ((int)prev).ToString(format),
			IntegerSize.uint32 => ((uint)prev).ToString(format),
			IntegerSize.int64 => ((long)prev).ToString(format),
			IntegerSize.uint64 => ((ulong)prev).ToString(format),
			_ => "0"
		};

		return SpaceNumber(value, 4, '_');
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
