﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatMovement : MonoBehaviour
{
    public float Speed;
    private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);
    }
}
