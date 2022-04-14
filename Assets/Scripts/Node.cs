using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        sprite.color = new Color(1, 0, 0, 1);
        //print("hi");
    }

    private void OnMouseExit()
    {
        sprite.color = new Color(0.2235294f, 0.4039216f, 0.2392157f, 1);
    }

    
}
