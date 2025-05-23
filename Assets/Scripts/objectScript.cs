using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public GameObject garbageTruck;
    public GameObject schoolBuss;
    public GameObject medic;

    public GameObject shuttleBus;
    public GameObject bike;
    public GameObject scooter;
    public GameObject lorry;
    public GameObject motorcycle;
    public GameObject policeCar;
    public GameObject moped;
    public GameObject sportCar;
    public GameObject van;


    [HideInInspector]
    public Vector2 gTruckPos;
    [HideInInspector]
    public Vector2 sBussPos;
    [HideInInspector]
    public Vector2 medicPos;

    [HideInInspector]
    public Vector2 shuttleBusPos;
    [HideInInspector]
    public Vector2 bikePos;
    [HideInInspector]
    public Vector2 scooterPos;
    [HideInInspector]
    public Vector2 lorryPos;
    [HideInInspector]
    public Vector2 motorcyclePos;
    [HideInInspector]
    public Vector2 policeCarPos;
    [HideInInspector]
    public Vector2 mopedPos;
    [HideInInspector]
    public Vector2 sportCarPos;
    [HideInInspector]
    public Vector2 vanPos;


    public AudioSource audioSource;
    public AudioClip[] audioClips;
    [HideInInspector]
    public bool rightPlace = false;
    public GameObject lastDragged = null;


    void Start()
    {
        gTruckPos = garbageTruck.GetComponent<RectTransform>().localPosition;
        sBussPos = schoolBuss.GetComponent<RectTransform>().localPosition;
        medicPos = medic.GetComponent<RectTransform>().localPosition;

        shuttleBusPos = shuttleBus.GetComponent<RectTransform>().localPosition;
        bikePos = bike.GetComponent<RectTransform>().localPosition;
        scooterPos = scooter.GetComponent<RectTransform>().localPosition;
        lorryPos = lorry.GetComponent<RectTransform>().localPosition;
        motorcyclePos = motorcycle.GetComponent<RectTransform>().localPosition;
        policeCarPos = policeCar.GetComponent<RectTransform>().localPosition;
        mopedPos = moped.GetComponent<RectTransform>().localPosition;
        sportCarPos = sportCar.GetComponent<RectTransform>().localPosition;
        vanPos = van.GetComponent<RectTransform>().localPosition;
    }
}
