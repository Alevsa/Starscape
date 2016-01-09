using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionBounds : MonoBehaviour
{
    private Bounds m_Bounds;
    public Transform Player;
    private ShipCore m_PlayerCore;
    public GameObject OutOfBoundsWarning;
    private bool m_OutOfBounds;
    private Coroutine m_Countdown;
    public float TimeToDie = 5f;

    void Start()
    {
        m_PlayerCore = Player.GetComponent<ShipCore>();
        m_Bounds = gameObject.GetComponent<Collider>().bounds;
    }

    void Update()
    {
        if (Player != null)
        {
            if (!m_Bounds.Contains(Player.position))
            {
                if (!m_OutOfBounds)
                {
                    m_Countdown = StartCoroutine("OutOfBoundsCountdown");
                }
                m_OutOfBounds = true;
            }
            else
            {
                StopAllCoroutines();
                m_OutOfBounds = false;
            }
            SetWarningTextActivity(m_OutOfBounds);
        }

    }

    private void SetWarningTextActivity(bool x)
    {
        OutOfBoundsWarning.SetActive(x);
    }

    IEnumerator OutOfBoundsCountdown()
    {
        for (float i = 0f; i < TimeToDie; i += Time.deltaTime)
        {
            yield return null;
        }
        m_PlayerCore.Health -= m_PlayerCore.MaxHealth;
    }

}
