using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentCreator : MonoBehaviour
{
    
    public GameObject PianoPrefab;
    public GameObject SynthPrefab;
    public GameObject DrumsPrefab;
    private GameObject Piano;
    private GameObject Synth;
    private GameObject Drums;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P) && Piano == null && Synth == null && Drums == null) {
            Piano = Instantiate(PianoPrefab, this.transform.position, Quaternion.identity);
        }

        if(Input.GetKey(KeyCode.O) && Piano == null && Synth == null && Drums == null) {
            Synth = Instantiate(SynthPrefab, this.transform.position, Quaternion.identity);
        }

        if(Input.GetKey(KeyCode.I) && Piano == null && Synth == null && Drums == null) {
            Drums = Instantiate(DrumsPrefab, this.transform.position, Quaternion.identity);
        }

        if (Piano != null) {
            Piano.transform.position = gameObject.transform.position;
            if(Input.GetKey(KeyCode.C)) {
                Piano = null;
            }
        }

        if (Synth != null) {
            Synth.transform.position = gameObject.transform.position;
            if(Input.GetKey(KeyCode.C)) {
                Synth = null;
            }
        }

        if (Drums != null) {
            Drums.transform.position = gameObject.transform.position;
            if(Input.GetKey(KeyCode.C)) {
                Drums = null;
            }
        }


    }
}
