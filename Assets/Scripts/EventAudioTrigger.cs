using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EventAudioTrigger : MonoBehaviour
{
    [SerializeField]
    AudioSource as_VoiceLine;

    private bool b_hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (b_hasPlayed == false)
            {
                Debug.Log("HET WERKT: " + other.gameObject.name);
                b_hasPlayed = true;
                as_VoiceLine.Play();
            }
        }
    }
}
