using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    // Vehicle pool
    public GameObject Truck;
    public GameObject Car;
    public GameObject Bike;

    // Vehicle
    private GameObject vehicleGameObject;
    private Vehicle vehicle;

    // Start is called before the first frame update
    void Start()
    {
        // Identify the vehicle to use
        var vehicleType = PersistentManager.Instance == null ? PersistentManager.EVehicle.Truck : PersistentManager.Instance.Vehicle;
        Debug.Log("Start of scene 1 - vehicle " + vehicleType);
        switch (vehicleType)
        {
            case PersistentManager.EVehicle.Truck:
                vehicleGameObject = Truck;
                break;
            case PersistentManager.EVehicle.Car:
                vehicleGameObject = Car;
                break;
            case PersistentManager.EVehicle.Bike:
                vehicleGameObject = Bike;
                break;
        }

        // Get the script
        vehicle = vehicleGameObject.GetComponent<Vehicle>();

        // Move the vehicle to the beginning of the track, adjust the camera, start the race
        vehicle.Setup();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
