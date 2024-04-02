using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimonDorado : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            UIManager.Instance.cambiarTextoObjetivos("Objetivo: Ve hacia la embarcación para avanzar a la siguiente fase");
        }
        GameManager.Instance.timonEquipado = true;
        Destroy(this.gameObject);
    }
}
