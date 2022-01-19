using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentManager : MonoBehaviour
{
    // Singleton pattern
    static public PersistentManager Instance { get; private set; }

    // Vehicle type
    public enum EVehicle { Car, Truck, Bike };
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

    // Start game scene
    public void StartScene(EVehicle vehicle)
    {
        Debug.Log("Load scene 1 vehicle " + vehicle);
        Vehicle = vehicle;
        SceneManager.LoadScene(1);
    }
}
