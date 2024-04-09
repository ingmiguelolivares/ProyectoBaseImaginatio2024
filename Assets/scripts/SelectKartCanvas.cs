using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

//desarollado por Miguel Olivares
public class SelectKartCanvas : MonoBehaviour
{
    public Canvas Inicio, Select;
    public TMP_Dropdown dropdown;
    public GameObject empty, prefab;


    string folderPath = Application.dataPath + "/Resources/models"; // Path to the folder you want to list

    void Start()
    {
        Inicio.enabled = false;
        if (!string.IsNullOrEmpty(folderPath))
        {
            ListFilesAndFoldersInDirectory(folderPath);
        }
        else
        {
            Debug.LogError("Folder path is not specified!");
        }
        DontDestroyOnLoad(this);
        print(folderPath);
    }

    void ListFilesAndFoldersInDirectory(string path)
    {
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        options.Add("seleccione el carro");
        // Check if the directory exists
        if (Directory.Exists(path))
        {
            // Get all files in the directory
            /*string[] files = Directory.GetFiles(path);
            Debug.Log("Files in " + path + ":");
            foreach (string file in files)
            {
                Debug.Log(file);
            }*/

            // Get all directories (folders) in the directory
            string[] directories = Directory.GetDirectories(path);
            Debug.Log("Directories in " + path + ":");
            foreach (string directory in directories)
            {
                string modifiedString = directory.Replace(path + "/", "");
                Debug.Log(modifiedString);
                options.Add(modifiedString);
            }
        }
        else
        {
            Debug.LogError("Directory does not exist: " + path);
        }
        dropdown.AddOptions(options);

    }
       
    

    public void ShowSelected() {
        EraseChildren(empty);
        string selectedOption = dropdown.options[dropdown.value].text;
        print(folderPath + "/" + selectedOption + "/" + selectedOption);
        prefab = Resources.Load<GameObject>("models/"+ selectedOption + "/" + selectedOption);
            
        if (prefab == null) print("error");
        else {
                GameObject instantiatedObject = Instantiate(prefab, empty.transform);

                instantiatedObject.name = "carro";
            }

         
        }


    void EraseChildren(GameObject parentObject)
    {
        // Loop through all child objects
        foreach (Transform child in parentObject.transform)
        {
            // Destroy the child object immediately
            DestroyImmediate(child.gameObject);
        }
    }

}

    

