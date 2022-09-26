namespace MyMocker.Models;

public record struct Method
{
    public readonly string VerbName;

    public Method(string verbName)
    {
        VerbName = verbName.ToLowerInvariant() switch 
        {
                    Verb.GET => Verb.GET,
                    Verb.DELETE => Verb.DELETE,
                    Verb.PATCH => Verb.PATCH,
                    Verb.POST => Verb.POST,
                    Verb.PUT => Verb.PUT,
                    _ => throw new ArgumentOutOfRangeException("Verb name not allow")
        };
    }

    public static implicit operator string(Method value) => value.VerbName;

    public override string ToString() => VerbName;

    public static Method CreateGet()
     => new Method(Verb.GET);
    public static Method CreateDelete()
     => new Method(Verb.DELETE);
    public static Method CreatePatch()
     => new Method(Verb.PATCH);
    public static Method CreatePost()
     => new Method(Verb.POST);
    public static Method CreatePut()
     => new Method(Verb.PUT);
}