using System.Collections;
using System.Collections.Generic;
using DesktopPortal.Overlays;
using DPInterface.SteamVR;
using NAudio.Wave;
using UnityEngine;
using UnityEngine.UI;

public class MyTestApp : DPApp {


	//Only use [SerializeField] on built in types.
	//If you need a more specific reference, add a sfield for the gameobject, and on Awake(), GetComponent the script you want.
	
	[SerializeField] private GameObject spawnablePF;

	[SerializeField] private Button thatButtonGO;
	
	
	//There's a bunch of overridable functions DPApp provides. Use them to do certain things when your app is used!


	protected override void Awake() {
		base.Awake();
		thatButtonGO.onClick.AddListener(ThatButton_Clicked);
	}


	//Only called once
	public override void Init() {
		base.Init();
		
		
	}

	
	public override void Opening() {
		base.Opening();
	}
	
	//Called anytime your app hides
	public override void Minimizing() {
		base.Minimizing();
	}

	//Called when your app is being closed. Minimized is also called when this happens
	public override void Quitting() {
		base.Quitting();

	}



	public override void TheBarOpening() {
		base.TheBarOpening();
	}

	public override void TheBarClosing() {
		base.TheBarClosing();
	}



	
	public void ThatButton_Clicked() {
		SpawnRandomDP();
		YouCanUseExternalAssemblies();
	}

	//External assemblies can be used just like a normal C# project. Just put them in your mod folder in Unity and you're good to go!
	//Example of using NAudio to get the capabilities of the first output device it finds.
	private void YouCanUseExternalAssemblies() {

		var capabilities = WaveOut.GetCapabilities(0);
		Debug.Log( "From mod: " + capabilities.ProductName + " " + capabilities.NameGuid);
		
	}



	private void SpawnRandomDP() {
		
		//If we want to get a reference to a DP we're spawning on the fly, we disable "AutoPreinitialize" on it in the inspector.
		//Then, we can GetComponent it and pre-initialize it ourselves when we're good and ready.
		DPOverlayBase dp = Instantiate(spawnablePF, transform).GetComponentInChildren<DPOverlayBase>();
		dp.PreInitialize();
			
		//Put it in front of the HMD.
		Vector3 goodPos = SteamVRManager.I.hmdTrans.position + SteamVRManager.I.hmdTrans.forward * 0.4f;
		dp.SetOverlayTransform(goodPos, SteamVRManager.I.hmdTrans.eulerAngles, true, true, false);
		
		
	}
	
	
	
}
