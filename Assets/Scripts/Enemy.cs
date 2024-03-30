using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip hitSound;
    AudioSource audioSource;

    private void Awake() {
        audioSource = FindObjectOfType<AudioSource>();
    }
    public void TakeDamage(){
        audioSource.PlayOneShot(hitSound, 0.25f);
        Destroy(gameObject);
    }
}
