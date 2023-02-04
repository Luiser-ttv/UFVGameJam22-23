using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items;
    public float pickupRadius = 2.0f;
    public Vector2 itemDisplaySize = new Vector2(50, 50);
    public int itemsPerColumn = 5;
    private int currentColumn = 0;
    public GameObject colliderConverted;

    void OnGUI()
    {
        int itemsDrawn = 0;
        foreach (GameObject item in items)
        {
            Rect itemRect = new Rect(10 + currentColumn * itemDisplaySize.x, 10 + (itemsDrawn % itemsPerColumn) * itemDisplaySize.y, itemDisplaySize.x, itemDisplaySize.y);
            GUI.Box(itemRect, item.GetComponent<SpriteRenderer>().sprite.texture);
            itemsDrawn++;
            if (itemsDrawn % itemsPerColumn == 0)
            {
                currentColumn++;
            }
        }
        currentColumn = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(items.Count);
            Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag("Pickup"))
                {
                    items.Add(collider.gameObject);
                    collider.gameObject.SetActive(false);
                    break;
                }
                else if (collider.gameObject.CompareTag("Transformer") && items.Count != 0 && items.Count < 2)
                {
                    
                    items.Clear();
                    items.Add(colliderConverted.gameObject);
                    collider.gameObject.tag = "TransformDone";
                    break;
                }
                else if (collider.gameObject.CompareTag("Deleter") && items.Count != 0)
                {
                    items.Clear();
                    
                    break;
                }
            }
        }
    }
}
