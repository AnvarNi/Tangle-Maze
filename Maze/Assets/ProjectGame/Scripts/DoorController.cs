using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorController : MonoBehaviour
{
    public float distance = 2f;
    List<Key> keyList;
    public TMP_Text attention;
    private float timeToHide;

    void Start()
    {
        keyList = new List<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.tag == "Door")
                {
                    Door door = hit.collider.GetComponent<Door>();
                    if (door.isLocked)
                    {
                        //for (int i = 0; i < keyList.Count; i++)
                        //{
                        //    if (keyList[i].id == door.id)
                        //    {
                        //        door.isLocked = false;
                        //        door.isOpen = !door.isOpen;
                        //        keyList.Remove(keyList[i]);
                        //    }
                        //    else
                        //    {
                        //        Debug.Log("Нет ключа");
                        //    }
                        //}
                        var inventory = GameObject.Find("Player").GetComponentInChildren<Inventory>();
                        foreach (var item in inventory.items)
                        {
                            if (item.id == door.id)
                            {
                                door.isLocked = false;
                                door.isOpen = !door.isOpen;
                                inventory.RemoveItem(door.id);
                                break;
                            }
                        }

                        if (door.isLocked)
                        {
                            attention.alpha = 1;
                            timeToHide = 0;
                        }
                    }
                    else
                    {
                        door.isOpen = !door.isOpen;
                    }
                }

                if (hit.collider.GetComponent<Key>())
                {
                    Key key = hit.collider.GetComponent<Key>();
                    keyList.Add(key);
                    Destroy(key.gameObject);
                }
            }
        }
        if (attention.alpha > 0)
        {
            timeToHide += Time.deltaTime;
            if (timeToHide >= 3)
                attention.alpha -= Time.deltaTime;
        }
        else
        {
            timeToHide = 0;
        }
    }
}
