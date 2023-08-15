using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tansition : MonoBehaviour
{
    protected bool NeedTransit;

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
