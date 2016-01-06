using UnityEngine;
using System.Collections;
using System.Runtime;
using System;
using System.Collections.Generic;

public class TapsellWrapper : MonoBehaviour{
	Action<String, String> action;
	Dictionary<String, Action<Boolean, Boolean>> consumeProductAction = new Dictionary<String, Action<Boolean, Boolean>>();
	Dictionary<String, Action<Boolean, Boolean, String>> isProductPurchasedAndNotConsumedAction = new Dictionary<String, Action<Boolean, Boolean, String>>();

	public void setPurchaseNotifier(Action<String, String> action){
		this.action = action;
	}

	public void notifyPurchased(string str){
		String sku = str.Substring(0, str.LastIndexOf(" "));
		String purchasedIt = str.Substring (sku.Length + 1);
		action (sku, purchasedIt);
	}

	public void consumeProduct(String sku, Action<Boolean, Boolean> action){
		if (consumeProductAction.ContainsKey (sku))
			consumeProductAction.Remove (sku);
		consumeProductAction.Add(sku, action);
	}

	public void notifyConsumeProduct(String ans){
		Boolean first, second;
		first = setBoolState (ans [0]);
		second = setBoolState (ans [1]);
		String newSku = ans.Substring (2);
		if (consumeProductAction.ContainsKey(newSku)){
			consumeProductAction[newSku](first, second);
		}
	}

	public void notifyCtaAvailability(String str){
		DeveloperCtaInterface.getInstance().notifyCtaAvailability (str);
	}

	public void notifyDirectAd(String str){
		DeveloperCtaInterface.getInstance().notifyDirectAd(str);
	}

	public void notifyGetUserInfo(String getUserTapCoinAmount){
		DeveloperCtaInterface.getInstance ().notifyGetUserInfo (getUserTapCoinAmount);
	}

	public void isProductPurchasedAndNotConsumed(String sku, Action<Boolean, Boolean, String> action){
		if (isProductPurchasedAndNotConsumedAction.ContainsKey (sku))
			isProductPurchasedAndNotConsumedAction.Remove (sku);
		isProductPurchasedAndNotConsumedAction.Add(sku, action);
	}

	public void notifyIsProductPurchasedAndNotConsumed(String ans){
		Boolean first, second;
		if (ans.Length == 0) {
			return;
		}
		first = setBoolState (ans [0]);
		second = setBoolState (ans [1]);
		String newSku = ans.Substring(2, ans.LastIndexOf(" ") - 2);
		String purchaseId = ans.Substring (ans.LastIndexOf (" "), ans.Length - ans.LastIndexOf(" "));
		if (isProductPurchasedAndNotConsumedAction.ContainsKey(newSku)){
			isProductPurchasedAndNotConsumedAction[newSku](first, second, purchaseId);
		}
	}

	private Boolean setBoolState(Char chr){
		return (chr == 't');
	}
}
