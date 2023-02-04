using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Vendor").tag = "Angry";
        GameObject.Find("Apple").SetActive(true);
    }

}
