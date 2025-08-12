using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public enum FieldState { Seed, Harvest }
    public FieldState fieldState;

    [SerializeField] GameObject tilePrefab;
    [SerializeField] Vector2 fieldSize = new Vector2(6, 6);
    [SerializeField] float tileSize = 8f;

    public GameObject plantPrefab;

    [SerializeField] LayerMask fieldLayerMask;

    GameObject[,] tileArray;
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;

        tileArray = new GameObject[(int)fieldSize.x, (int)fieldSize.y];

        CreateFiedl();
    }
    private void Update()
    {
        if(GameManager.Instance.camState == CameraState.Field)
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

    void CreateFiedl()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2f;
        float offsetY = (fieldSize.y - 1) * tileSize / 2f;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for(int j = 0; j<fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float posZ = transform.position.z + j * tileSize - offsetX;

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
                    GameObject plant = Instantiate(plantPrefab, transform.GetChild(1));
                    plant.transform.position = hit.transform.position; //클릭한 곳에 생성

                    tileArray[tileX, tileY] = plant; //타일 위치에 플랜트 심기
                }

            }
        }
    }

    void OnHarvest()
    {

    }
}
