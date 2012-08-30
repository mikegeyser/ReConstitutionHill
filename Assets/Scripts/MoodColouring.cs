using UnityEngine;
using System.Collections;

public class MoodColouring : MonoBehaviour {
	
	private Player player;
	public Material[] colors;
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake()
	{
		player = (Player)FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
		//material.color = new Color(128,player.GetKarmaPercentage()*256,0);
		//gameObject.renderer.material.color = new Color(player.GetKarmaPercentage()*256,256-(256*player.GetKarmaPercentage()),0);
		for(int i = 0; i < colors.Length; i++)
		{
			if(player.GetKarmaPercentage() <= i  * (100/(colors.Length-1)))
			{
				gameObject.renderer.material.color = colors[i].color;
				break;
			}
		}
	}
}
