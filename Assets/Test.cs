using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;

public class Test : MonoBehaviour {
	// Use this for initialization
	
	void Start () {
		// Set your key
		TapsellDeveloper.getInstance ().setKey ("sqfoqcflrbfhpqtogfbfbhlajtkfdbdtpnmjnmkemibpcjrramrskgflpamntfaqckarpt");

		TapsellDeveloper.getInstance ().setPurchaseNotifier ((String sku, String purchaseId) => { 
			TapsellDeveloper.getInstance ().consumeProduct (sku, (Boolean consumed, Boolean connected) => {
				// Call after each purchase
			});
		});

		TapsellDeveloper.getInstance ().isProductPurchasedAndNotConsumed ("product1", (Boolean checkResponse, Boolean connected, String purchaseId) => {
			Debug.Log("isProductPurchasedAndNotConsumed: " + checkResponse + " " + connected + " " + purchaseId);
		});

		// Check ready Advertisement
		DeveloperCtaInterface.getInstance().checkCtaAvailability (DeveloperCtaInterface.VIDEO_PLAY, 0, true, (Boolean connected, Boolean isAvailable) => {
			Debug.Log("Tapsell: " + DeveloperCtaInterface.VIDEO_PLAY + " " + connected + " " + isAvailable);
		});

		DeveloperCtaInterface.getInstance().checkCtaAvailability (DeveloperCtaInterface.ALL_AD, 0, true, (Boolean connected, Boolean isAvailable) => {
			Debug.Log("Tapsell: " + DeveloperCtaInterface.ALL_AD + " " + connected + " " + isAvailable);
		});

		DeveloperCtaInterface.getInstance().checkCtaAvailability (DeveloperCtaInterface.PAY_PER_CHARGE, 0, true, (Boolean connected, Boolean isAvailable) => {
			Debug.Log("Tapsell: " + DeveloperCtaInterface.PAY_PER_CHARGE + " " + connected + " " + isAvailable);
		});

		DeveloperCtaInterface.getInstance().checkCtaAvailability (DeveloperCtaInterface.PAY_PER_INSTALL, 0, true, (Boolean connected, Boolean isAvailable) => {
			Debug.Log("Tapsell: " + DeveloperCtaInterface.PAY_PER_INSTALL + " " + connected + " " + isAvailable);
		});

		DeveloperCtaInterface.getInstance().checkCtaAvailability (DeveloperCtaInterface.WEB_VIEW, 0, true, (Boolean connected, Boolean isAvailable) => {
			Debug.Log("Tapsell: " + DeveloperCtaInterface.WEB_VIEW + " " + connected + " " + isAvailable);
		});

		
		// Get user information
		DeveloperCtaInterface.getInstance().getUserInfo ((int amount) => {
			Debug.Log("Tapsell: " + amount);
		});
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(50, 50, 100, 100), "Tapsell")){
			// Start Tapsell offerwall
			// TapsellDeveloper.getInstance().startTapsell();
			
			 // Show Tapsell Advertisement
			 DeveloperCtaInterface.getInstance().showNewCta (DeveloperCtaInterface.VIDEO_PLAY, -2, (Boolean connected, Boolean isAvailable, int award) => {
				Debug.Log("test " + connected + " " + isAvailable + " " + award);
			 });
		}
	}
}
