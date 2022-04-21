using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public TowerShop shop;
    public UpgradeMenu menu;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;


            if (hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero))
            {
                GameObject go = hit.collider.gameObject;

                if(go.GetComponent<Node>() != null && shop.TowerSelected())
                {
                    Transform t = go.transform;
                    go.SetActive(false);

                    shop.CreateTower(t);

                    shop.UnselectAll();
                }
                else if (go.CompareTag("Tower"))
                {
                    menu.SetTower(go);
                    menu.setText();
                    GameManager.instance().UpgradeMenuOn();
                }
            }
        }
    }
}
