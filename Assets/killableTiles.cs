using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KillableTiles : MonoBehaviour
{
    public Tilemap killableTiles;

    // Start is called before the first frame update
    private void Start()
    {
        //killableTiles = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Collision detected");
            //Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
