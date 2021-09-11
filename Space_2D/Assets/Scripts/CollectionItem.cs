using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ManagerClass.JumpSpeed++;
            ManagerClass.itemsCollected++;
            Destroy(gameObject);
        }
    }
}
