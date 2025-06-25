using System.Collections;
using System.Collections.Generic;
using Model;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectPanel : MonoBehaviour
{
    public static WeaponSelectPanel Instance;
    public CanvasGroup _canvasGroup;
    public Transform _weaponContent;

    //武器数据信息
    public List<WeaponData> WeaponDatas = new List<WeaponData>(); //角色数据信息

    //json文件
    public TextAsset weaponTextAsset;

    //预制体
    public GameObject weapon_prefab;

    public Transform _weaponList;

    //武器图片
    public Image _weaponAvatar;

    //武器名称
    public TextMeshProUGUI _weaponName;

    //武器类型
    public TextMeshProUGUI _weaponType;

    //武器描述
    public TextMeshProUGUI _weaponDescribe;
    public GameObject _weaponDetails;

    private void Awake()
    {
        Instance = this;
        _canvasGroup = GetComponent<CanvasGroup>();
        _weaponContent = GameObject.Find("WeaponContent").transform;

        //读取json文件
        weaponTextAsset = Resources.Load<TextAsset>("Data/weapon");
        WeaponDatas = JsonConvert.DeserializeObject<List<WeaponData>>(weaponTextAsset.text);

        //预制体
        weapon_prefab = Resources.Load<GameObject>("prefabs/Weapon");

        //获取组件
        _weaponList = GameObject.Find("WeaponList").transform;
        _weaponAvatar = GameObject.Find("Avatar_Weapon").GetComponent<Image>();
        _weaponName = GameObject.Find("WeaponName").GetComponent<TextMeshProUGUI>();
        _weaponType = GameObject.Find("WeaponType").GetComponent<TextMeshProUGUI>();
        _weaponDescribe = GameObject.Find("WeaponDescribe").GetComponent<TextMeshProUGUI>();
        _weaponDetails = GameObject.Find("WeaponDetails");
    }


    void Start()
    {
        foreach (WeaponData weaponData in WeaponDatas)
        {
            WeaponUI w = GameObject.Instantiate(weapon_prefab, _weaponList).GetComponent<WeaponUI>();
            w.SetData(weaponData);
        }
    }
}