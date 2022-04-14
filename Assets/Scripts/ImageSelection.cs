using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine;

public class ImageSelection : MonoBehaviour
{
    private Color red;
    private Color original;
    private UnityEngine.UI.Image image;
    private bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        red = new Color(1, 0, 0);
        original = new Color(1,1,1);
        clicked = false;
    }

    
    public void Select()
    {
        if (clicked)
        {
            UnSelect();
        } 
        else
        {
            clicked = true;
            image.color = red;
        }
    }

    public void UnSelect()
    {
        if (clicked)
        {
            clicked = false;
            image.color = original;
        }
    }

    public bool WasClicked()
    {
        return clicked;
    }
}
