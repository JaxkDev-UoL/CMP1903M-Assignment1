using System;
namespace CMP1903M_A01_2223
{

	//NEW Custom exception class, used by program when handling invalid values.

	public class ValueException : Exception {

		public ValueException(int value, string message) : this(value.ToString(), message) { }

		public ValueException(string value, string message) : base("Value: " + value + ", Message: " + message) {}

	}
}

