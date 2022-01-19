using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleButton : MonoBehaviour
{
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SetVehicle);
    }

    private void SetVehicle()
    {
        //Debug.Log("Click: name: " + gameObject.name);

        PersistentManager.EVehicle vehicle;

        if (gameObject.name.StartsWith("Car"))
        {
            vehicle = PersistentManager.EVehicle.Car;
        }
        else if (gameObject.name.StartsWith("Truck"))
        {
            vehicle = PersistentManager.EVehicle.Truck;
        }
        else
        {
            vehicle = PersistentManager.EVehicle.Bike;
        }

        //Debug.Log("Click: vehicle " + vehicle);

        PersistentManager.Instance.StartScene(vehicle);
    }
}
