﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseUnit
{
    [SerializeField] private float maxPower = 1000;

    private float _power;

    public GameObject laserShotPrefab;

    public float Power
    {
        get
        {
            return this._power;
        }
        protected set
        {
            this._power = value;

            if (this._power <= 0)
            {
                PlayerDeath();
            }
        }
    }

    public float PowerProprtional
    {
        get
        {
            return this.Power / this.maxPower;
        }
    }
	
	void Update ()
    {
        this.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        Debug.DrawRay(this.transform.position, this.transform.up * 100, Color.blue);
        Debug.DrawRay(this.transform.position, (CameraRig.GetWorldMousePosition() - (Vector2)this.transform.position), Color.red);

        float angle = -Vector3.SignedAngle(this.transform.up, (CameraRig.GetWorldMousePosition() - (Vector2)this.transform.position), Vector3.back);

        if (Mathf.Abs(angle) > 5)
        {
            this.Rotate(Mathf.Clamp(angle, -1, 1));
        }

        if (Input.GetMouseButton(0))
        {
            GameObject.Instantiate(this.laserShotPrefab, this.transform.position, this.transform.rotation);
        }
	}

    public override void DoDamage(float damageAmount)
    {
        this.Power -= damageAmount;
    }

    public void PlayerDeath()
    {
        Debug.Log("The player died.");

        Destroy(this.gameObject);
    }
}
