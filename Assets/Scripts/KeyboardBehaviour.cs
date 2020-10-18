using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardBehaviour : MonoBehaviour
{

    // Audio Source for Piano
    public AudioSource Speaker;
    public AudioRenderer Recorder;

    public AudioClip C_P;
    public AudioClip CS_P;
    public AudioClip D_P;
    public AudioClip DS_P;
    public AudioClip E_P;
    public AudioClip F_P;
    public AudioClip FS_P;
    public AudioClip G_P;
    public AudioClip GS_P;
    public AudioClip A_P;
    public AudioClip AS_P;
    public AudioClip B_P;
    public AudioClip C2_P;

    // Audio Soundclip synth
    public AudioClip C_S;
    public AudioClip CS_S;
    public AudioClip D_S;
    public AudioClip DS_S;
    public AudioClip E_S;
    public AudioClip F_S;
    public AudioClip FS_S;
    public AudioClip G_S;
    public AudioClip GS_S;
    public AudioClip A_S;
    public AudioClip AS_S;
    public AudioClip B_S;
    public AudioClip C2_S;

    // Audio soundclip drums
    public AudioClip Crash;
    public AudioClip HiHat;
    public AudioClip Kick;
    public AudioClip Ride;
    public AudioClip Snare;
    public AudioClip TomHigh;
    public AudioClip TomMid;
    public AudioClip TomLow;

    public LineRenderer RayPrefab;
    private LineRenderer Ray;
    private Vector3 hitPoint;
    private RaycastHit hit;
    private GameObject controller;
    private bool PlaySound;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
             // create raycast
            if (Ray == null) {  
                Ray = Instantiate(RayPrefab, this.transform.position, Quaternion.identity);
                }

            if (Ray != null) {
                Ray.transform.position = this.transform.position;
                Ray.transform.rotation = this.transform.rotation;
                if (Physics.Raycast(new Ray (Ray.transform.position, Ray.transform.rotation*Vector3.forward), out hit, 50)) {
                    hitPoint = hit.point;
                    PlaySound = true;

                    // identifies the instrument and the note to be played based on the collider information
                    if (hit.collider && hit.collider.transform.parent.tag == "Synth") {
                        if (hit.collider.gameObject.name == "C") {
                            PlayMusic(C_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "C#") {
                            PlayMusic(CS_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "D") {
                            PlayMusic(D_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "D#") {
                            PlayMusic(DS_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "E") {
                            PlayMusic(E_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "F") {
                            PlayMusic(F_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "F#") {
                            PlayMusic(FS_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "G") {
                            PlayMusic(G_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "G#") {
                            PlayMusic(GS_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "A") {
                            PlayMusic(A_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "A#") {
                            PlayMusic(AS_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "B") {
                            PlayMusic(B_S, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "C2") {
                            PlayMusic(C2_S, 1.5F);
                        } 
                    }

                     if (hit.collider && hit.collider.transform.parent.tag == "Piano") {
                        if (hit.collider.gameObject.name == "C") {
                            PlayMusic(C_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "C#") {
                            PlayMusic(CS_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "D") {
                            PlayMusic(D_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "D#") {
                            PlayMusic(DS_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "E") {
                            PlayMusic(E_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "F") {
                            PlayMusic(F_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "F#") {
                            PlayMusic(FS_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "G") {
                            PlayMusic(G_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "G#") {
                            PlayMusic(GS_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "A") {
                            PlayMusic(A_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "A#") {
                            PlayMusic(AS_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "B") {
                            PlayMusic(B_P, 1.5F);
                        }
                        else if(hit.collider.gameObject.name == "C2") {
                            PlayMusic(C2_P, 1.5F);
                        }
                    }

                     if (hit.collider && hit.collider.transform.parent.tag == "Drums") {
                        if (hit.collider.gameObject.name == "Snare") {
                            PlayDrums(Snare);
                        }
                        else if(hit.collider.gameObject.name == "Hi-hat") {
                            PlayDrums(HiHat);
                        }
                        else if(hit.collider.gameObject.name == "Crash") {
                            PlayDrums(Crash);
                        }
                        else if(hit.collider.gameObject.name == "TomHigh") {
                            PlayDrums(TomHigh);
                        }
                        else if(hit.collider.gameObject.name == "TomMid") {
                            PlayDrums(TomMid);
                        }
                        else if(hit.collider.gameObject.name == "Ride") {
                            PlayDrums(Ride);
                        }
                        else if(hit.collider.gameObject.name == "TomLow") {
                            PlayDrums(TomLow);
                        }
                        else if(hit.collider.gameObject.name == "Kick") {
                            PlayDrums(Kick);
                        }                        
                    }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            Destroy(Ray);
        }
    }

    public void PlayDrums(AudioClip clip) {
        if(!Speaker.isPlaying) {
            Speaker.PlayOneShot(clip);
        }
    }

    public void PlayMusic(AudioClip clip, float time) {
        if (PlaySound == true) {
            Speaker.PlayOneShot(clip);
        }
        
        if (!Speaker.isPlaying) {
            StartCoroutine(Wait(time));
        }
    }

    IEnumerator Wait(float time) {
        yield return new WaitForSeconds(time);
        PlaySound = true;
    }

}
