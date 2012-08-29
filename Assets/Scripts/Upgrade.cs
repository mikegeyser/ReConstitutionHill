using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {
	
	enum UpgradeType {PlayerHEALTH, PlayerSPEED, DELAY, ProjectileSPEED, ProjectileDAMAGE};
	UpgradeType ut;
	Player player;
	//Combat combat;
	//Projectile projectile;
	// Use this for initialization
	void Start () {
		ut = (UpgradeType)Random.Range(0,5);
		//ut = UpgradeType.PlayerSPEED;
	}
	
	void Awake()
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PerformUpgrade()
	{
		player = (Player)FindObjectOfType(typeof(Player));
		if(player == null)
		{
			return;
		}
		if(ut == UpgradeType.PlayerHEALTH)
		{
			player.ChangeHealth(2);
			print("Upgrade Health");
		}
		if(ut == UpgradeType.PlayerSPEED)
		{
			player.ChangeSpeed(2f);
			print("Upgrade Speed");
		}
		
		if((ut == UpgradeType.DELAY))
		{
			
			player.ChangeROF(-0.2f);
			print("Upgrade ROF");
		}
		
		if(ut == UpgradeType.ProjectileSPEED)
		{
			player.ChangeProjSpeed(20f);
			print("Upgrade ProjSpeed");
		}
		
		if(ut == UpgradeType.ProjectileDAMAGE)
		{
			player.ChangeStrength(20);
			print("Upgrade DMG");
		}
		player.Karma -= 0.5f;
		if(player.Karma < 0) player.Karma = 0;
		DestroyObject(gameObject);
	}
	
	
}
