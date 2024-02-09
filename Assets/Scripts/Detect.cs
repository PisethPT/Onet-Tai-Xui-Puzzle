using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Text level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("L1"))
            level.text = "LEVEL 1".ToString();
        else if (collision.gameObject.CompareTag("L2"))
            level.text = "LEVEL 2".ToString();
        else if (collision.gameObject.CompareTag("L3"))
            level.text = "LEVEL 3".ToString();
    }
}
