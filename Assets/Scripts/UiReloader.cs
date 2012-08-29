using UnityEngine;
using System.Collections;

public class UiReloader : MonoBehaviour {
    public GUISkin UI;
    public int X;
    public int Y;
    public int Height;
    public int Width;

    private Combat combat;

    void Awake()
    {
        combat = (Combat)FindObjectOfType(typeof(Combat));
    }

    void OnGUI()
    {
        GUI.skin = UI;

        var reloadTime = 0f;
        if (combat.IsReloading(out reloadTime))
            GUI.Label(new Rect(X, Y, Width, Height), string.Format("Reload: {0}s", reloadTime), "large");
    }
}
