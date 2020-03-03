using System;
using System.Collections;
using System.Collections.Generic;
using DesktopPortal.Overlays;
using DPInterface.SteamVR;
using NAudio.Wave;
using UnityEngine;

public class CoolScript : MonoBehaviour {


    private DPApp dpApp;

    
    private void Awake() {
        dpApp = GetComponent<DPApp>();
        
        
        
        
    }


    private void Start() {
        dpApp.dpMain.lookedAtEvent += SayHelloFromTheOtherSide;
    }


    private void OnDestroy() {
        dpApp.dpMain.lookedAtEvent -= SayHelloFromTheOtherSide;
    }


    private void SayHelloFromTheOtherSide(bool lookedAt) {

        Debug.Log("hello from the other side");
        
    }

}
