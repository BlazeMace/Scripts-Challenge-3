﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime;

    void start ()
    {
        Destroy (gameObject);
    }
}
