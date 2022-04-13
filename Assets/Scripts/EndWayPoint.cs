using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndWayPoint : MonoBehaviour
{

    public Text healthText;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TEST1");
        if (collision.tag == "Enemy")
        {
            Debug.Log("TEST2");
            healthText.text = (int.Parse(healthText.text) - 1).ToString();
        }
    }
}
