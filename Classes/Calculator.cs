namespace BitCalculator;

public class Calculator
{
	public IntegerSize CurrentIntegerSize { get; private set; }
	public OperatorType CurrentOperator { get; private set; }
	public Int128 PreviousValue { get; private set; }
	public Int128 CurrentValue { get; private set; }

	public Calculator()
	{
		CurrentIntegerSize = IntegerSize.int32;
		CurrentOperator = OperatorType.Add;
		PreviousValue = 0;
		CurrentValue = 0;
	}

	public void UpdateOperator(OperatorType newOperator) => CurrentOperator = newOperator;
	public void UpdatePreviousInput(string newInput)
	{
		if (Int128.TryParse(newInput, out Int128 result))
			PreviousValue = Operations.CastToType(CurrentIntegerSize, result);
		PreviousValue = PreviousValue;
	}
	public void UpdateCurrentInput(string newInput)
	{
		if (Int128.TryParse(newInput, out Int128 result))
			CurrentValue = result;
	}

	public void UpdateType(IntegerSize newIntegerSize)
	{
		CurrentIntegerSize = newIntegerSize;
		PreviousValue = Operations.CastToType(CurrentIntegerSize, PreviousValue);
	}

	public void RunCalculation()
	{
		Int128 a = Operations.CastToType(CurrentIntegerSize, CurrentValue);
		Int128 b = PreviousValue;
		Int128 c = unchecked(CurrentOperator switch
		{
			OperatorType.Equal => a,
			OperatorType.Add => b + a,
			OperatorType.Subtract => b - a,
			OperatorType.Multiply => b * a,
			OperatorType.Divide => b / a,
			OperatorType.Mod => b % a,
			OperatorType.LeftShift => b << (int)a,
			OperatorType.RightShift => b >> (int)a,
			OperatorType.AND => b & a,
			OperatorType.OR => b | a,
			OperatorType.NOT => ~a,
			OperatorType.XOR => b ^ a,
			_ => b
		});

		PreviousValue = Operations.CastToType(CurrentIntegerSize, c);
	}
}