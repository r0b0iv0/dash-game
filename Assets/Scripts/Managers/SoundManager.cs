using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private AudioSource audioSource;
    private AudioClip coinCollectSound;

    [SerializeField] private AudioClip RubyCollectsound;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip exlplodeUfoSound;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        
        // coinCollectSound = Resources.Load<AudioClip>("/Audio/Sounds/coincollect");

    }

    public void playCoinSound() {
        audioSource.PlayOneShot(RubyCollectsound);
    }

    public void playAttackSound() {
        audioSource.PlayOneShot(attackSound);
    }

    public void playExplodeSound() {
        audioSource.PlayOneShot(exlplodeUfoSound);
    }
}
