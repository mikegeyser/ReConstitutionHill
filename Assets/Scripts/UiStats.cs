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
        sb.AppendLine("Speed: " + pl.Speed.ToString());
        sb.AppendLine("Cooldown: " + pl.ROF.ToString());
        sb.AppendLine("Damage: " + pl.Strength.ToString());
		sb.AppendLine("Shot Speed: " + pl.ProjSpeed.ToString());

        GUI.Label(new Rect(LeftOffset, Screen.height - Height - BottomOffset - Height, Width, Height), sb.ToString(), "box");
    }
}
