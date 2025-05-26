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

public bool CheckAllCarsInPlace()
{
    bool garbageInPlace = CheckCarPosition(garbageTruck, gTruckPos);
    bool schoolBusInPlace = CheckCarPosition(schoolBuss, sBussPos);
    bool medicInPlace = CheckCarPosition(medic, medicPos);
    bool shuttleInPlace = CheckCarPosition(shuttleBus, shuttleBusPos);
    bool bikeInPlace = CheckCarPosition(bike, bikePos);
    bool scooterInPlace = CheckCarPosition(scooter, scooterPos);
    bool lorryInPlace = CheckCarPosition(lorry, lorryPos);
    bool motorcycleInPlace = CheckCarPosition(motorcycle, motorcyclePos);
    bool policeInPlace = CheckCarPosition(policeCar, policeCarPos);
    bool mopedInPlace = CheckCarPosition(moped, mopedPos);
    bool sportCarInPlace = CheckCarPosition(sportCar, sportCarPos);
    bool vanInPlace = CheckCarPosition(van, vanPos);
    
    return garbageInPlace && schoolBusInPlace && medicInPlace &&
               shuttleInPlace && bikeInPlace && scooterInPlace &&
               lorryInPlace && motorcycleInPlace && policeInPlace &&
               mopedInPlace && sportCarInPlace && vanInPlace;
}

private bool CheckCarPosition(GameObject car, Vector2 correctPosition)
{
    RectTransform carTransform = car.GetComponent<RectTransform>();
    
    bool positionCorrect = Vector2.Distance(carTransform.anchoredPosition, correctPosition) < 10f;
    
    float rotation = carTransform.eulerAngles.z;
    bool rotationCorrect = (rotation <= 10f || rotation >= 350f);
    
    Vector3 scale = carTransform.localScale;
    bool scaleCorrect = Mathf.Abs(scale.x - 1f) < 0.1f && Mathf.Abs(scale.y - 1f) < 0.1f;
    
    return positionCorrect && rotationCorrect && scaleCorrect;
}

}
