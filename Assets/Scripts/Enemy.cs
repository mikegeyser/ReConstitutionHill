using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float speed = 4f, engagedDistanceSquared = 50f;
	public int health = 100, damage = 20;
	private Transform player;
	public Material Enemymat;
	private bool isEngaged = false;
	public bool isHostile = false;
	public Light light;
	public GameObject upgrade;
	//Spawner sp;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake()
	{
		Vector3 rotation = new Vector3(0,(Mathf.Atan2(Random.Range(0f,5000f),Random.Range(0f,5000f))* -180 / Mathf.PI),0);
		transform.rotation = Quaternion.Euler(rotation);
		//sp = (Spawner)FindObjectOfType(typeof(Spawner));
		try
		{
			player = ((Combat)FindObjectOfType(typeof(Combat))).transform;
		}
		catch
		{
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed*Time.deltaTime,0,0);
		if(isHostile)
		{
			TrackPlayer();
			ChangeMaterial();
		}
		else
		{
				
		}
	}
	
	void ChangeMaterial()
	{
		if(player==null) return;
		if(isEngaged) return;
		
		if(Vector3.SqrMagnitude(player.position - transform.position) < engagedDistanceSquared)
		{
			renderer.material = Enemymat;
			speed = speed * Random.Range(2f, 4f);
			isEngaged = true;
			if(light!=null)
			{
				light.color = Color.red;
			}
		}
	}
	
	void TrackPlayer()
	{
		if(player==null) return;
		Vector3 travelVector =  player.position - transform.position;
		Vector3 rotation = new Vector3(0,(Mathf.Atan2(travelVector.z,travelVector.x)* -180 / Mathf.PI),0);
		transform.rotation = Quaternion.Euler(rotation);
	}
	
	public void TakeDamage(int damage)
	{
		health -= damage;
		isHostile = true;
		try
		{
			if(isHostile)
				player.gameObject.GetComponent<Player>().Karma -= 0.25f;
			else
				player.gameObject.GetComponent<Player>().Karma -= 0.5f;
		}
		catch
		{
		}
		if(health <= 0)
		{
			if(Random.Range(0f,1f) > 0.3f) Instantiate(upgrade,transform.position,transform.rotation);
			DestroyObject(gameObject);
			
			//if(sp == null) return;
			//sp.numberOfEnemies--;
		}
	}
	
	void OnCollisionEnter(Collision c)
	{
		if(!isHostile) return;
		try
		{
			Player player = (Player)c.gameObject.transform.parent.GetComponent<Player>();
			
			print(c.gameObject.name);
			
			if(player != null)
			{
				player.TakeDamage(damage);
				DestroyObject(gameObject);
			}
		}
		catch{}
	}
	
	
}
