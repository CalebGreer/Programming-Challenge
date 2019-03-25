using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationServicesController : MonoBehaviour
{
    public Text latitudeText;
    public Text longitudeText;

    void Start()
    {
        latitudeText.text = "";
        longitudeText.text = "";
        StartCoroutine(LocationServiceUpdate());
    }

    IEnumerator LocationServiceUpdate()
    {
        Input.location.Start();

        int waitTime = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && waitTime > 0)
        {
            yield return new WaitForSeconds(1);
            waitTime--;
        }

        if (waitTime <= 0)
        {
            latitudeText.text = "Timed out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            latitudeText.text = "Failed to determine device location";
            yield break;
        }
        else
        {
            latitudeText.text = Input.location.lastData.latitude.ToString();
            longitudeText.text = Input.location.lastData.longitude.ToString();
        }

        Input.location.Stop();
    }
}
