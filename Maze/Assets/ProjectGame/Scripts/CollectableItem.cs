using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private GameObject player;
    public float distance = 2f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!item) return;
        var inventory = other.GetComponent<Inventory>();
        if (inventory)
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.GetComponent<CollectableItem>())
                {
                    var itemToAdd = hit.collider.GetComponent<CollectableItem>().item;
                    var inventory = player.GetComponent<Inventory>();
                    if (inventory)
                    {
                        inventory.AddItem(item);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
