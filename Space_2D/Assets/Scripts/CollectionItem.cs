using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : MonoBehaviour
{
    private GameObject player;
    private AudioSource[] sounds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ManagerClass.updateSpeed = true;
            ManagerClass.itemsCollected++;
            player = GameObject.FindWithTag("Player");
            sounds = player.GetComponents<AudioSource>();
            sounds[1].Play();
            Destroy(gameObject);
        }
    }
}
