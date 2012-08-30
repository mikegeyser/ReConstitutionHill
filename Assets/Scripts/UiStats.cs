using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class UiStats : MonoBehaviour {
	public GUISkin UI;
    public int LeftOffset;
    public int BottomOffset;
    public int Height;
    public int Width;
	private Player pl;
	
	void Awake()
	{
		pl = (Player)FindObjectOfType(typeof(Player));
	}
	
    void OnGUI()
    {
        GUI.skin = UI;

        var sb = new StringBuilder("STATS:" + Environment.NewLine + Environment.NewLine);
        sb.AppendLine("Speed: " + pl.Speed);
        sb.AppendLine("Cooldown: " + pl.ROF);
        sb.AppendLine("Damage: " + pl.Strength);
		sb.AppendLine("Shot Speed: " + pl.ProjSpeed);

        GUI.Label(new Rect(LeftOffset, Screen.height - Height - BottomOffset - Height, Width, Height), sb.ToString(), "box");
    }
}
