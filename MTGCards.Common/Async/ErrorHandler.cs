using PRF.Utils.CoreComponents.Diagnostic;

namespace MTGCards.Common.Async;

internal static class ErrorHandler
{
    /// <summary>
    /// Handle consistently error accross application
    /// </summary>
    public static void HandleError(string message)
    {
        DebugCore.Fail(message);
    }
}