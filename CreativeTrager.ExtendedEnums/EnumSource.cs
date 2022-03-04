using System.Security.Cryptography;
using CreativeTrager.ExtendedEnums.Resources;


// ReSharper disable MemberCanBePrivate.Global


namespace CreativeTrager.ExtendedEnums;
public sealed class EnumSource<TEnum>
where TEnum : struct, Enum
{
	private readonly TEnum [] _values;
	private readonly string[] _names;

	public EnumSource() 
	{
		this._values = Enum.GetValues<TEnum>();
		this._names  = this._values.Select(value
			=> value.ToString()).ToArray();
	}

	public ReadOnlySpan<TEnum> Values => _values;
	public ReadOnlySpan<string> Names => _names;

	public int Length => Names.Length;

	public int MinElementIndex => 0;
	public int MaxElementIndex => Length - 1;

	#region GetRandom

	public TEnum GetRandom() => GetRandom(MaxElementIndex);
	public TEnum GetRandom(int toIndexInclusive) => GetRandom(MinElementIndex, toIndexInclusive);
	public TEnum GetRandom(int fromIndexInclusive, int toIndexInclusive) 
	{
		if(fromIndexInclusive < MinElementIndex || fromIndexInclusive > MaxElementIndex) 
		{
			throw new ArgumentOutOfRangeException(
				paramName: nameof(fromIndexInclusive), actualValue: fromIndexInclusive,
				message: string.Format(ExceptionMessages.EnumSourceGetRandomBoundArgumentOutOfRange,
					typeof(TEnum), nameof(fromIndexInclusive), MinElementIndex, MaxElementIndex)
			);
		}
		if(toIndexInclusive < fromIndexInclusive || toIndexInclusive > MaxElementIndex) 
		{
			throw new ArgumentOutOfRangeException(
				paramName: nameof(toIndexInclusive), actualValue: toIndexInclusive,
				message: string.Format(ExceptionMessages.EnumSourceGetRandomBoundArgumentOutOfRange,
					typeof(TEnum), nameof(toIndexInclusive), fromIndexInclusive, MaxElementIndex)
			);
		}

		return _values[RandomNumberGenerator
			.GetInt32(fromIndexInclusive, toIndexInclusive+1)];
	}

	#endregion
}