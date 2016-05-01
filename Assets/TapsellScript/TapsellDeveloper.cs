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

	public void setAppUserInfo(AppUserInfo appUserInfo) {
		AndroidJavaClass jc = new AndroidJavaClass("ir.tapsell.tapselldevelopersdk.developer.models.AppUserInfo");
		jc.Call ("setPub0", appUserInfo.Pub0);
		jc.Call ("setPub1", appUserInfo.Pub1);
		jc.Call ("setPub2", appUserInfo.Pub2);
		jc.Call ("setPub3", appUserInfo.Pub3);
		jc.Call ("setPub4", appUserInfo.Pub4);
		jc.Call ("setPub5", appUserInfo.Pub5);
		jc.Call ("setPub6", appUserInfo.Pub6);
		jc.Call ("setPub7", appUserInfo.Pub7);
		jc.Call ("setPub8", appUserInfo.Pub8);
		jc.Call ("setPub9", appUserInfo.Pub9);
		tapsellDeveloperInfo.Call ("setAppUserInfo", appUserInfo.Pub0, appUserInfo.Pub1, appUserInfo.Pub2, appUserInfo.Pub3, appUserInfo.Pub4,
		                           appUserInfo.Pub5, appUserInfo.Pub6, appUserInfo.Pub7, appUserInfo.Pub8, appUserInfo.Pub9);
	}

	public void removeUserInfo() {
		tapsellDeveloperInfo.Call ("removeAppUserInfo");
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

	public void setAppUserId(String appUserId) {
		tapsellDeveloperInfo.Call ("setAppUserId", appUserId);
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
		tapsellDeveloperInfo.Call ("addHiddenSku", sku);
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
