using UnityEngine;

public class PlayerPrefsLoader : MonoBehaviour
{/*
    public static PlayerPrefsLoader Instance;
    AudioSource audioSource;
    [Header("Player prefs")]
    public float volumeSFX;
    public string controlType;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o objeto vivo entre cenas
        }
        else
        {
            Destroy(gameObject);
        }

        // Inicializa o AudioSource no Awake
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();

        // Carrega os valores salvos
        LoadSavedSettings();
    }

    void LoadSavedSettings()
    {
        volumeSFX = PlayerPrefs.GetFloat("sfx volume");
        controlType = PlayerPrefs.GetString("control type");

        // Atualiza o volume do áudio ao iniciar
        audioSource.volume = volumeSFX;
    }

    public void SfxValue(float value)
    {
        // Atualiza o volume do áudio
        audioSource.volume = value;
        volumeSFX = value;

        // Salva o valor do volume
        PlayerPrefs.SetFloat("sfx volume", volumeSFX);
        PlayerPrefs.Save();
    }

    public void SaveControlType(string type)
    {
        // Salva o tipo de controle
        PlayerPrefs.SetString("control type", type);
        controlType = type;
        PlayerPrefs.Save();
    }
*/
}