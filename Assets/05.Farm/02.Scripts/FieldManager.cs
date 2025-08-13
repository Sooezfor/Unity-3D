using System.Collections;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public enum FieldState { None, Seed, Harvest }
    public FieldState fieldState;


    [SerializeField] GameObject tilePrefab;
    [SerializeField] Vector2 fieldSize = new Vector2(6, 6);
    [SerializeField] float tileSize = 3f;

    [SerializeField] int currPlantIndex;

    [SerializeField] private GameObject[] plants;
    [SerializeField] private GameObject[] crops;

    GameObject[,] tileArray;
    Camera mainCamera;

    [SerializeField] LayerMask fieldLayerMask;


    private void Awake()
    {
        mainCamera = Camera.main;
        tileArray = new GameObject[(int)fieldSize.x, (int)fieldSize.y];

        CreateField();
    }
    private void Update()
    {    
        if (fieldState != FieldState.None)
        {
            switch (fieldState)
            {
                case FieldState.Seed:
                    OnSeed();
                    break;
                case FieldState.Harvest:
                    OnHarvest();
                    break;
            }      
        }
    }

    void CreateField()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2f;
        float offsetY = (fieldSize.y - 1) * tileSize / 2f;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for(int j = 0; j<fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float posZ = transform.position.z + j * tileSize - offsetY;

                GameObject tileObj = Instantiate(tilePrefab, transform.GetChild(0));
                tileObj.name = $"Tile_{i}_{j}";
                tileObj.transform.position = new Vector3(posX, 0, posZ); //Y나 Z나 상관없 이름
                //tileArray[i, j] = tileObj;
                tileObj.GetComponent<Tile>().arrayPos = new Vector2Int(i, j);
            }
        }
    }
    void OnSeed()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f, fieldLayerMask)) //필드 레이어에서 맞은 애
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                if (tileArray[tileX, tileY] == null)
                {
                    GameObject plant = Instantiate(plants[currPlantIndex], transform.GetChild(1));
                    plant.transform.position = hit.transform.position; //클릭한 곳에 생성

                    plant.GetComponent<Plant>().plantIndex = currPlantIndex;
                    tileArray[tileX, tileY] = plant; //타일 위치에 플랜트 심기
                }

            }
        }
    }


    public void SetState(FieldState newState)
    {
        if (fieldState != newState)
            fieldState = newState;
    }

    public void SetPlant(int index)
    {       
        currPlantIndex = index;
    }

    IEnumerator HarvestRoutine(int index, Vector3 pos)
    {
        int ranAmount = Random.Range(1, 4); //1~3개의 작물 개수 설정

        for(int i = 0; i< ranAmount; i++)
        {
            GameObject crop = Instantiate(crops[index]);
            Rigidbody cropRb = crop.GetComponent<Rigidbody>();
            crop.transform.position = pos;

            float ranX = Random.Range(-2f, 2f);
            float ranZ = Random.Range(-2f, 2f);
            var forcedir = new Vector3(ranX, 5f, ranZ); //힘을 주는 벡터 

            cropRb.AddForce(forcedir, ForceMode.Impulse);

            yield return new WaitForSeconds(0.15f);                                                              
        }        
    }

    void OnHarvest() //수확은 타일을 기준으로
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, fieldLayerMask)) //필드 레이어에서 맞은 애
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                if (tileArray[tileX, tileY] != null) //식물이 있어야지만 수확 가능
                {
                    Plant plant = tileArray[tileX, tileY].GetComponent<Plant>();

                    if(plant.isHarvest) //수확 가능 상태인지 확인
                    {
                        plant.gameObject.SetActive(false);
                        tileArray[tileX, tileY] = null;

                        StartCoroutine(HarvestRoutine(plant.plantIndex, hit.transform.position));
                    }                   
                }

            }
        }
    }
}
