using UnityEngine;
using System.Collections;

public class VolumeAdjuster : MonoBehaviour {
	
	private Player player;
	public AudioSource happy;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake()
	{
		player = (Player)FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
		happy.volume = (player.GetKarmaPercentage())/100;
	}
}
