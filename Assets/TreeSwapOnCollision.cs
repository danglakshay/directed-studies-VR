using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeSwapOnCollision : MonoBehaviour
{
    
    
    public GameObject summerTreePrefab; // Reference to the summer tree prefab
    public GameObject fallTreePrefab; // Reference to the fall tree prefab
    public GameObject winterTreePrefab; // Reference to the winter tree prefab
    public GameObject springTreePrefab; // Reference to the spring tree prefab

    public GameObject currentTreeInstance; // Instance of the current tree in the scene
    
    
    // // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Summer Rune"))
        {
            SwapTree(summerTreePrefab);
        }
        else if(col.gameObject.CompareTag("Autumn Rune"))
        {
            SwapTree(fallTreePrefab);
        }
        else if(col.gameObject.CompareTag("Winter Rune"))
        {
            SwapTree(winterTreePrefab);
        }
        else if(col.gameObject.CompareTag("Spring Rune"))
        {
            SwapTree(springTreePrefab);
        }
        
        
    }

    

    private void SwapTree(GameObject newTreePrefab)
    {
        Debug.Log("Successfully entered into the swap method");
        if (currentTreeInstance != null && newTreePrefab != null)
        {
            Vector3 position = currentTreeInstance.transform.position;
            Quaternion rotation = currentTreeInstance.transform.rotation;

            Destroy(currentTreeInstance);

            currentTreeInstance = Instantiate(newTreePrefab, position, rotation);
        }
        else
        {
            if (currentTreeInstance == null)
            {
                Debug.Log(currentTreeInstance.gameObject.name);
            }
            else
            {


                Debug.LogError("Missing reference to tree objects");
            }
        }
            
    }
}
