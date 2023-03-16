using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public static DoorKey instance;
    public GameObject ObjectToKey;
    
    public bool deactivateKey;
    public bool keyCollected;

    private void Awake()
    {
        instance = this;
    }
    
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
            if (deactivateKey)
            {
                ObjectToKey.SetActive(false);
            }
            else
            {
                ObjectToKey.SetActive(true);
            }
            Debug.Log("Anahtara dokundu");
            keyCollected = true;
        }

    }
}
