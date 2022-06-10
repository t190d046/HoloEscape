using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPole : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    AudioSource audioSource;
    [SerializeField] AudioClip sound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (transform.childCount > 0) return;

        Debug.Log("Enter_" + collision.name);

        if (collision.gameObject.name == "ExitDoor_Key")
        {
            ExitDoorKeyCatcher key = collision.GetComponent<ExitDoorKeyCatcher>();
            if (!key.isCatch)
            {
                audioSource.PlayOneShot(sound);
                collision.transform.parent = transform;
                collision.transform.localPosition = new Vector3(0, 0, 0);
                gameManager.SetClearInMirror();
            }
        }
    }
}
