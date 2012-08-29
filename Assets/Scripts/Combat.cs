using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {
	
	public GameObject projectile, sphere;
	public float delay = 0.5f, accuracy = 0.1f;
	private float fireTime = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast(ray,out hit))
		{
			Vector3 travelVector =  hit.point - transform.position;
			Vector3 rotation = new Vector3(0,(Mathf.Atan2(travelVector.z,travelVector.x)* -180 / Mathf.PI),0);
			sphere.transform.rotation = Quaternion.Euler(rotation + new Vector3(0,90,0)); 
			if((Input.GetAxisRaw("Fire1")==1)&&(Time.timeSinceLevelLoad >= fireTime + delay))
		{
//			float distanceFromCamera = Camera.main.transform.position.y - transform.position.y;
//			Vector3 myNewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
//			//print(myNewPosition);
//			Vector3 relativeToPlayer = myNewPosition - transform.position;
//			Vector3 rotation = new Vector3(0,(Mathf.Atan2(relativeToPlayer.z,relativeToPlayer.x)* -180 / Mathf.PI),0);
//			Instantiate(projectile,transform.position,Quaternion.Euler(rotation));
//			fireTime = Time.timeSinceLevelLoad;
			//Instantiate(projectile,transform.position, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0,90f,0)));
			
			  // Get your player object's position (could be any way, this is just one possible way)
			  //var playerT = GameObject.FindWithTag("Player").transform;
			  // Now you have where your player is and a 3D point the mouse is over
			  	Debug.DrawLine (transform.position, hit.point);
				
			 	Instantiate(projectile,transform.position,Quaternion.Euler(rotation));
				fireTime = Time.timeSinceLevelLoad;
			
			
		}
			
		}
		
		
	}

    public bool IsReloading(out float reloadTime)
    {
        reloadTime = delay + (fireTime - Time.timeSinceLevelLoad);
        //print("Reload Time:" + reloadTime);
        return (reloadTime > 0);
    }
}
