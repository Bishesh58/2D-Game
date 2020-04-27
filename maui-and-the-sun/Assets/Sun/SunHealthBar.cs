using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunHealthBar : MonoBehaviour {

	Vector3 localScale;

	// Use this for initialization
	void Start () {
        localScale = transform.localScale;
       // localScale.y = 1;
       // localScale.z = 0;


    }

    // Update is called once per frame
    void Update () {
		localScale.x = SunDamage.healthAmount;
		transform.localScale = localScale;
	}
}
