using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityGenerator : MonoBehaviour
{
    public GameObject layoutRoom;
    public Color highwayColor,townHallColor, churchColor, milBaseColor;

    public int distanceToTownHall;
    public int densityCount, densityMax;
    public bool includeChurch, includeMilBase;
    public int minDistanceToChurch, maxDistanceToChurch, minDistanceToMilBase, maxDistanceToMilBase;

    public Transform generationPoint,corePoint;
    private Vector3 corePosition;

    public bool makeOutline;

    public enum Direction { up, right, down, left};
    public Direction selectedDirection;

    public float xOffset = 10f, yOffset = 10;

    public LayerMask whatIsRoom;

    private GameObject townHall, churchBlock, milBaseBlock;

    private List<GameObject> layoutCityObjects = new List<GameObject>();

    public RoomPrefabs blocks;

    private List<GameObject> generatedOutlines = new List<GameObject>();

    public RoomCenter centerHighway, centerTownHall, centerChurch, centerMilBase;
    public RoomCenter[] potentialCenters;


    void Start()
    {
        Instantiate(layoutRoom, generationPoint.position, generationPoint.rotation).GetComponent<SpriteRenderer>().color = highwayColor;

        selectedDirection = (Direction)Random.Range(0, 4);
        MoveGenerationPoint();

        //Possible to insert room check here

        for(int i = 0; i < distanceToTownHall; i++)
        {
            GameObject newRoom = Instantiate(layoutRoom, generationPoint.position, generationPoint.rotation);

            layoutCityObjects.Add(newRoom);

            if(i + 1 == distanceToTownHall)
            {
                newRoom.GetComponent<SpriteRenderer>().color = townHallColor;
                layoutCityObjects.RemoveAt(layoutCityObjects.Count -1);

                townHall = newRoom;
            }

            //Spawn Point Movement

            selectedDirection = (Direction)Random.Range(0, 4);
            MoveGenerationPoint();

            //Spot Check

            while(Physics2D.OverlapCircle(generationPoint.position, .2f, whatIsRoom))
            {
              MoveGenerationPoint();

              densityCount = densityCount +1;
              
            }

            densityCount = densityCount + 1;

            if(densityCount >= densityMax)
            {
                //generationPoint.position = corePoint.position;
                densityCount = 0;
            }
        }

        if(includeChurch)
        {
            int shopSelector = Random.Range(minDistanceToChurch, maxDistanceToChurch + 1);
            churchBlock = layoutCityObjects[shopSelector];
            layoutCityObjects.RemoveAt(shopSelector);
            churchBlock.GetComponent<SpriteRenderer>().color = churchColor;
        }

        if(includeMilBase)
        {
            int altarSelector = Random.Range(minDistanceToMilBase, maxDistanceToMilBase + 1);
            milBaseBlock = layoutCityObjects[altarSelector];
            layoutCityObjects.RemoveAt(altarSelector);
            milBaseBlock.GetComponent<SpriteRenderer>().color = milBaseColor;
        }

        //Create room outlines
        if(makeOutline)
        {
            CreateCityOutline(Vector3.zero);
            foreach(GameObject room in layoutCityObjects)
            {
                CreateCityOutline(room.transform.position);
            }
            CreateCityOutline(townHall.transform.position);
            if(includeChurch)
            {
                CreateCityOutline(churchBlock.transform.position);
            }
            if(includeMilBase)
            {
                CreateCityOutline(milBaseBlock.transform.position);
            }
        }

        //Leave center lanes clear and generate roads via outlines. I am smart.

        foreach(GameObject outline in generatedOutlines)
        {
            bool generateCenter = true;

            if(outline.transform.position == Vector3.zero)
            {
                Instantiate(centerHighway, outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();

                generateCenter = false;
            }

            if(outline.transform.position == townHall.transform.position)
            {
                Instantiate(centerTownHall, outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();

                generateCenter = false;
            }

            if(includeChurch)
            {
                if(outline.transform.position == churchBlock.transform.position)
                {
                    Instantiate(centerChurch, outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();

                    generateCenter = false;
                }
            }

            if(includeMilBase)
            {
                if(outline.transform.position == milBaseBlock.transform.position)
                {
                    Instantiate(centerMilBase, outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();

                    generateCenter = false;
                }
            }

            if(generateCenter)
            {
                int centerSelect = Random.Range(0, potentialCenters.Length);

                Instantiate(potentialCenters[centerSelect], outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();
            }
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void MoveGenerationPoint()
    {
        switch(selectedDirection)
        {
            case Direction.up:
                generationPoint.position += new Vector3(0f, yOffset, 0f);
                break;

            case Direction.down:
                generationPoint.position += new Vector3(0f, -yOffset, 0f);
                break;

            case Direction.right:
                generationPoint.position += new Vector3(xOffset, 0f, 0f);
                break;

            case Direction.left:
                generationPoint.position += new Vector3(-xOffset, 0f, 0f);
                break;
        }
    }

    public void CreateCityOutline(Vector3 blockPosition)
    {
            bool roomAbove = Physics2D.OverlapCircle(blockPosition + new Vector3(0f, yOffset, 0f), .2f, whatIsRoom);
            bool roomBelow = Physics2D.OverlapCircle(blockPosition + new Vector3(0f, -yOffset, 0f), .2f, whatIsRoom);
            bool roomLeft = Physics2D.OverlapCircle(blockPosition + new Vector3(-xOffset, 0f, 0f), .2f, whatIsRoom);
            bool roomRight = Physics2D.OverlapCircle(blockPosition + new Vector3(xOffset, 0f, 0f), .2f, whatIsRoom);
            
            int directionCount = 0;
            if(roomAbove)
            {
                directionCount++;
            }
            if(roomBelow)
            {
                directionCount++;
            }
            if(roomLeft)
            {
                directionCount++;
            }
            if(roomRight)
            {
                directionCount++;
            }

            switch(directionCount)
            {
                case 0:
                    //Debug.LogError("found noom exists!");
                    //break;

                case 1:

                if(roomAbove)
                {
                    generatedOutlines.Add(Instantiate(blocks.singleUp, blockPosition, transform.rotation));
                }

                if(roomBelow)
                {
                    generatedOutlines.Add(Instantiate(blocks.singleDown, blockPosition, transform.rotation));
                }

                if(roomLeft)
                {
                    generatedOutlines.Add(Instantiate(blocks.singleLeft, blockPosition, transform.rotation));
                }

                if(roomRight)
                {
                    generatedOutlines.Add(Instantiate(blocks.singleRight, blockPosition, transform.rotation));
                }

                    break;

                case 2:

                if(roomAbove && roomBelow)
                {
                    generatedOutlines.Add(Instantiate(blocks.doubleUpDown, blockPosition, transform.rotation));
                }

                if(roomLeft && roomRight)
                {
                    generatedOutlines.Add(Instantiate(blocks.doubleLeftRight, blockPosition, transform.rotation));
                }

                if(roomAbove && roomRight)
                {
                    generatedOutlines.Add(Instantiate(blocks.doubleUpRight, blockPosition, transform.rotation));
                }

                if(roomRight && roomBelow)
                {
                    generatedOutlines.Add(Instantiate(blocks.doubleRightDown, blockPosition, transform.rotation));
                }

                if(roomLeft && roomBelow)
                {
                    generatedOutlines.Add(Instantiate(blocks.doubleLeftDown, blockPosition, transform.rotation));
                }

                if(roomLeft && roomAbove)
                {
                    generatedOutlines.Add(Instantiate(blocks.doubleLeftUp, blockPosition, transform.rotation));
                }

                break;

                case 3:

                if(roomAbove && roomBelow && roomRight)
                {
                    generatedOutlines.Add(Instantiate(blocks.tripleUpRightDown, blockPosition, transform.rotation));
                }

                if(roomLeft && roomBelow && roomRight)
                {
                    generatedOutlines.Add(Instantiate(blocks.tripleRightDownLeft, blockPosition, transform.rotation));
                }

                if(roomAbove && roomBelow && roomLeft)
                {
                    generatedOutlines.Add(Instantiate(blocks.tripleDownLeftUp, blockPosition, transform.rotation));
                }

                if(roomLeft && roomAbove && roomRight)
                {
                    generatedOutlines.Add(Instantiate(blocks.tripleLeftUpRight, blockPosition, transform.rotation));
                }

                    break;

                case 4:

                if(roomAbove && roomBelow && roomRight && roomLeft)
                {
                    generatedOutlines.Add(Instantiate(blocks.fourway, blockPosition, transform.rotation));
                }

                    break;
                    
            }
    }
}

[System.Serializable]
public class CityPrefabs
{
    public GameObject singleUp, singleDown, singleRight, singleLeft,
        doubleLeftDown, doubleUpDown, doubleLeftRight, doubleUpRight, doubleRightDown, doubleLeftUp,
        tripleUpRightDown, tripleRightDownLeft, tripleDownLeftUp, tripleLeftUpRight,
        fourway;
}
