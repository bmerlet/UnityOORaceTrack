using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentManager : MonoBehaviour
{
    // Singleton pattern
    static public PersistentManager Instance { get; private set; }

    // Vehicle type
    public enum EVehicle {  Car, Truck, Bike };
    public EVehicle Vehicle { get; private set; }

    // Construction
    private void Awake()
    {
        lock (this)
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // Set vehicle type from buttons
    public void SetVehicleCar()
    {
        StartScene(EVehicle.Car);
    }

    public void SetVehicleTruck()
    {
        StartScene(EVehicle.Truck);
    }

    public void SetVehicleBike()
    {
        StartScene(EVehicle.Bike);
    }

    private void StartScene(EVehicle vehicle)
    {
        Vehicle = EVehicle.Bike;
        SceneManager.LoadScene(1);
    }
}
