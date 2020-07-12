using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyManager em;
    Pathfinding pathfinding;

    public float moveSpeed;
    private bool pathfindingSet;

    List<PathNode> path;
    private int currentIndex;

    public float thresholdDistance;

    public float attackRange;

    private void Start()
    {
        path = new List<PathNode>();

        em = EnemyManager.instance;

        InvokeRepeating("UpdatePath", 2f, 0.25f);
    }

    bool isActive;
    public void Activate(bool val)
    {
        isActive = val;
    }

    private void Update()
    {
        if (!isActive) return;
        if (em.startDelay < Time.time)
        {
            if (!pathfindingSet)
            {
                pathfinding = GridGeneration.instance.pathfinding;
                pathfindingSet = true;
            }            
        }


    }

    private void FixedUpdate()
    {
        if (!isActive) return;
        Move();
    }

    void Move()
    {
        if (Time.time > 2.2f)
        {
            if (path.Count > 0)
            {
                if (currentIndex > path.Count - 1)
                {
                    print("This is not possible");
                }
                else
                {

                    //If melee run this
                    if (GetComponent<EnemyController>().enemyType == EnemyController.EnemyType.melee)
                    { 
                        if (Vector2.Distance(transform.position, new Vector2(path[currentIndex].x + 0.5f, path[currentIndex].y + 0.5f)) < thresholdDistance)
                        {
                            currentIndex++;
                        }
                        else
                        {
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(path[currentIndex].x + 0.5f, path[currentIndex].y + 0.5f), moveSpeed * Time.deltaTime);
                        }
                    }

                    //If ranged run this
                    else
                    {
                        if(Vector2.Distance(transform.position, new Vector2(em.playerX, em.playerY)) < attackRange)
                        {
                            //Shoot at the player
                            print("Should be shooting at the player");
                            transform.GetComponent<EnemyCombat>().RangedAttack();
                        }
                        else
                        {
                            if (Vector2.Distance(transform.position, new Vector2(path[currentIndex].x + 0.5f, path[currentIndex].y + 0.5f)) < thresholdDistance)
                            {
                                currentIndex++;
                            }
                            else
                            {
                                transform.position = Vector2.MoveTowards(transform.position, new Vector2(path[currentIndex].x + 0.5f, path[currentIndex].y + 0.5f), moveSpeed * Time.deltaTime);
                            }
                        }

                    }                    
                }                
            }

        }
    }
    

    void UpdatePath()
    {
        if (!isActive) return;
        int thisX = Mathf.RoundToInt(transform.position.x - 0.5f);
        int thisY = Mathf.RoundToInt(transform.position.y - 0.5f);

        currentIndex = 0;

        path.Clear();
        path = pathfinding.FindPath(thisX, thisY, em.playerX, em.playerY);

        if(path.Count > 0)
        {
            path.Remove(pathfinding.GetNode(thisX, thisY));
        }
    }

}
