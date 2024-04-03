using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimonColision : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject timonModeloBarco;
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
        if (GameManager.Instance.timonEquipado && timeline.state != PlayState.Playing)
        {
            timonModeloBarco.gameObject.SetActive(true);
            UIManager.Instance.cambiarTextoObjetivos("");
            timeline.Play();
        }
    }
}
