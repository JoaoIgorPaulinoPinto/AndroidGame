using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class ConfigManager : MonoBehaviour
{
    [SerializeField] Toggle toggleDrag;
    [SerializeField] Toggle toggleSingle;
    [SerializeField] Toggle toggleDouble;

    [SerializeField] Slider SFXSlider;

    [SerializeField] TextMeshProUGUI textSFXcfg;

    string controltype;

    [SerializeField] AudioSource audioSource;
    


    private void Update()
    {
        
        UpdateSFXText();
       
    }
    private void Start()
    {
        LoadControlHUDValues();
        SFXSlider.value = PlayerPrefs.GetFloat("sfx volume");
        audioSource.volume = PlayerPrefs.GetFloat("sfx volume");
    }

    public void SaveValues() {

        PlayerPrefs.SetFloat("sfx volume", SFXSlider.value);
        SelectControlType();
        PlayerPrefs.Save();
        audioSource.volume = PlayerPrefs.GetFloat("sfx volume");
    }

    void SelectControlType()
    {
        switch (controltype)
        {
            case "SingleControlType":
                PlayerPrefs.SetString("control type", "SingleControlType");
                toggleSingle.isOn = true; 
                break;
            case "DragControlType":
                PlayerPrefs.SetString("control type", "DragControlType");
                toggleDrag.isOn = true;
                break;
            case "DoubleControlType":
                PlayerPrefs.SetString("control type", "DoubleControlType");
                toggleDouble.isOn = true; 
                break;
            default:
                // Se não houver nenhum tipo salvo, assume-se o controle de arrastar
                PlayerPrefs.SetString("control type", "DoubleControlType");
                toggleDouble.isOn = true;   
                break;
        }
    }

    public void ToggleDragType()
    {
        controltype ="DragControlType";
    }

    public  void ToggleSingleType()
    {
        controltype = "SingleControlType";
    }
    public void ToggleDoubleType()
    {
        controltype = "DoubleControlType";
    }

    void UpdateSFXText()
    {
        float txtVolume = SFXSlider.value * 100;
        textSFXcfg.text = " " + txtVolume.ToString("00") + "%";

        
    }

    void LoadControlHUDValues()
    {
        string controltype = PlayerPrefs.GetString("control type");
        switch (controltype)
        {
            case "SingleControlType":
                toggleSingle.isOn = true;
                break;
            case "DragControlType":
                toggleDrag.isOn = true;
                break;
            case "DoubleControlType": 
                toggleDouble.isOn = true;
                break;
            default:
                toggleDouble.isOn = true;
                break;
        }
    }
}
