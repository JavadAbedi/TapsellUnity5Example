using UnityEngine;
using System.Collections;
using System;

public class TapsellDeveloper {
	private TapsellObject tapsellObject;
	private static TapsellDeveloper instance;
	private AndroidJavaObject tapsellDeveloperInfo;

	public static TapsellDeveloper getInstance(){
		if (instance == null) {
			instance = new TapsellDeveloper ();
		}
		return instance;
	}

	public TapsellDeveloper(){
		tapsellObject = new TapsellObject ();
		AndroidJavaClass jc = new AndroidJavaClass("ir.tapsell.tapselldevelopersdk.developer.TapsellDeveloperInfo");
		tapsellDeveloperInfo = jc.CallStatic<AndroidJavaObject>("getInstance");
	}

	public void setPurchaseNotifier(Action<String, String> action){
		tapsellObject.wrapper.setPurchaseNotifier (action);
	}

	public void consumeProduct(String sku, Action<Boolean, Boolean> action){
		tapsellDeveloperInfo.Call ("consumeProduct", sku);
		tapsellObject.wrapper.consumeProduct (sku, action);
	}

	public void isProductPurchasedAndNotConsumed(String sku, Action<Boolean, Boolean, String> action){
		tapsellDeveloperInfo.Call ("isProductPurchasedAndNotConsumed", sku);
		tapsellObject.wrapper.isProductPurchasedAndNotConsumed (sku, action);
	}
	
	public void setKey(string key){
		tapsellDeveloperInfo.Call("setDeveloperKey", key);
	}

	public void startTapsell(){
		tapsellDeveloperInfo.CallStatic("startActivity");
	}

	public void addHiddenSku(String sku){
		tapsellDeveloperInfo.Call ("addHiddenSkua", sku);
	}

	public void removeHiddenSku(String sku){
		tapsellDeveloperInfo.Call ("removeHiddenSku", sku);
	}

	public void isHiddenSku(String sku){
		tapsellDeveloperInfo.Call ("isHiddenSku", sku);
	}

	public void setCurrentProduct(String sku){
		tapsellDeveloperInfo.Call ("setCurrentProduct", sku);
	}

	public void removeCurrentProduct(){
		tapsellDeveloperInfo.Call ("removeCurrentProduct");
	}
}
