using UnityEngine;

public class EnemyDetectionSystem : MonoBehaviour
{
    private Rect _attachedArea;
    private PlayerController _player;

    public bool IsPlayerInArea { get; private set; }
    public bool IsPlayerDetected { get; private set; }

    private void Update()
    {
        IsPlayerInArea = CheckPlayerInArea();
        IsPlayerDetected = TryDetectPlayer();
    }

    public void Init(Rect patrolArea, PlayerController player)
    {
        _attachedArea = patrolArea;
        _player = player;
    }

    private bool TryDetectPlayer()
    {
        float boxAngle = 0;
        float areaReduceCoeff = 2;
        Vector2 boxSize = new Vector2(_attachedArea.width / areaReduceCoeff, _attachedArea.height);

        var hits = Physics2D.OverlapBoxAll(transform.position, boxSize, boxAngle);

        foreach (var hit in hits)
            if (hit.TryGetComponent(out PlayerController player))
                return true;

        return false;
    }

    private bool CheckPlayerInArea()
    {
        if (_player.transform.position.x > _attachedArea.xMax)
            return false;

        if (_player.transform.position.x < _attachedArea.xMin)
            return false;

        if (_player.transform.position.y > _attachedArea.yMax)
            return false;

        if (_player.transform.position.y < _attachedArea.yMin)
            return false;

        return true;
    }
}