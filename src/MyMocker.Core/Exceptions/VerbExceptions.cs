using System.Runtime.Serialization;
namespace MyMocker.Core;

public class VerbNotFoundException : Exception
{
    public VerbNotFoundException() { }

    public VerbNotFoundException(string? message) : base(message) { }

    public VerbNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }

    protected VerbNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context){ }
}

public class InvalidVerbException : Exception
{
    public InvalidVerbException() { }

    public InvalidVerbException(string? message) : base(message) { }

    public InvalidVerbException(string? message, Exception? innerException) : base(message, innerException) { }

    protected InvalidVerbException(SerializationInfo info, StreamingContext context) : base(info, context){ }
}