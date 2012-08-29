using UnityEngine;
using System.Collections;

public class UiKarmaBox : MonoBehaviour {

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

        GUI.Label(new Rect((Screen.width / 2) - (Width / 2), Screen.height - Height - BottomOffset, Width, Height), string.Format("Humanity: {0}%", player.GetKarmaPercentage()), "large");
    }
}
