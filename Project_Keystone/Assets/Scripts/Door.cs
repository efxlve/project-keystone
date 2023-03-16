using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject ObjectToDoor;
    private bool deavtivateDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
             if (DoorKey.instance.keyCollected)
             {
                ObjectToDoor.SetActive(false); //Anahtar varsa kapıyı açıyor
                DoorKey.instance.keyCollected = false; //kapıyı açtıktan sonra anahtarı sıfırlıyor
            }
             else
             {
                 ObjectToDoor.SetActive(true);
             }
            Debug.Log("Kapı dokundu");

        }

    }
}
