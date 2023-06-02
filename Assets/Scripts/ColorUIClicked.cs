using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUIClicked : MonoBehaviour
{
    public Color selectedColor;
    public GameObject checkIUmagePrefab;
    public UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameObject checkIUmage = Instantiate(checkIUmagePrefab, transform);
        if(UIManager.UIPrefab != null)
            Destroy(UIManager.UIPrefab);
        UIManager.UIPrefab = checkIUmage;
        if (uIManager.manPanel)
        {
            uIManager.ChangeManColor(selectedColor);
        }
        else
        {
            uIManager.ChangeStageColor(selectedColor);
        }
    }
}
