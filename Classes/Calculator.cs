namespace BitCalculator;

public class Calculator
{
	public IntegerSize CurrentIntegerSize { get; private set; }
	public OperatorType CurrentOperator { get; private set; }
	public object PreviousValue { get; private set; }
	public object CurrentValue { get; private set; }

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
		//if (Int128.TryParse(newInput, out Int128 result))
		//	PreviousValue = result;
	}
	public void UpdateCurrentInput(string newInput)
	{
		//if (Int128.TryParse(newInput, out Int128 result))
		//	CurrentValue = result;
	}

	public void UpdateType(IntegerSize newIntegerSize)
	{
		CurrentIntegerSize = newIntegerSize;
		PreviousValue = Operations.CastToType(CurrentIntegerSize, (Int128)PreviousValue);
	}

	public void RunCalculation()
	{
		Int128 prev = (Int128)PreviousValue;
		Int128 result = unchecked(CurrentOperator switch
		{
			OperatorType.Equal => (Int128)CurrentValue,
			OperatorType.Add => prev + (Int128)CurrentValue,
			OperatorType.Subtract => prev - (Int128)CurrentValue,
			OperatorType.Multiply => prev * (Int128)CurrentValue,
			OperatorType.Divide => prev / (Int128)CurrentValue,
			OperatorType.Mod => prev % (Int128)CurrentValue,
			OperatorType.LeftShift => prev << (int)CurrentValue,
			OperatorType.RightShift => prev >> (int)CurrentValue,
			OperatorType.AND => prev & (Int128)CurrentValue,
			OperatorType.OR => prev | (Int128)CurrentValue,
			OperatorType.NOT => ~prev,
			OperatorType.XOR => prev ^ (Int128)CurrentValue,
			_ => prev
		});

		PreviousValue = Operations.CastToType(CurrentIntegerSize, result);
	}
}