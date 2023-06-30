using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip soundToPlay;

    void PlaySound()
    {
        SoundManager.Instance.PlayClip(soundToPlay);
    }
}
