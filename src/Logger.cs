using System;
using Godot;


class Logger
{
    static void Log(String level, String msg, params object[] items)
    {
        var formattedMsg = String.Format(msg, items);
        GD.Print(String.Format(
            "[{0}]: {1}", level, formattedMsg
        ));
    }

    public static void Debug(String msg, params object[] items)
    {
#if DEBUG
        Log("DEBUG", msg, items);
#endif  // DEBUG
    }
    public static void Info(String msg, params object[] items) => Log("INFO", msg, items);
}