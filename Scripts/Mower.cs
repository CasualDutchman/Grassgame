using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mower : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
        if(col.GetComponent<Grass>()) {
            col.GetComponent<Grass>().SetGrassVolume(1);
        }
    }
}
