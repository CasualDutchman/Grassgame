using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour {

    [Range(0, 9)]
    public int volume = 9;

    int timer = 0;
    float randomNumber = 0;

	void Start () {
        UpdateGrass();
        randomNumber = Random.Range(1, 30);
    }
	
	void FixedUpdate () {
        //timer++;
        if(timer >= 90 + randomNumber) {
            if(volume < 9)
                Tick();
            timer = 0;
        }
	}

    public void Tick() {
        volume = Mathf.Clamp(volume + 1, 1, 9);
        SetGrassVolume(volume);
        randomNumber = Random.Range(1, 10);
    }

    public void UpdateGrass() {
        for(int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).localScale = new Vector3(volume / 9f, volume / 9f, volume / 9f);
        }

        //transform.localScale = new Vector3(volume / 9f, volume / 9f, volume / 9f);
        GetComponent<BoxCollider>().size = transform.localScale;
    }

    public void SetGrassVolume(int i) {
        volume = i;
        UpdateGrass();
    }
}
