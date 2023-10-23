using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] AudioClip openingDoorSFX, closingDoorSFX;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("Open");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayOpeningDoorSFX()
    {
        AudioSource.PlayClipAtPoint(openingDoorSFX, Camera.main.transform.position);
    }

    void PlayClosingDoorSFX()
    {
        AudioSource.PlayClipAtPoint(closingDoorSFX, Camera.main.transform.position);
    }
}
