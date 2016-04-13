using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;

public class Test : MonoBehaviour {
	// Use this for initialization
	
	void Start () {
		// Set your key
		TapsellDeveloper.getInstance ().setKey ("ekdcaoonjrofaqipsbnffdlnrdafefalbhcmastitqhbffkhdcoqahdilnqrabcsiahoon");
		TapsellDeveloper.getInstance ().setAppUserId ("mane-mane-kalle-gonde");
		TapsellDeveloper.getInstance ().setPurchaseNotifier ((String sku, String purchaseId) => { 
			TapsellDeveloper.getInstance ().consumeProduct (sku, (Boolean consumed, Boolean connected) => {
				Debug.Log("comsumeProduct: " + sku + " " + connected + " " + purchaseId);
			});
		});

		TapsellDeveloper.getInstance ().isProductPurchasedAndNotConsumed ("product_2", (Boolean checkResponse, Boolean connected, String purchaseId) => {
			Debug.Log("isProductPurchasedAndNotConsumed: " + checkResponse + " " + connected + " " + purchaseId);
		});

		// Check ready Advertisement
		// For Test Video: minimumAward = -2
		DeveloperCtaInterface.getInstance().checkCtaAvailability (DeveloperCtaInterface.VIDEO_PLAY, -2, true, (Boolean connected, Boolean isAvailable) => {
			Debug.Log("Tapsell: " + DeveloperCtaInterface.VIDEO_PLAY + " " + connected + " " + isAvailable);
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
			TapsellDeveloper.getInstance().startTapsell();

			 // Show Tapsell Advertisement
			// For Test Video: minimumAward = -2
			// DeveloperCtaInterface.getInstance().showNewCta (DeveloperCtaInterface.VIDEO_PLAY, -2, (Boolean connected, Boolean isAvailable, int award) => {
			//	Debug.Log("test " + connected + " " + isAvailable + " " + award);
			// });
		}
	}
}
