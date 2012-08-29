using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

    public float Karma;
    public int Health;
    public float Speed;
    public int Strength; // Related to the strength of the gun, not the person.
    public float ROF;
	public float ProjSpeed;
	private List<Upgrade> upgrades; 
	Combat combat;
	ThirdPersonController tps;
	
	// Use this for initialization
	void Start ()
	{
		upgrades = new List<Upgrade>();
	}
	
	void Awake()
	{
		combat = (Combat)FindObjectOfType(typeof(Combat));	
		tps = (ThirdPersonController)FindObjectOfType(typeof(ThirdPersonController));
	}
	
	// Update is called once per frame
	void Update () {
	 	if(Karma<0) Karma = 0;
		UseUpgrade();
	}

    public float GetKarmaPercentage()
    {
        return Karma/10f * 100f;
    }
	
	public void TakeDamage(int damage)
	{
		Health -= damage;
		if(Health <= 0)
		{
			Application.LoadLevel(0);
			DestroyObject(gameObject);
		}
	}
	
	public void UseUpgrade()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(upgrades.Count == 0) return;
			Upgrade up = upgrades[upgrades.Count-1];
			upgrades.Remove(up);
			up.PerformUpgrade();
		}
	}
	
	public void ChangeHealth(int amount)
	{
		Health += amount;
		if(Health > 30) Health = 30;
		if(Health < 3) Health = 3;
	}
	
	public void ChangeSpeed(float amount)
	{
		Speed += amount;
		if(Speed > 20f) Speed = 20f;
		if(Speed < 5f) Speed = 5f;
		tps.runSpeed = Speed * 3f;
		tps.trotSpeed = Speed * 1.5f;
		tps.walkSpeed = Speed;
	}
	
	public void ChangeStrength(int amount)
	{
		Strength += amount;
		if(Strength < 50) Strength = 50;
		if(Strength > 100) Strength = 100;
	}
	
	public void ChangeROF(float amount)
	{
		ROF += amount;
		if(ROF < 0.5f) ROF = 0.5f;
		if(ROF > 3f) ROF = 3f;
		combat.delay = ROF;
		
	}
	
	public void ChangeProjSpeed(float amount)
	{
		ProjSpeed += amount;
		if(ProjSpeed < 30f) ProjSpeed = 30f;
		if(ProjSpeed > 300f) ProjSpeed = 200f;
	}
	
	void OnTriggerEnter(Collider c)
	{
		Upgrade up = (Upgrade)c.GetComponent<Upgrade>();
		if(up != null)
		{
			upgrades.Add(up);
			c.gameObject.renderer.enabled = false;
			c.gameObject.collider.enabled = false;
			c.GetComponentInChildren<Light>().enabled = false;
		}
	}
	
	public int getNumberOfUpgrades()
	{
		return upgrades.Count;
	}
}
