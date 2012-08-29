using UnityEngine;
using System.Text;
using System;

public class UiHelpBox : MonoBehaviour {
    public GUISkin UI;
    public int LeftOffset;
    public int BottomOffset;
    public int Height;
    public int Width;

    void OnGUI()
    {
        GUI.skin = UI;

        var sb = new StringBuilder("Halp!?" + Environment.NewLine + Environment.NewLine);
        sb.AppendLine("Move: WASD");
        sb.AppendLine("Sprint: SHIFT");
        sb.AppendLine("Shoot: L. CLICK");
        sb.AppendLine("Use: E");

        GUI.Label(new Rect(LeftOffset, Screen.height - Height - BottomOffset, Width, Height), sb.ToString(), "box");
    }
}
