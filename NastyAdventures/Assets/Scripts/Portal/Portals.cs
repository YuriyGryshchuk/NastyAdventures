using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public Transform target;
    private CharacterController controller;

    private void OnTriggerEnter(Collider other) 
    {
        controller = other.gameObject.GetComponent<CharacterController>();
        controller.enabled = false;
        other.gameObject.transform.position = target.position;
        controller.enabled = true;
    }

}
