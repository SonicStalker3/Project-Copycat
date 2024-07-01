using DefaultNamespace.InputHandlers;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class MenuUIManager : MonoBehaviour
{
public GameObject OptionsObj;
    public GameObject MenuObj;
    private EventSystem _eventSystem;
    public EventSystem EventSystem => _eventSystem;
    public GameObject[] OptionsList;

    [SerializeField]
    private GameObject MenuSelected;
    [SerializeField]
    private GameObject OptionsSelected;
    public GameObject CloseOptionBtn;

    public AudioMixer mixer; 
    //public AudioMixerGroup Music; 

    public bool ShoudOpen = false;

    private Button StartBtn;
    private Button SettingsBtn;
    private Button ExitBtn;
    
    
    private InputHandler _input;
    // Start is called before the first frame update
    
    [Inject]
    void Construct(InputHandler input)
    {
        _input = input;
    }
    
    private void Start()
    {
        _eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        if (!_eventSystem) Debug.Log("Null");
        var panel = OptionsObj.transform.GetChild(1);//GameObject.Find("OptionPanels");
        int children = panel.transform.childCount;
        OptionsList = new GameObject[children];
        for (int i = 0; i < children; ++i)
        {
            OptionsList[i] = panel.transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        gameObject.SetActive(ShoudOpen);
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        _eventSystem.SetSelectedGameObject(MenuSelected);
    }
    
    public void OnStartBtn()
    {
        ShoudOpen = false;
        gameObject.SetActive(ShoudOpen);
    }
    
    public void OnExitBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void OnOpenOptions() 
    {
        OptionsObj.SetActive(true);
        Debug.Log(_eventSystem.GetInstanceID());
        MenuSelected = _eventSystem.currentSelectedGameObject;
        OptionsSelected = !OptionsSelected ? _eventSystem.currentSelectedGameObject : CloseOptionBtn;
        _eventSystem.SetSelectedGameObject(OptionsSelected);
        MenuObj.SetActive(false);
    }
    
    public void OnCloseOptions() 
    {
        MenuObj.SetActive(true);
        Debug.Log(_eventSystem.GetInstanceID());
        _eventSystem.SetSelectedGameObject(MenuSelected);
        OptionsObj.SetActive(false);
    }

    public void OpenOption(int currentOption)
    {
        for (int i = 0; i < OptionsList.Length; ++i)
        {
            OptionsList[i].SetActive(i == currentOption);
        }
    }

    public void OnSensitivityChanged(float x)
    {
        _input.CursorSensitivity = x;
    }
    
    public void OnMusicChanged(float x)
    {
        mixer.SetFloat("MusicVolume", x-80);
    }
    public void OnGraphicsChanged(float x)
    {
        //InputSys.CursorSensitivity = x;
    }

}
