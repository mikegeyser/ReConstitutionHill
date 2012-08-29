using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public float initialRespawnDelay = 5f, initialEnemyProbability = 0.5f;
	private float spawnTime = 0f;
	public GameObject Enemies;
	public static int MaxNumberOfEnemies = 1000;
	private Player player;
	//public static int numberOfEnemies = 0;
	// Use this for initialization
	void Start () {
		spawnTime = Random.Range(-2f, 2f);
	}
	
	void Awake()
	{
		player = (Player)FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
	
		if((Time.timeSinceLevelLoad >= spawnTime + initialRespawnDelay)&&(FindObjectsOfType(typeof(Enemy)).Length<MaxNumberOfEnemies))
		{
			spawnTime = Time.timeSinceLevelLoad;
			float probability = initialEnemyProbability + ((100f-player.GetKarmaPercentage())*0.5f/100f); 
			print(probability);
			GameObject enemyObj = (GameObject)Instantiate(Enemies,transform.position, Quaternion.identity);
			Enemy enemy = (Enemy)enemyObj.GetComponent<Enemy>();
			if(enemy==null) return;
			enemy.isHostile = (Random.Range(0f,1f) >  1f-probability);
			//numberOfEnemies++;
		}
	}
}
