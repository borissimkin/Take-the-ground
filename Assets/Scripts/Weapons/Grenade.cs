using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ToDo: спрайт гранаты
public class Grenade : MonoBehaviour {
    public int damageExplosion = 50;
    public Vector3 endPoint;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x == endPoint.x && gameObject.transform.position.y == endPoint.y)
        {
            gameObject.GetComponent<Explosion>().Boom();
            Destroy(this.gameObject);
        }
	}
}
