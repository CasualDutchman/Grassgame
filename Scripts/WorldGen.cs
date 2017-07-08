using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

    public GameObject[] grassPrefab;
    public GameObject mower;

    public Vector2 grassAmount;

    List<Grass> allGrass;

    int timer = 0;
    float randomNumber = 0;

    void Start () {
        allGrass = new List<Grass>();

        for (int y = 0; y < grassAmount.y; y++) {
            for(int x = 0; x < grassAmount.x; x++) {

                GameObject obj = Instantiate(grassPrefab[Random.Range(0, grassPrefab.Length)], new Vector3( -1.55f + (x / 6f), 0, -3.5f + (y / 6f)), Quaternion.Euler(-90, 180 + Random.Range(-25, 25), 0), transform);
                obj.transform.localPosition += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                obj.name = x + " / " + y;

                allGrass.Add(obj.GetComponent<Grass>());
            }
        }
	}
	
	void Update () {
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Terrain"))) {
                if (hit.collider != null)
                    mower.transform.position = hit.point;
            }
        } else {
            mower.transform.position = new Vector3(0, 0, -7);
        }
    }

    void FixedUpdate() {
        timer++;
        if (timer >= 90 + randomNumber) {
            //UpdateGrass();
            timer = 0;
        }
    }

    void UpdateGrass() {
        Grass randomGrass = allGrass[Random.Range(0, allGrass.Count)];
        if(randomGrass.volume < 9) {
            randomGrass.volume = Mathf.Clamp(randomGrass.volume + 1, 1, 9);
            randomGrass.SetGrassVolume(randomGrass.volume);
            randomNumber = Random.Range(1, 10);
        }
    }
}
