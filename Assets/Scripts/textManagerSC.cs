using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class textManagerSC : MonoBehaviour
{
    public struct ListContainer
    {
        public List<Data> dataList;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_dataList">Data list value</param>
        public ListContainer(List<Data> _dataList)
        {
            dataList = _dataList;
        }
    }


    public GameObject TaskField;
    private InputField TaskText;
    public GameObject Item;
    public GameObject Content;

    private static int TaskId;

    [SerializeField]
    public static List<Data> currentdata = new List<Data>();


    private static string path;
    void Start()
    {
        TaskText = TaskField.GetComponent<InputField>();
        path = Path.Combine(Application.persistentDataPath + "data.json");
        LoadSavedData(); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void LoadSavedData()
    {

        ReadDataFromFile();
        foreach(Data data in currentdata)
        {
            GameObject item = GameObject.Instantiate(Item);
            item.name = data.TaskId.ToString();
            item.transform.SetParent(Content.transform);
            item.transform.localScale = Vector3.one;
            item.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text = data.Text;
        }
    }
    public static void DeleteTaskFromList(int TaskId)
    {
        foreach(Data data in currentdata)
        {
            if(data.TaskId == TaskId)
            {
                currentdata.Remove(data);
                ListContainer container = new ListContainer(currentdata);
                string json = JsonUtility.ToJson(container);
                WriteDataToFile(json);
                break;
            }
        }
    }
    public void AddTaskToList()
    {
        if (!TaskText.text.Trim().Equals(""))
        {
            GameObject item = GameObject.Instantiate(Item);
            item.name = TaskId.ToString();
            item.transform.SetParent(Content.transform);
            item.transform.localScale = Vector3.one;
            item.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text = TaskText.text;
           
            currentdata.Add(new Data(TaskText.text,TaskId));
            ListContainer container = new ListContainer(currentdata);
            string json = JsonUtility.ToJson(container);
            WriteDataToFile(json);

            TaskId++;
            TaskText.text = "";         
        }
       
    }


    public static void ReadDataFromFile()
    {
        try
        {
            string loadedJsonDataString = File.ReadAllText(path);
            ListContainer container = JsonUtility.FromJson<ListContainer>(loadedJsonDataString);
            for (int i = 0; i < container.dataList.Count; i++)
            {
                currentdata.Add(new Data(container.dataList[i].Text, container.dataList[i].TaskId));                    
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }
    public static void WriteDataToFile(string jsonString)
    {
        File.WriteAllText(path, jsonString);
    }
}
