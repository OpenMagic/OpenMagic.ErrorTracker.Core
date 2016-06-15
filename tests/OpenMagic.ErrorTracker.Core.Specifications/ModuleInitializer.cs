/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        InitializeFluentAssertions();
    }

    private static void InitializeFluentAssertions()
    {
        // Default implementation excludes all objects in System namespace. Therefore
        // System.Exception cannot be compared which seems a reasonable thing to do to me.
        FluentAssertions.AssertionOptions.IsValueType = type => type.IsValueType;
    }
}