using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript2 : MonoBehaviour
{
    public GameObject airplane;
    public GameObject boat;
    public GameObject bus;
    public GameObject cat;
    public GameObject firecar;
    public GameObject helicopter;
    public GameObject house;
    public GameObject skateboard;
    public GameObject sun;
    public GameObject taxi;
    public GameObject traficlight;
    public GameObject tree;


    [HideInInspector]
    public Vector2 airplanePlace;
    [HideInInspector]
    public Vector2 boatPlace;
    [HideInInspector]
    public Vector2 busPlace;
    [HideInInspector]
    public Vector2 catPlace;
    [HideInInspector]
    public Vector2 firecarPlace;
    [HideInInspector]
    public Vector2 helicopterPlace;
    [HideInInspector]
    public Vector2 housePlace;
    [HideInInspector]
    public Vector2 skateboardPlace;
    [HideInInspector]
    public Vector2 sunPlace;
    [HideInInspector]
    public Vector2 taxiPlace;
    [HideInInspector]
    public Vector2 traficlightPlace;
    [HideInInspector]
    public Vector2 treePlace;


    public AudioSource audioSource;
    public AudioClip[] audioClips;
    [HideInInspector]
    public bool rightPlace = false;
    public GameObject lastDragged = null;


    void Start()
    {
        airplanePlace = airplane.GetComponent<RectTransform>().localPosition;
        boatPlace = boat.GetComponent<RectTransform>().localPosition;
        busPlace = bus.GetComponent<RectTransform>().localPosition;
        catPlace = cat.GetComponent<RectTransform>().localPosition;
        firecarPlace = firecar.GetComponent<RectTransform>().localPosition;
        helicopterPlace = helicopter.GetComponent<RectTransform>().localPosition;
        housePlace = house.GetComponent<RectTransform>().localPosition;
        skateboardPlace = skateboard.GetComponent<RectTransform>().localPosition;
        sunPlace = sun.GetComponent<RectTransform>().localPosition;
        taxiPlace = taxi.GetComponent<RectTransform>().localPosition;
        traficlightPlace = traficlight.GetComponent<RectTransform>().localPosition;
        treePlace = tree.GetComponent<RectTransform>().localPosition;
    }

    public bool CheckAllCarsInPlace()
    {
        bool airplaneInPlace = CheckCarPosition(airplane, airplanePlace);
        bool boatInPlace = CheckCarPosition(boat, boatPlace);
        bool busInPlace = CheckCarPosition(bus, busPlace);
        bool catInPlace = CheckCarPosition(cat, catPlace);
        bool firecarInPlace = CheckCarPosition(firecar, firecarPlace);
        bool helicopterInPlace = CheckCarPosition(helicopter, helicopterPlace);
        bool houseInPlace = CheckCarPosition(house, housePlace);
        bool skateboardInPlace = CheckCarPosition(skateboard, skateboardPlace);
        bool sunInPlace = CheckCarPosition(sun, sunPlace);
        bool taxiInPlace = CheckCarPosition(taxi, taxiPlace);
        bool traficlightInPlace = CheckCarPosition(traficlight, traficlightPlace);
        bool treeInPlace = CheckCarPosition(tree, treePlace);

        return airplaneInPlace && boatInPlace && busInPlace &&
                   catInPlace && firecarInPlace && helicopterInPlace &&
                   houseInPlace && skateboardInPlace && sunInPlace &&
                   taxiInPlace && traficlightInPlace && treeInPlace;
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
