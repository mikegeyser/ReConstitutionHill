using System.IO;
using System.Linq;
using UnityEngine;
using System.Collections;
using System;

public class UiTimer : MonoBehaviour
{
    public GUISkin UI;
    public int RightOffset;
    public int TopOffset;
    public int Height;
    public int Width;

    private TimeSpan timer;


    private float timeScaleStorage; // This is just cause I don't know what it should be.
    public Rect windowRect;
    public Vector2 scrollPosition;

    void Update()
    {
        //	if(timer.Milliseconds <= 0) Application.LoadLevel(0);
    }

    void Awake()
    {
        timeScaleStorage = UnityEngine.Time.timeScale;


        windowRect = new Rect(Screen.width / 4, 100, Screen.width / 2, 2 * Screen.height / 3);
    }

    private Objective GetCurrentObjective()
    {
        foreach (Objective o in FindObjectsOfType(typeof(Objective)))
        {
            if (o.Active)
                return o;
        }

        return null;
    }

    void OnGUI()
    {
        var objective = GetCurrentObjective();

        if (objective == null) return;

        GUI.skin = UI;

        GUI.Label(new Rect(Screen.width - Width - RightOffset, TopOffset, Width, Height), string.Format("{0:c}", objective.GetTimeRemaining()), "large");

        if (objective.Complete)
        {
            // Pause the game
            Time.timeScale = 0;

            windowRect = GUI.Window(0, windowRect, DrawDialog, string.Empty, "box");
        }
    }

    void DrawDialog(int windowID)
    {
        var objective = GetCurrentObjective();

        if (objective == null) return;

        var textAsset = Resources.Load(objective.File) as TextAsset;

        GUILayout.BeginHorizontal();
        GUILayout.Label(objective.Title, "small");
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Done"))
        {
            Time.timeScale = timeScaleStorage;
            objective.SetNext();
        }
        GUILayout.Space(50);
        GUILayout.EndHorizontal();
        GUILayout.Space(10);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

        GUILayout.Label(textAsset.text, "small");

        GUILayout.EndScrollView();
    }
}
