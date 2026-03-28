namespace BitCalculator.Layout;

public struct ByteModifier
{
	public byte Value;
	public int Offset;

	public ByteModifier(byte value, int offset)
	{
		Value = value;
		Offset = offset;
	}
}