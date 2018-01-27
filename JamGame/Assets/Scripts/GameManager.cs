using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas inGameMenu;
    public bool menuOpen = false;
    public float energy;
    public float maxEnergy = 100;
    public Slider currentEnergy;
    //public Panel Inventory;
    public string activeItem;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //inGameMenu.enabled = false;
        energy = 10;
    }

    void OnGUI()
    {
        currentEnergy.value = energy;
    }

    void Update()
    {

        /*if (Input.GetButtonDown("Cancel") && menuOpen == true)
        {
            inGameMenu.enabled = false;
            menuOpen = false;
        }
        else if (Input.GetButtonDown("Cancel") && menuOpen == false && SceneManager.GetActiveScene().buildIndex != 0)
        {
            inGameMenu.enabled = true;
            menuOpen = true;
        }*/



    }

}
