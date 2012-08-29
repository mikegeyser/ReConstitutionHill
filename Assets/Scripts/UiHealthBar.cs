using UnityEngine;
using System.Collections;
using System.Text;

public class UiHealthBar : MonoBehaviour {
    public GUISkin UI;
    public int BottomOffset;
    public int Height;
    public int Width;

    private Player player;

    void Awake()
    {
        player = (Player)FindObjectOfType(typeof(Player));

    }

    void OnGUI()
    {
        GUI.skin = UI;

        var sb = new StringBuilder("Health: ");

        for (int i = 0; i < player.Health; i++)
            sb.Append("|");
        GUI.Label(new Rect((Screen.width / 2) - (Width / 2), Screen.height - Height - BottomOffset, Width, Height), sb.ToString(), "large");
		
		GUI.Label(new Rect(0f, Height, Width, Height), "Upgrades: " + player.getNumberOfUpgrades().ToString(), "large");
    }
}
