using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSubject : MonoBehaviour
{
      public static event Action E_oven;

      public static void SetOvenDoor()
      {
            E_oven?.Invoke();
      }
}
