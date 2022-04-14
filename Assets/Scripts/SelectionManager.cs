using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Camera camera;

    public TowerShop shop;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;


            if (hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero))
            {
                GameObject go = hit.collider.gameObject;

                if(go.GetComponent<Node>() != null && shop.towerSelected())
                {
                    Transform t = go.transform;
                    go.SetActive(false);

                    shop.createTower(t);
                    print("hit node");
                }
            }

        }
    }

}
