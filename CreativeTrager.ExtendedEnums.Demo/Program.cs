using System.Text;
using CreativeTrager.ExtendedEnums;


// ReSharper disable LocalizableElement


// Create an enum source
var enumSource = new EnumSource<Color>();


// Get length of enum
var length = enumSource.Length;

// Get min and max element indexes
var minElementIndex = enumSource.MinElementIndex;
var maxElementIndex = enumSource.MaxElementIndex;

// Get all enum values as ReadOnlySpan<TEnum>
var values = enumSource.Values;

// Get all enum value names as ReadOnlySpan<string>
var names = enumSource.Names;


// Get random enum value in range from enumMinElementIndex to enumMaxElementIndex
var randomValue = enumSource.GetRandom();

// Get random enum value in range from enumMinElementIndex to custom upper bound index
var randomValueToCustomUpperBound = enumSource.GetRandom(toIndexInclusive: 2);

// Get random enum value in range from custom lower bound index to custom upper bound index
var randomValueFromToCustomBounds1 = enumSource.GetRandom(fromIndexInclusive: 2, toIndexInclusive: 5);
var randomValueFromToCustomBounds2 = enumSource.GetRandom(fromIndexInclusive: 45, toIndexInclusive: 4);

Console.WriteLine(new StringBuilder()
	.AppendLine($"Extended Enums Demo (v.0.0.1, rev.1)")
	.AppendLine()
	.AppendLine()
	.AppendLine($"Wrapper: {typeof(EnumSource<>).FullName}.")
	.AppendLine($"Target : {typeof(Color).FullName}")
	.AppendLine()
	.AppendLine($"RESULTS:")
	.AppendLine()
	.AppendLine($"Enum length: {length}")
	.AppendLine($"Enum min element index: {minElementIndex}")
	.AppendLine($"Enum max element index: {maxElementIndex}")
	.AppendLine()
	.AppendLine($"Enum values: {string.Join(", ", values.ToArray())}")
	.AppendLine()
	.AppendLine($"Enum random value: {randomValue}")
	.AppendLine($"Enum random value to custom upper bound: {randomValueToCustomUpperBound}")
	.AppendLine($"Enum random value from & to custom upper bound 1: {randomValueFromToCustomBounds1}")
	.AppendLine($"Enum random value from & to custom upper bound 2: {randomValueFromToCustomBounds2}")
);

Console.Write($"Press <Enter> to end the program...");
Console.ReadLine();


internal enum Color 
{
	Red,    // index: 0
	Orange, // index: 1
	Yellow, // index: 2
	Green,  // index: 3
	Blue,   // index: 4
	Indigo, // index: 5
	Violet  // index: 6
}