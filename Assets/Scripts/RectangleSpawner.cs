using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(Canvas))]
public class RectangleSpawner : MonoBehaviour
{
    [SerializeField]
    private RectTransform Prefab;
    [SerializeField]
    private MinMaxCurve SizeCurve = new MinMaxCurve(1, new AnimationCurve(), new AnimationCurve());

    private void Update()
    {
        if (Application.isFocused && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Vector2 currentMousePosition = Mouse.current.position.ReadValue();

            float widthMultiplier = SizeCurve.Evaluate(currentMousePosition.x / Screen.width, Random.value);
            float heightMultiplier = SizeCurve.Evaluate(currentMousePosition.y / Screen.height, Random.value);

            RectTransform instance = Instantiate(Prefab, currentMousePosition, Quaternion.identity, transform);
            instance.localScale = new Vector3(
                instance.localScale.x * widthMultiplier,
                instance.localScale.y * heightMultiplier,
                instance.localScale.z
            );
        }
    }
}
