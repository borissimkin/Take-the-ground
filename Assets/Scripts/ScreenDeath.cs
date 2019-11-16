using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScreenDeath : MonoBehaviour {

    public bool isdead = false;
  
    // Use this for initialization
    void Start () {
 
    }

    public void IsDeath()
    {
            gameObject.SetActive(true);
            isdead = true;
    }
	

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
                gameObject.SetActive(false);
                isdead = false;
        }
    }
}
