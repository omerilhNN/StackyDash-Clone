using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectDashes : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dashes")
        {
            collectSound.Play();
            ScoringSystem.score += 1;
            
            other.gameObject.AddComponent<CollectDashes>();
            Destroy(this);
        }

    }
}
