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
        //print("ЛЕЧУ");
        //print(string.Format("trans x{0}, trans y{1}, point x{2}, point y{3}", transform.position.x, transform.position.y, endPoint.x, endPoint.y));
		if (gameObject.transform.position.x == endPoint.x && gameObject.transform.position.y == endPoint.y)
        {
            print("Дошел до точки");
            gameObject.GetComponent<Explosion>().Boom();
            Destroy(this.gameObject, 5);
        }
	}
}
