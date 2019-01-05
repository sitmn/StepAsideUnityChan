using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider Item)
    {
        if(Item.gameObject.tag == "CarTag" || Item.gameObject.tag == "TrafficConeTag" || Item.gameObject.tag == "CoinTag"){
            Destroy(Item.gameObject);
            Debug.Log("a");
        }
    }
}
