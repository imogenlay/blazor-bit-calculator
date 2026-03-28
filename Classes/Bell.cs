using System.Text;

namespace BitCalculator;

public static class Bell
{
	public static string GetHexidecimal(IntType type, object prev) => BuildString(type, prev, "X");
	public static string GetBinary(IntType type, object prev) => BuildString(type, prev, "B");

	private static string BuildString(IntType type, object prev, string format)
	{
		string value = type switch
		{
			IntType.int8 => ((sbyte)prev).ToString(format),
			IntType.uint8 => ((byte)prev).ToString(format),
			IntType.int16 => ((short)prev).ToString(format),
			IntType.uint16 => ((ushort)prev).ToString(format),
			IntType.int32 => ((int)prev).ToString(format),
			IntType.uint32 => ((uint)prev).ToString(format),
			IntType.int64 => ((long)prev).ToString(format),
			IntType.uint64 => ((ulong)prev).ToString(format),
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
