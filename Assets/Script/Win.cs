using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject win;
    public GameObject Hp;
    private void OnTriggerEnter(Collider other)
    {
        win.SetActive(true);
        Hp.SetActive(false);
    }
}
