using System.Collections;
using System.Collections.Generic;
using Services.Window;
using UI;
using UnityEngine;

public class WindowDatabase
{
    public static List<Window> Values = new List<Window>();

    public static UI.Window Get(WindowTypeId windowTypeId)
    {
        for (int i = 0; i < Values.Count; i++)
        {
            if (Values[i].WindowTypeId == windowTypeId)
                return Values[i];
        }

        return null;
    }

    public static void Add(UI.Window window) =>
        Values.Add(window);
}
