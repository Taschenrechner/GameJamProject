using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public Canvas inGameMenu;
    //public bool menuOpen = false;
    public float energy;
    public float maxEnergy = 100;
    public Slider currentEnergy;
    //public Panel Inventory;
    public Text showInventory;
    public int activeItem = 0;
    public int nextItem;
    public bool pushObject;
    public List<GameObject> inventory = new List<GameObject>();
    public GameObject currentItem;
    /*private string[] arrayofItems;
    private string stringOfItems;*/
    public GameObject pref;
    public GameObject parenpan;
    public bool robotmoveable;
    public bool wrenchable;
    public bool gearable;
    public GameObject wrenchableobject;
    public bool liftable;
    public GameObject liftableObject;


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
        energy = 100;
        activeItem = 0;
        inventory[activeItem].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(45, 45);
        robotmoveable = true;
    }

    void OnGUI()
    {
        inventory[activeItem].gameObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(50, 50);
        currentEnergy.value = energy;
        /*if (inventory.Count == 0)
        {
            showInventory.text = "Inventory Empty";
        }
        else
        {
            arrayofItems = inventory.ToArray();
            stringOfItems = string.Join("\n", arrayofItems);
            showInventory.text = stringOfItems;
        }*/

        


    }

    void CycleItems(int x)
    {
        inventory[activeItem].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(30, 30);
        nextItem = (activeItem +x) % inventory.Count;
        activeItem = nextItem;
        inventory[activeItem].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(50, 50);
    }

    void Update()
    {
        if (Input.GetButtonDown("c"))
        {
            CycleItems(1);
        }

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

    public bool Addtoinv(GameObject additem)
    {
        if (inventory.Count <= 3)
        {
            inventory.Add(additem);
            Image prefIm = additem.GetComponent<Image>();
            prefIm.rectTransform.sizeDelta = new Vector2(30, 30);
            //Instantiate(prefIm, parenpan.transform);
            prefIm.transform.parent = parenpan.transform;
            return true;
        }
        else
        {
            Debug.Log("Inventory Full");
            return false;
        }
    }

    public void Deletefrominv(GameObject delitem)
    {
        Image[] allImages = parenpan.GetComponentsInChildren<Image>();
        foreach(Image img in allImages)
        {
            if (img.gameObject.name == delitem.name)
            {
                Destroy(img.gameObject);
                activeItem = 0;
            }
        }
        inventory.Remove(delitem);

        OnGUI();
    }

}
