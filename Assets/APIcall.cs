using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Net;

public class APIcall : MonoBehaviour
{
    public TextMeshProUGUI text;

   
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Fact
    {
        public string fact { get; set; }
        public int length { get; set; }
    }

    void Start()
    {
        // Call the Refresh function every 2 seconds
        InvokeRepeating("Refresh", 0f, 2f);
    }

    // Refresh the data
    public void Refresh()
    {
        StartCoroutine(GetRequest("https://catfact.ninja/fact"));
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //    StartCoroutine(GetRequest("https://catfact.ninja/fact"));
    //}

    //public void Refesh()
    //{
    //    Start();
    //}

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) 
        {
            yield return webRequest.SendWebRequest();
            Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
            text.text = fact.fact;
            //switch (webRequest.result) 
            //{
               
            //    case UnityWebRequest.Result.ConnectionError:
            //    case UnityWebRequest.Result.DataProcessingError:
            //        Debug.LogError(string.Format("Something went Wrong: {0}", webRequest.error));
            //        break;

            //    case UnityWebRequest.Result.Success:
            //        Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
            //        text.text = fact.fact;
            //        break;
            //}
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
