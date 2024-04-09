using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadModel : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public WheelRotate LR, LF, RF, RR;

    

    void Awake()
    {

        GameObject Manager = GameObject.Find("MenuManager");
        SelectKartCanvas select = Manager.GetComponent<SelectKartCanvas>();
        prefabToInstantiate = select.prefab;
        // Instantiate the prefab and set its parent to this GameObject
        GameObject instantiatedObject = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity, transform);
        instantiatedObject.name = "carro";
        GetChildren(instantiatedObject);
        // Optionally, you can reset the local position and rotation of the instantiated object
        instantiatedObject.transform.localPosition = Vector3.zero;
        instantiatedObject.transform.localRotation = Quaternion.identity;
        
    }

    void GetChildren(GameObject parent)
    {
        // Loop through each child of the parent object
        foreach (Transform child in parent.transform)
        {


            if (child.name == "RF") RF.rueda = child;
            else if (child.name == "LF") LF.rueda = child; 
            else if (child.name == "LR") LR.rueda = child; 
            else if (child.name == "RR") RR.rueda = child;

            // You can also access and manipulate the child object here if needed
            // For example, you can access its components:
            // Rigidbody rb = child.GetComponent<Rigidbody>();
            // Or you can disable the child object:
            // child.gameObject.SetActive(false);

            // If the child object has further children, call this function recursively
            if (child.childCount > 0)
            {
                GetChildren(child.gameObject);
            }
        }
    }

}
