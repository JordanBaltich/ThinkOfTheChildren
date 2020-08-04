using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerrainTexture : MonoBehaviour
{
    public Transform playerTransform;
    public Terrain t;

    public int posX;
    public int posZ;
    public float[] textureValues;

    private void Start()
    {    
        playerTransform = gameObject.transform;
        t = GameObject.Find("Terrain").GetComponent<Terrain>();
    }

    public void GetTerrainTexture()
    {
        ConvertPosition(playerTransform.position);
        CheckTexture();
    }

    void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - t.transform.position;

        Vector3 mapPosition = new Vector3
        (terrainPosition.x / t.terrainData.size.x, 0,
        terrainPosition.z / t.terrainData.size.z);

        float xCoord = mapPosition.x * t.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * t.terrainData.alphamapHeight;

        posX = (int)xCoord;
        posZ = (int)zCoord;
    }

    void CheckTexture()
    {
        float[,,] aMap = t.terrainData.GetAlphamaps(posX, posZ, 1, 1);

        textureValues[0] = aMap[0, 0, 0];
        textureValues[1] = aMap[0, 0, 1];
        textureValues[2] = aMap[0, 0, 2];
    }

    public bool CheckIfOnTerrain()
    {
        RaycastHit hit;

        Debug.DrawRay(playerTransform.position, Vector3.down, Color.red);
        if (Physics.Raycast(playerTransform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.GetComponent<Terrain>() != null)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    Terrain GetClosestCurrentTerrain(Vector3 playerPos)
    {
        //Get all terrain
        Terrain[] terrains = Terrain.activeTerrains;

        //Make sure that terrains length is ok
        if (terrains.Length == 0)
            return null;

        //If just one, return that one terrain
        if (terrains.Length == 1)
            return terrains[0];

        //Get the closest one to the player
        float lowDist = (terrains[0].GetPosition() - playerPos).sqrMagnitude;
        var terrainIndex = 0;

        for (int i = 1; i < terrains.Length; i++)
        {
            Terrain terrain = terrains[i];
            Vector3 terrainPos = terrain.GetPosition();

            //Find the distance and check if it is lower than the last one then store it
            var dist = (terrainPos - playerPos).sqrMagnitude;
            if (dist < lowDist)
            {
                lowDist = dist;
                terrainIndex = i;
            }
        }
        return terrains[terrainIndex];
    }
}
