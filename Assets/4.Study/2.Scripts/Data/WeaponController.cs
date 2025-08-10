using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData[] weaponDatas; //에셋 데이터
    public GameObject[] weaponObjs; //무기 넣기 

    public string currWeaponName;
    public int currWeaponDmg;
    public int currWeaponRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(1);
        }
    }

    private void SwapWeapon(int index)
    {
        foreach (var weapon in weaponObjs)
            weapon.SetActive(false);

        weaponObjs[index].SetActive(true);

        currWeaponName = weaponDatas[index].weaponName;
        currWeaponDmg = weaponDatas[index].attackDamage;
        currWeaponRange = weaponDatas[index].attackRange;
    }
}
