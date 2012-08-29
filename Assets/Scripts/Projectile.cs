using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float speed = 9f, lifetime = 1.5f;
	public int damage = 50;
	private float bornTime;
	// Use this for initialization
	void Start () {
		bornTime = Time.timeSinceLevelLoad;
		Player pl = (Player)FindObjectOfType(typeof(Player));
		speed = pl.ProjSpeed;
		damage = pl.Strength;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed*Time.deltaTime,0,0);
		
		if(Time.timeSinceLevelLoad >= bornTime + lifetime)
		{
			DestroyObject(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider c)
	{
//		Combat combat = c.GetComponent<Combat>();
//		print(c.name);
//		if (c.name == "Terrain_Streets")
//		{
//			DestroyObject(gameObject);
//		}
		
		Enemy enemy = (Enemy)c.GetComponent<Enemy>();
		if(enemy != null)
		{
			enemy.TakeDamage(damage);
			DestroyObject(gameObject);
			
		}
	}
}
