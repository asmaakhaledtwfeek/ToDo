using System.Reflection;

namespace ToDo.Presentation;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}