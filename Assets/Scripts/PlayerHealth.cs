using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHealth : Health {

    protected GameObject scrDeath;
   
    public override void Death()
    {
        gameObject.GetComponent<ControllerMove>().isdead = true;
        gameObject.GetComponent<ShootSystem>().fire = false;
        scrDeath = Resources.FindObjectsOfTypeAll(typeof(GameObject)).FirstOrDefault(go => go.name == "ScreenDeath") as GameObject;
        scrDeath.GetComponent<ScreenDeath>().IsDeath();
    }
}
