using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TextQueue : MonoBehaviour {
    public string Block;
    public Flowchart flowstate;

    void OnTriggerEnter2D(Collider2D other)
    {
        flowstate.ExecuteBlock(Block);
        //Trigger Block//
        Destroy(this.gameObject);
    }

}
