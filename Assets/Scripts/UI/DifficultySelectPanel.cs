
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelectPanel : MonoBehaviour
{
    public static DifficultySelectPanel Instance;

    public Transform _difficultyContent;
    public CanvasGroup _canvasGroup;
    
    public List<DifficultyData> difficultyDatas = new List<DifficultyData>();
    public TextAsset difficultyTextAsset;

    public GameObject difficulty_prefab;
    public Transform _difficultyList;
    public Image _difficultyAvatar;
    public TextMeshProUGUI _difficultyName;
    public TextMeshProUGUI _difficultyDescribe;

    private void Awake()
    {
        Instance = this;
        
        _difficultyContent = GameObject.Find("DifficultyContent").transform;
        _canvasGroup = GetComponent<CanvasGroup>();
        
        difficultyTextAsset =Resources.Load<TextAsset>("Data/difficulty");
        difficultyDatas = JsonConvert.DeserializeObject<List<DifficultyData>>(difficultyTextAsset.text);
        
        _difficultyList = GameObject.Find("DifficultyList").transform;
        difficulty_prefab = Resources.Load<GameObject>("prefabs/Difficulty");
        
        _difficultyAvatar = GameObject.Find("Avatar_Difficulty").GetComponent<Image>();
        _difficultyName = GameObject.Find("DifficultyName").GetComponent<TextMeshProUGUI>();
        _difficultyDescribe = GameObject.Find("DifficultyDescribe").GetComponent<TextMeshProUGUI>();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        foreach (DifficultyData difficultyData in difficultyDatas)
        {
            DifficultyUI d = Instantiate(difficulty_prefab,_difficultyList).GetComponent<DifficultyUI>();
            d.SetData(difficultyData);
        }
    }
    
}
