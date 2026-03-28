namespace BitCalculator;

public class Calculator
{
	public IntType SelectedType { get; private set; }
	public object PreviousValue { get; private set; }
	public OperatorType CurrentOperator { get; private set; }
	public string CurrentInput { get; private set; }

	public bool TypeIsSigned => (int)SelectedType % 2 == 0;

	public Calculator()
	{
		SelectedType = IntType.uint8;
		PreviousValue = byte.MinValue;
		CurrentOperator = OperatorType.Add;
		CurrentInput = "0";
	}

	public void UpdateInput(string newInput)
	{
		CurrentInput = newInput;
	}

	public void UpdateOperator(OperatorType newOperator)
	{
		CurrentOperator = newOperator;
	}

	public void UpdateType(IntType newType)
	{
		SelectedType = newType;

		if (PreviousValue is sbyte or short or int or long)
		{
			// Cast previous signed value to new value type.
			long signedValue = Convert.ToInt64(PreviousValue);
			PreviousValue = CastToType(signedValue);
		}
		else
		{
			// Cast previous unsigned value to new value type. 
			ulong unsignedValue = Convert.ToUInt64(PreviousValue);
			PreviousValue = CastToType(unsignedValue);
		}
	}

	public void RunCalculation()
	{
		if (TypeIsSigned)
		{
			if (!long.TryParse(CurrentInput, out long input)) return;
			long prev = Convert.ToInt64(PreviousValue);

			long result = unchecked(CurrentOperator switch
			{
				OperatorType.Equal => input,
				OperatorType.Add => prev + input,
				OperatorType.Subtract => prev - input,
				OperatorType.Multiply => prev * input,
				OperatorType.Divide => prev / input,
				OperatorType.Mod => prev % input,
				OperatorType.LeftShift => prev << (int)input,
				OperatorType.RightShift => prev >> (int)input,
				OperatorType.AND => prev & input,
				OperatorType.OR => prev | input,
				OperatorType.NOT => ~prev,
				OperatorType.XOR => prev ^ input,
				_ => prev
			});

			PreviousValue = CastToType(result);
		}
		else
		{
			if (!ulong.TryParse(CurrentInput, out ulong input)) return;
			ulong prev = Convert.ToUInt64(PreviousValue);

			ulong result = unchecked(CurrentOperator switch
			{
				OperatorType.Equal => input,
				OperatorType.Add => prev + input,
				OperatorType.Subtract => prev - input,
				OperatorType.Multiply => prev * input,
				OperatorType.Divide => prev / input,
				OperatorType.Mod => prev % input,
				OperatorType.LeftShift => prev << (int)input,
				OperatorType.RightShift => prev >> (int)input,
				OperatorType.AND => prev & input,
				OperatorType.OR => prev | input,
				OperatorType.NOT => ~prev,
				OperatorType.XOR => prev ^ input,
				_ => prev
			});

			PreviousValue = CastToType(result);
		}
	}

	private object CastToType(long value) => SelectedType switch
	{
		IntType.int8 => unchecked((sbyte)value),
		IntType.uint8 => unchecked((byte)value),
		IntType.int16 => unchecked((short)value),
		IntType.uint16 => unchecked((ushort)value),
		IntType.int32 => unchecked((int)value),
		IntType.uint32 => unchecked((uint)value),
		IntType.int64 => value,
		IntType.uint64 => unchecked((ulong)value),
		_ => throw new ArgumentException("Unsupported type")
	};

	private object CastToType(ulong value) => SelectedType switch
	{
		IntType.int8 => unchecked((sbyte)value),
		IntType.uint8 => unchecked((byte)value),
		IntType.int16 => unchecked((short)value),
		IntType.uint16 => unchecked((ushort)value),
		IntType.int32 => unchecked((int)value),
		IntType.uint32 => unchecked((uint)value),
		IntType.int64 => unchecked((long)value),
		IntType.uint64 => value,
		_ => throw new ArgumentException("Unsupported type")
	};

}
