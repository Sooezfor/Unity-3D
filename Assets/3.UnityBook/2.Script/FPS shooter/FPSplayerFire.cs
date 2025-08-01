using System.Collections;
using TMPro;
using UnityEngine;

public class FPSplayerFire : MonoBehaviour
{
    enum WeaponMode { Normal, Sniper }
    WeaponMode wMode;

    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;

    public GameObject weapon01;
    public GameObject weapon02;

    public GameObject crosshair01;
    public GameObject crosshair02; //줌 에임
    public GameObject crosshair02_zoom; //줌 화면

    public GameObject weapon01_R;
    public GameObject weapon02_R;

    private ParticleSystem ps;

    public TextMeshProUGUI wModeText;
    public GameObject[] eff_Flash;

    Animator anim;

    public float throwPower = 15f;
    public int weaponPower = 5;

    bool ZoomMode = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; //커서 안 보이기

        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

        wMode = WeaponMode.Normal;
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        #region 마우스 왼쪽 클릭


        if (Input.GetMouseButtonDown(0)) //마우스 왼쪽버튼 
        {
            if(anim.GetFloat("MoveMotion") == 0) //이동하지 않을 때만            
                anim.SetTrigger("Shoot");

            StartCoroutine(ShootEffectOn(0.05f));
            
            //카메라의 앞으로 나가는 레이저
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) //맞은 대상이 에네미 레이어인 경우
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else //맞은 대상이 enemy가 아닌 경우 
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal; //총알 이펙트의 앞 방향은 노멀벡터 방향으로 

                    ps.Play();                    
                }
            }
        }

        #endregion

        #region 마우스 오른쪽 클릭
        if (Input.GetMouseButtonDown(1)) //마우스 오른쪽
        {
            switch(wMode)
            {
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position; //위치만 설정

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce((Camera.main.transform.forward + Camera.main.transform.up * 0.5f) * throwPower, ForceMode.Impulse); //카메라가 바라보는 방향쪽으로 던지는 힘만큼)
                    break;
                case WeaponMode.Sniper:
                     ZoomMode = !ZoomMode; //현재의 반대. false면 true로 바꾸고.                  

                     float fov = ZoomMode ? 15f : 60f;
                     Camera.main.fieldOfView = fov;

                     crosshair02_zoom.SetActive(ZoomMode);
                     crosshair02.SetActive(!ZoomMode);
                     break;                    

                    //if(ZoomMode)
                    //{
                    //    crosshair02_zoom.SetActive(true);
                    //    crosshair02.SetActive(false);

                    //}
                    //else
                    //{
                    //    crsoohair02_zoom.SetActive(false);
                    //    crosshair02.SetActive(true);

                    //}

            }
        }
        #endregion 마우스 오른쪽 클릭

        #region 키보드 1번 클릭
        if (Input.GetKeyDown(KeyCode.Alpha1)) //키보드 위에 번호임
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;

            wModeText.text = "Normal Mode";

            weapon01.SetActive(true);
            weapon01_R.SetActive(true);
            weapon02.SetActive(false);
            weapon02_R.SetActive(false);
            crosshair01.SetActive(true);
            crosshair02.SetActive(false);
            crosshair02_zoom.SetActive(false);
        }
        #endregion

        #region 키보드 2번 클릭
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;

            wModeText.text = "Sniper Mode";

            weapon01.SetActive(false);
            weapon01_R.SetActive(false);
            weapon02.SetActive(true);
            weapon02_R.SetActive(true);
            crosshair01.SetActive(false);
            crosshair02.SetActive(true);
            //crosshair02_zoom.SetActive(false);
        }
        #endregion
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length);
        eff_Flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}
