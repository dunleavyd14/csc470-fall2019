﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerScript : MonoBehaviour
{
    public GameManager GM;
    string KeyOptsString = "R: Rotate U: Upgrade";

    public Material UpgradedMat;

    public GameObject[] components;

    public int CoolingRate = 5;
    public int upgradeCost = 100; 
  
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnMouseOver()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {//rotate
            transform.rotation *= Quaternion.Euler(0, 45, 0);
        }

        if (Input.GetKeyDown(KeyCode.U) && GM.money >= upgradeCost)
        {//upgrade
            GM.money -= upgradeCost;
            CoolingRate *= 2;
            upgradeCost *= 2;
            foreach (GameObject comp in components)
            {
                comp.GetComponent<Renderer>().material = UpgradedMat;

            }
        }
    }

    private void OnMouseEnter () {
        GM.KeyOpts.text = KeyOptsString + " " + upgradeCost;
    }
    private void OnMouseExit()
    {
        GM.NormalizeKeyOpts();
    }





}
