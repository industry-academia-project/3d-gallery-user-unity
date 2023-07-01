using UnityEngine;
using DG.Tweening;

namespace Move
{
    public class CameraMove : MonoBehaviour
    {
        public static int MOUSE_ID = 2;
        public float m_Speed;

        private void Update()
        {
            KeyboardMove();
            CursorMove();
        }

        private void KeyboardMove()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            float c = Input.GetAxisRaw("Altitude");
            Vector3 velocity = new Vector3(h, c, v);
            if (velocity != Vector3.zero)
            {
                DOTween.Kill(transform);
                velocity = ToEyeVector(velocity);
                velocity *= Time.deltaTime * m_Speed;
                transform.position += velocity;
            }
        }

        // 벡터를 보고있는 방향의 벡터로 변환
        private Vector3 ToEyeVector(Vector3 vec)
        {
            float yAngle = transform.rotation.eulerAngles.y;
            yAngle *= -Mathf.Deg2Rad;

            return new Vector3(
                vec.x * Mathf.Cos(yAngle) - vec.z * Mathf.Sin(yAngle),
                vec.y,
                vec.x * Mathf.Sin(yAngle) + vec.z * Mathf.Cos(yAngle)
            );
        }

        private Vector3 m_ClickStart;
        private Vector3 m_ClickStartAngle;

        private void CursorMove()
        {
            if (Input.GetMouseButtonDown(MOUSE_ID))
            {
                m_ClickStart = Input.mousePosition;
                m_ClickStartAngle = transform.rotation.eulerAngles;
            }
            else if (Input.GetMouseButton(MOUSE_ID))
            {
                Vector2 cur = Input.mousePosition;

                float x = m_ClickStartAngle.x + (m_ClickStart.y - cur.y) / 10;
                float y = m_ClickStartAngle.y - (m_ClickStart.x - cur.x) / 10;
                float z = m_ClickStartAngle.z;

                // clamp x angle
                x = Mathf.Clamp((x + 180) % 360, 90, 270) + 180;

                Quaternion rotate = Quaternion.Euler(x, y, z);
                transform.rotation = rotate;
            }
        }
    }
}