using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSubject : MonoBehaviour
{
    public static event Action E_TestEvent;

    public void Notify()
    {
        E_TestEvent?.Invoke();   
    }
}
