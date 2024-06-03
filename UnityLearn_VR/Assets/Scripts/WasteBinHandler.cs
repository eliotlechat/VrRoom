using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBinHandler : MonoBehaviour
{
    [SerializeField, TagFilter]
    string tagFilter;

    AudioSource source;

    [SerializeField]
    AudioClip validationSound;

    [SerializeField]
    AudioClip errorSound;

    Animator anim; 

    [SerializeField]
    GameObject animChild;

    ParticleSystem successParticle;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        successParticle = GetComponent<ParticleSystem>();

        if (animChild != null)
        {
            Debug.Log("animChild is assigned.");
            anim = animChild.GetComponent<Animator>();
            if (anim != null)
            {
                Debug.Log("Animator component found.");
            }
            else
            {
                Debug.LogError("Animator component is missing on animChild.");
            }
        }
        else
        {
            Debug.LogError("animChild is not assigned in the Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.CompareTag(tagFilter))
        {
            Debug.Log("Recycled");
            source.PlayOneShot(validationSound);
            anim.Play("SuccessIcon");
            successParticle.Play();
        }
        else
        {
            Debug.Log("The item is not recyclable!");
            source.PlayOneShot(errorSound);
        }
    }
}
