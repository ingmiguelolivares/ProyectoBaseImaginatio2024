using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newmodel : MonoBehaviour
{

    public string fbxFilePath; // Path to your .fbx file
    string folderPath = "/Users/MiguelOlivares/Documents/Modelos3D/car.fbx";

    void Awake()
    {
        var dir = folderPath + "/car.fbx";
        if (!string.IsNullOrEmpty(folderPath))
        {
            ImportAsset(folderPath);
        }
        else
        {
            Debug.LogError("FBX file path is not specified!");
        }
    }

    void ImportAsset(string path)
    {
        Mesh[] meshes = Resources.LoadAll<Mesh>(path);
        print("ok");
        foreach (Mesh m in meshes)
        {
            Debug.Log("meshname: " + m.name);
        }

        /*Object asset = Resources.Load(path); // Load the .fbx file as an asset
        if (asset != null)
        {
            Debug.Log("FBX file imported successfully: " + path);
        }
        else
        {
            Debug.LogError("Failed to import FBX file at path: " + path);
        }*/
    }

    void GetChildren(GameObject parent)
    {
        // Loop through each child of the parent object
        foreach (Transform child in parent.transform)
        {
            

            /*if (child.name == "RF") KartAnim.frontRightWheel.wheelTransform = child.transform;
            else if (child.name == "LF") KartAnim.frontRightWheel.wheelTransform = child.transform;
            else if (child.name == "LR") KartAnim.frontRightWheel.wheelTransform = child.transform;
            else if (child.name == "RR") KartAnim.frontRightWheel.wheelTransform = child.transform;
            */
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
