using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebApiClient : MonoBehaviour
{
    private delegate void Callback(string result);
    private static RefreshToken refreshToken = null;

    [Serializable]
    private sealed class LoginData
    {
        public string id = "holoescape";
        public string password = "c3S2YhSn";
    }
    private sealed class RefreshToken
    {
        public string refreshToken;
        public static RefreshToken CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<RefreshToken>(jsonString);
        }
    }
    private sealed class AccsessToken
    {
        public string accessToken;
        public static AccsessToken CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<AccsessToken>(jsonString);
        }
    }

    private sealed class Action
    {
        public string action = "unlock";
    }
    private sealed class Enable
    {
        public bool enable = true;
    }


    public IEnumerator Login()
    {
        var data = new LoginData();
        var json = JsonUtility.ToJson(data);
        yield return StartCoroutine(PostRequest("http://192.168.20.5:8080/api/user/auth", json, (string str) => { refreshToken = JsonUtility.FromJson<RefreshToken>(str); }));
        EscapeMode(true);
    }
    private void GetAccsessToken(Callback ptr)
    {
        if (refreshToken == null)
        {
            Debug.Log("refreshToken Null");
            return;
        }
        var json = JsonUtility.ToJson(refreshToken);
        StartCoroutine(PostRequest("http://192.168.20.5:8080/api/token", json, (string str) => { 
            var accsessToken = JsonUtility.FromJson<AccsessToken>(str);
            //Debug.Log(accsessToken);
            //Debug.Log(str);
            ptr.Invoke(accsessToken.accessToken);
        }));
    }
    public void DoorLock()
    {
        var data = new Action();
        var json = JsonUtility.ToJson(data);
        GetAccsessToken((string str) => { StartCoroutine(PostRequestWithToken("http://192.168.20.5:8080/api/door", json, str)); });
        EscapeMode(false);

    }
    public void EscapeMode(bool flag)
    {
        var data = new Enable();
        data.enable = flag;
        var json = JsonUtility.ToJson(data);
        GetAccsessToken((string str) => { StartCoroutine(PostRequestWithToken("http://192.168.20.5:8080/api/escape", json, str)); });
    }

    private IEnumerator PostRequest(string url, string json, Callback ptr)
    {
        Debug.Log(json);
        var postData = Encoding.UTF8.GetBytes(json);

        using (var req = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST))
        {
            req.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
            req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();

            Debug.Log(req.result == UnityWebRequest.Result.ConnectionError);
            Debug.Log(req.result == UnityWebRequest.Result.ProtocolError);
            Debug.Log(req.result == UnityWebRequest.Result.Success);
            Debug.Log($"StatusCode: {req.responseCode}");
            Debug.Log(req.downloadHandler.text);
            Debug.Log(req.error);
            ptr.Invoke(req.downloadHandler.text);
        }

    }

    private IEnumerator PostRequestWithToken(string url, string json, string accsess)
    {
        Debug.Log(json);
        var postData = Encoding.UTF8.GetBytes(json);

        using (var req = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST))
        {
            req.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
            req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("Authorization", "Bearer "+ accsess);
            yield return req.SendWebRequest();

            Debug.Log("Bearer " + accsess);
            Debug.Log(req.result == UnityWebRequest.Result.ConnectionError);
            Debug.Log(req.result == UnityWebRequest.Result.ProtocolError);
            Debug.Log(req.result == UnityWebRequest.Result.Success);
            Debug.Log($"StatusCode: {req.responseCode}");
            Debug.Log(req.downloadHandler.text);
        }

    }

}

