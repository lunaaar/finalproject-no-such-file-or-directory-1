using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class EndWayPoint : MonoBehaviour
{
    public Text healthText;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            int newHealth = int.Parse(healthText.text) - 1;

            Debug.Log(newHealth);

            healthText.text = newHealth.ToString();

            if (newHealth <= 0)
            {
                GameManager.instance().DefeatPanelOn();
                GameManager.instance().SpawnerOff();

                GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
                foreach(GameObject g in go)
                {
                    Destroy(g);
                }
            }
        }
    }
}
