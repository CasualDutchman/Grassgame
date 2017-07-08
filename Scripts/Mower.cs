using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mower : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
        if(col.tag.Equals("Grass")) {
            col.transform.localScale = new Vector3(1, 1, .1f);
        }
    }
}
