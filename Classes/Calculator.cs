namespace BitCalculator;

public class Calculator
{
	public IntegerSize CurrentIntegerSize { get; private set; }
	public OperatorType CurrentOperator { get; private set; }
	public object PreviousValue { get; private set; }
	public string CurrentInput { get; private set; }

	public Calculator()
	{
		CurrentIntegerSize = IntegerSize.int32;
		PreviousValue = 0;
		CurrentOperator = OperatorType.Add;
		CurrentInput = "0";
	}

	public void UpdateInput(string newInput) => CurrentInput = newInput;
	public void UpdateOperator(OperatorType newOperator) => CurrentOperator = newOperator;

	public void UpdateType(IntegerSize newIntegerSize)
	{
		CurrentIntegerSize = newIntegerSize;

		if (PreviousValue is sbyte or short or int or long)
		{
			// Cast previous signed value to new value type.
			long signedValue = Convert.ToInt64(PreviousValue);
			PreviousValue = Operations.CastToType(CurrentIntegerSize, signedValue);
		}
		else
		{
			// Cast previous unsigned value to new value type. 
			ulong unsignedValue = Convert.ToUInt64(PreviousValue);
			PreviousValue = Operations.CastToType(CurrentIntegerSize, unsignedValue);
		}
	}

	public void RunCalculation()
	{
		if (CurrentIntegerSize == IntegerSize.uint64)
		{
			// do ulong
			if (!ulong.TryParse(CurrentInput, out ulong uvalue)) return;

			// Unsigned long has to function differently due to the fact
			// that it can have values that are outside the range of signed long.
			ulong prev = Convert.ToUInt64(PreviousValue);
			ulong result = unchecked(CurrentOperator switch
			{
				OperatorType.Equal => uvalue,
				OperatorType.Add => prev + uvalue,
				OperatorType.Subtract => prev - uvalue,
				OperatorType.Multiply => prev * uvalue,
				OperatorType.Divide => prev / uvalue,
				OperatorType.Mod => prev % uvalue,
				OperatorType.LeftShift => prev << (int)uvalue,
				OperatorType.RightShift => prev >> (int)uvalue,
				OperatorType.AND => prev & uvalue,
				OperatorType.OR => prev | uvalue,
				OperatorType.NOT => ~prev,
				OperatorType.XOR => prev ^ uvalue,
				_ => prev
			});

			PreviousValue = Operations.CastToType(CurrentIntegerSize, result);

			return;
		}

		if (long.TryParse(CurrentInput, out long value))
		{
			long prev = Convert.ToInt64(PreviousValue);
			long result = unchecked(CurrentOperator switch
			{
				OperatorType.Equal => value,
				OperatorType.Add => prev + value,
				OperatorType.Subtract => prev - value,
				OperatorType.Multiply => prev * value,
				OperatorType.Divide => prev / value,
				OperatorType.Mod => prev % value,
				OperatorType.LeftShift => prev << (int)value,
				OperatorType.RightShift => prev >> (int)value,
				OperatorType.AND => prev & value,
				OperatorType.OR => prev | value,
				OperatorType.NOT => ~prev,
				OperatorType.XOR => prev ^ value,
				_ => prev
			});

			PreviousValue = Operations.CastToType(CurrentIntegerSize, result);
		}
	}


}
