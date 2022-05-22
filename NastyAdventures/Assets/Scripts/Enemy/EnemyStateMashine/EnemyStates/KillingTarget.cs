using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingTarget: State
{
    private void OnEnable()
    {
        Time.timeScale = 0;
        Debug.Log("You are dead!");

    }

}
