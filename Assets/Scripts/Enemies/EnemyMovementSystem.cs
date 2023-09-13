using System.Collections;
using UnityEngine;

public class EnemyMovementSystem : MonoBehaviour
{
    private Rect _attachedArea;
    private float _movementSpeed = 2;
    private PlayerController _player;
    private bool _isFlying;

    private Coroutine _followingCoroutine;
    private Coroutine _patrolingCoroutine;

    public void Init(Rect attachedArea, float movementSpeed, PlayerController player, bool isFlying)
    {
        _attachedArea = attachedArea;
        _movementSpeed = movementSpeed;
        _player = player;
        _isFlying = isFlying;
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
            var destination = GetRandomDestination();
            RotateToTarget(destination.x);

            while (Vector2.Distance(transform.position, destination) > destinationOffset)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * _movementSpeed);

                yield return null;
            }
        }
    }

    private Vector3 GetRandomDestination()
    {
        if (_isFlying)
            return new Vector3(Random.Range(_attachedArea.xMin, _attachedArea.xMax), Random.Range(_attachedArea.yMin, _attachedArea.yMax));
        else
            return new Vector3(Random.Range(_attachedArea.xMin, _attachedArea.xMax), transform.position.y);
    }

    private IEnumerator PlayerFollowing()
    {
        while (true)
        {
            RotateToTarget(_player.transform.position.x);
            Vector3 moveTarget = _isFlying? _player.transform.position : new Vector3(_player.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, moveTarget, Time.deltaTime * _movementSpeed);
           
            yield return null;
        }
    }

    public void SwitchFollowingState(bool state)
    {
        if (state)
            _followingCoroutine = StartCoroutine(PlayerFollowing());
        else
            StopCoroutine(_followingCoroutine);
    }

    public void SwitchPatrolingState(bool state)
    {
        if (state)
            _patrolingCoroutine = StartCoroutine(Patroling());
        else
            StopCoroutine(_patrolingCoroutine);
    }
}
