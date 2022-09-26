using System.Runtime.Serialization;
namespace MyMocker.Core;

public class PathNotFoundException : Exception
{
    public PathNotFoundException() { }

    public PathNotFoundException(string? message) : base(message) { }

    public PathNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }

    protected PathNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context){ }
}

public class InvalidPathException : Exception
{
    public InvalidPathException() { }

    public InvalidPathException(string? message) : base(message) { }

    public InvalidPathException(string? message, Exception? innerException) : base(message, innerException) { }

    protected InvalidPathException(SerializationInfo info, StreamingContext context) : base(info, context){ }
}