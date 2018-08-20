using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !source.isPlaying) source.Play();
    }
}
