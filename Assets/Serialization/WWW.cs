using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WWW : MonoBehaviour
{
    [ContextMenu("Execute")]
    public void Execute()
    {
        StartCoroutine(SendWebRequestCoroutine());
    }

    private IEnumerator SendWebRequestCoroutine()
    {
        UnityWebRequest www = new UnityWebRequest("https://prod.gameservices.forhumans.games/ab-test-manager/v2/experiments");
       //www = new UnityWebRequest($"https://prod.gameservices.forhumans.games/ab-test-manager/v2/schemas/BundleColorChanger/schema");
        www.downloadHandler = new DownloadHandlerBuffer();

        www.SetRequestHeader("X-For-Humans-Bundle-Id", "com.byaliens.gunfirestars");
        www.SetRequestHeader("X-For-Humans-Service-Account-Key", "");
        www.SetRequestHeader("X-Env", "prod");

        yield return www.SendWebRequest();
        Debug.Log("Request result: " + www.result);

        if(www.result == UnityWebRequest.Result.ProtocolError) Debug.Log("Request error: " + www.error);
    }
}
