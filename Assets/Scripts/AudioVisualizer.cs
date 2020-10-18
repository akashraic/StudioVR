using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public GameObject SampleCubePrefab;
    GameObject[] SampleCubes = new GameObject[512];
    public float maxScale;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++) {
            GameObject Cube = (GameObject) Instantiate(SampleCubePrefab);
            Cube.transform.position = this.transform.position;
            Cube.transform.parent = this.transform;
            Cube.name = "Cube" + i;
            this.transform.eulerAngles = new Vector3 (0, -0.703125f * i, 0);
            Cube.transform.position = Vector3.forward * 100;
            SampleCubes[i] = Cube; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++) {
            if (SampleCubes != null) {
                SampleCubes[i].transform.localScale = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2 ,10);
            }
        }
    }
}
