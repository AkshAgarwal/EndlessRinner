using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    #region Data Members
    //ObjectRefernece Script reference
    [SerializeField] private ObjectReference objectReference;
    private float obstacleOffset = 12f;
    //Integer data members.
    private const int MAX_NO_OF_OBSTACLES = 8;
    private const float TILE_LENGTH = 62.68f;
    private float obstacleHeight=0f;
    // Array that stores the left and right bounds of tiles to spawn obstacles.
    private readonly float[] _xRange = {-1.7f, 1.7f, 0f};

    //Singleton instance of class
    public static ObstacleSpawner obstacleSpawnerInstance;

    //Boolean for PlayerSpawned
    #endregion

    #region OnEnable Function
    private void OnEnable()
    {
        objectReference.ObstacleSpawner += Objectspawner; 
    }
    #endregion

    #region Obstacle spawner and binding of the obstacles
    private void Objectspawner()
    {
       
            for (var i = 1; i <= MAX_NO_OF_OBSTACLES; i++)
            {
                SpawnObstacle();
            }

        objectReference.ObstacleSpawner -= Objectspawner;
    }



    private void SpawnObstacle()
    {
        obstacleHeight = 0f;
        GameObject ObstacleToBeBOund = ObjectPooler.ObjectPoolerInstance.GetObstacles();
        if(ObstacleToBeBOund.name=="Crate4(Clone)")
        {
            obstacleHeight = 0.4f;
        }
        var position = transform.position;
        ObstacleToBeBOund.transform.position = new Vector3(_xRange[Random.Range(0, _xRange.Length)], obstacleHeight,
        Random.Range(position.z, position.z + TILE_LENGTH));
        if (ObstacleToBeBOund.transform.position.z <=obstacleOffset)
        {
            ObstacleToBeBOund.SetActive(false);
        }
        else
        {
            ObstacleToBeBOund.SetActive(true);
        }
    }
    #endregion
}
