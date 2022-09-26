using System.Runtime.Serialization;
namespace MyMocker.Core;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException() { }

    public ResourceNotFoundException(string? message) : base(message) { }

    public ResourceNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }

    protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context){ }
}

public class ResourceNameNotFoundException : Exception
{
    public ResourceNameNotFoundException() { }

    public ResourceNameNotFoundException(string? message) : base(message) { }

    public ResourceNameNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }

    protected ResourceNameNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context){ }
}

public class InvalidResourceException : Exception
{
    public InvalidResourceException() { }

    public InvalidResourceException(string? message) : base(message) { }

    public InvalidResourceException(string? message, Exception? innerException) : base(message, innerException) { }

    protected InvalidResourceException(SerializationInfo info, StreamingContext context) : base(info, context){ }
}