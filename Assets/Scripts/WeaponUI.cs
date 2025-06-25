using DefaultNamespace;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public WeaponData weaponData ;

    //背景图片
    public Image _backImage;

    //角色头像
    public Image _avatar;

    //按钮
    public Button _button;

    private void Awake()
    {
        _backImage = GetComponent<Image>();
        _button = GetComponent<Button>();
        _avatar = transform.GetChild(0).GetComponent<Image>();
    }

    //注入数据
    public void SetData(WeaponData w)
    {

        
        weaponData = w;

        _avatar.sprite = Resources.Load<Sprite>(weaponData.avatar);
        
        //点击事件
        _button.onClick.AddListener(() => { ButtonClicked(weaponData); });
    }

    //鼠标移入
    public void OnPointerEnter(PointerEventData eventData)
    {
        _backImage.color = new Color(207 / 255f, 207 / 255f, 207 / 255f);
        RenewUI(weaponData);
    }

    private void RenewUI(WeaponData w)
    {
        //修改头像
        WeaponSelectPanel.Instance._weaponAvatar.sprite = Resources.Load<Sprite>(w.avatar);

        //修改名称
        WeaponSelectPanel.Instance._weaponName.text = w.name;

        //修改武器类型
        WeaponSelectPanel.Instance._weaponType.text = w.isLong == 0 ? "近战" : "远程";

        //武器描述
        WeaponSelectPanel.Instance._weaponDescribe.text = w.weapon_describe;
    }

    //鼠标移出
    public void OnPointerExit(PointerEventData eventData)
    {
        _backImage.color = new Color(34 / 255f, 34 / 255f, 34 / 255f);
    }

    //按钮点击
    private void ButtonClicked(WeaponData w)
    {
        //记录当前武器
        GameManager.Instance.currentWeapons.Add(w);
        
        //克隆UI
        GameObject weapon_clone = Instantiate(WeaponSelectPanel.Instance._weaponDetails,DifficultySelectPanel.Instance._difficultyContent);
        weapon_clone.transform.SetSiblingIndex(0);
        GameObject role_clone = Instantiate(RoleSelectPanel.Instance._roleDetails,DifficultySelectPanel.Instance._difficultyContent);
        role_clone.transform.SetSiblingIndex(0);
        
        //关闭当前面板
        WeaponSelectPanel.Instance._canvasGroup.alpha = 0;
        WeaponSelectPanel.Instance._canvasGroup.interactable = false;
        WeaponSelectPanel.Instance._canvasGroup.blocksRaycasts = false;
        
        //打开下一个面板
        DifficultySelectPanel.Instance._canvasGroup.alpha = 1;
        DifficultySelectPanel.Instance._canvasGroup.interactable = true;
        DifficultySelectPanel.Instance._canvasGroup.blocksRaycasts = true;
    }
}