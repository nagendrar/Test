using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class SearchTest : MonoBehaviour
{
    public string[] Names;
    public GameObject Scrollview;
    public TMP_InputField IPF;

    bool IsDeselect = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (IsDeselect)
        {
            if (EventSystem.current.currentSelectedGameObject.name != "Button(Clone)" && EventSystem.current.currentSelectedGameObject.name != "Scrollbar Vertical")
            {
                IPF.text = "";
            }
        }
    }

    string sceneName;
    GameObject g;
    public void OnValueChange()
    {
        g = Scrollview.GetComponentInChildren<GridLayoutGroup>().gameObject;

        for (int i =0; i < g.transform.childCount; i++)
        {
            Destroy(g.transform.GetChild(i).transform.gameObject);
        }

        if(IPF.text.Length != 0)
        {
            foreach (var name in Names)
            {
                bool contains = name.Contains(IPF.text);

                if (contains)
                {
                    GameObject b = (GameObject)Resources.Load("Button");
                    GameObject button = Instantiate(b, transform.position, transform.rotation);
                    button.transform.SetParent(g.transform);
                    button.transform.GetChild(0).GetComponent<TMP_Text>().text = name;
                    button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(name));
                }
            }
        }       
    }

    public void OnButtonClick(string m)
    {
        //SceneManager.LoadScene(m);
        ProcessStartInfo p = new ProcessStartInfo(@"C:\Users\Satwik - Activa\Downloads\Module2\Module2\Module2.exe");
        p.WindowStyle = ProcessWindowStyle.Maximized;
        IPF.text = "";
        IsDeselect = false;
        
        Process.Start(@"C:\Users\Satwik - Activa\Downloads\Module2\Module2\Module2.exe");
        
    }

    public void OnSelect()
    {
        IsDeselect = false;
    }
    public void OnDeselect()
    {
        IsDeselect = true;
    }
}
