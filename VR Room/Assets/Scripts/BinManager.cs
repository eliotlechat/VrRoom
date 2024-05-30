using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinManager : MonoBehaviour
{

    AudioSource source;

    [SerializeField]
    AudioClip validationSound;

    [SerializeField]
    AnimationClip validationClip;

    [SerializeField]
    AudioClip ErrorSound;

    [SerializeField]
    AnimationClip ErrorClip;

    [SerializeField]
    Collider trigger; 
    

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        if (trigger == null)
        {
            Debug.LogError("Le trigger n'est pas assigné dans l'inspecteur.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.PlayOneShot(validationSound);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recyclable"))
        {
            // Affiche "OK" dans la console
            Debug.Log("OK");
        }
    }


}
