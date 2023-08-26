using System.Collections;
using UnityEngine;

public class EnemyMovementSystem : MonoBehaviour
{
    private Rect _attachedArea;
    private float _movementSpeed = 2;
    private PlayerController _player;

    public void Init(Rect attachedArea, float movementSpeed, PlayerController player)
    {
        _attachedArea = attachedArea;
        _movementSpeed = movementSpeed;
        _player = player;
    }

    private void RotateToTarget(float targetX)
    {
        Vector3 normalRotation = Vector3.zero;
        Vector3 flippedRotation = new Vector3(0, 180, 0);

        transform.eulerAngles = targetX > transform.position.x ? normalRotation : flippedRotation;
    }

    private IEnumerator Patroling()
    {
        var destinationOffset = 0.1f;

        while (true)
        {
            var destination = new Vector3(Random.Range(_attachedArea.xMin, _attachedArea.xMax), transform.position.y);
            RotateToTarget(destination.x);

            while (Vector2.Distance(transform.position, destination) > destinationOffset)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * _movementSpeed);

                yield return null;
            }
        }
    }

    private IEnumerator PlayerFollowing()
    {
        while (true)
        {
            RotateToTarget(_player.transform.position.x);
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector3(_player.transform.position.x, transform.position.y),
                Time.deltaTime * _movementSpeed);
           
            yield return null;
        }
    }
}
