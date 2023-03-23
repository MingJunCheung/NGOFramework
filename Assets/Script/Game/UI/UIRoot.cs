using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public Transform normal;
    public Transform tips;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }
}
