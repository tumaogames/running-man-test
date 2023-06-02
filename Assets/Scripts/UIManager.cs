using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject manColorBody;
    public GameObject stageColorBody;
    public Text manColorButtonText;
    public Text stageColorButtonText;
    public static GameObject UIPrefab;
    public static Color manColor;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Material material;
    public bool manPanel;
    public Renderer cubeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeManColor(Color mColor)
    {
        // Get the materials from the SkinnedMeshRenderer
        Material[] materials = skinnedMeshRenderer.materials;

        // Change the color of each material
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = mColor;
        }

        // Assign the modified materials back to the SkinnedMeshRenderer
        skinnedMeshRenderer.materials = materials;
    }

    public void ChangeStageColor(Color mColor)
    {
        Material newMaterial = new Material(cubeRenderer.sharedMaterial);

        // Assign the new color to the material
        newMaterial.color = mColor;

        // Assign the modified material to the cube's Renderer component
        cubeRenderer.material = newMaterial;
    }

    public void ShowSetting()
    {
        settingPanel.gameObject.SetActive(true);
        ManColorClick();
        GameManager.manAnimate = true;
    }

    public void CloseSetting()
    {
        settingPanel.gameObject.SetActive(false);
        GameManager.manAnimate = false;
    }

    public void ManColorClick()
    {
        stageColorButtonText.color = new Color32(50, 50, 50, 255);
        manColorButtonText.color = new Color32(246, 6, 6, 255);
        manColorBody.gameObject.SetActive(true);
        stageColorBody.gameObject.SetActive(false);
        manPanel = true;
    }
    public void StageColorClick()
    {
        manColorButtonText.color = new Color32(50, 50, 50, 255);
        stageColorButtonText.color = new Color32(246, 6, 6, 255);
        manColorBody.gameObject.SetActive(false);
        stageColorBody.gameObject.SetActive(true);
        manPanel = false;
    }
}
