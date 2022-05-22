using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal: MonoBehaviour
{
    [SerializeField] private Portal target;

    [SerializeField] private float exitFromPortal = 2;

    private CharacterController controller;


    private void OnTriggerEnter(Collider other) 
    {
        EnterInPortal(other);
    }



    private void EnterInPortal(Collider other)
    {
        controller = other.gameObject.GetComponent<CharacterController>();
        controller.enabled = false;
        Vector3 targetPosition = new Vector3(target.transform.position.x + exitFromPortal, target.transform.position.y, target.transform.position.z);
        other.gameObject.transform.position = targetPosition;
        controller.enabled = true;
    }

}
