﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform camera;

    void LateUpdate()
    {
        transform.position = camera.position;
    }
}
