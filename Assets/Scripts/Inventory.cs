using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items;
    public float pickupRadius = 2.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag("Pickup"))
                {
                    items.Add(collider.gameObject);
                    collider.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
