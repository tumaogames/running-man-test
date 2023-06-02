using UnityEngine;
using UnityEngine.UI;

public class UIImage : MonoBehaviour
{
    public GameObject imagePrefab;
    public float moveDuration = 1f; // Duration of movement in seconds
    public float fadeDuration = 1f; // Duration of fade animation

    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void TriggerImageInstantiation(int point)
    {
        // Instantiate the UI image
        GameObject imageObj = Instantiate(imagePrefab, canvas.transform);
        // Access the Text component of the instantiated image
        Text textComponent = imageObj.GetComponentInChildren<Text>();

        // Modify the text
        textComponent.text = "Passing point " + (point - 1);
        // Set the initial position at the center of the screen
        RectTransform imageTransform = imageObj.GetComponent<RectTransform>();
        imageTransform.anchoredPosition = Vector2.zero;

        // Calculate the target position at 1/4 of the screen height
        float screenHeight = canvas.pixelRect.height;
        float targetY = screenHeight * 0.25f;
        Vector2 targetPosition = new Vector2(0, targetY);

        // Move the image using a coroutine
        StartCoroutine(MoveAndFade(imageTransform, targetPosition));
    }

    private System.Collections.IEnumerator MoveAndFade(RectTransform imageTransform, Vector2 targetPosition)
    {
        // Get the initial color and set it to fully opaque
        Image image = imageTransform.GetComponent<Image>();
        Color initialColor = image.color;
        initialColor.a = 1f;

        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            // Calculate the normalized time for movement
            float normalizedTime = elapsedTime / moveDuration;

            // Move the image towards the target position based on the normalized time
            imageTransform.anchoredPosition = Vector2.Lerp(Vector2.zero, targetPosition, normalizedTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the image reaches the exact target position
        imageTransform.anchoredPosition = targetPosition;

        // Fade out the image
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / fadeDuration;
            image.color = Color.Lerp(initialColor, Color.clear, normalizedTime);
            yield return null;
        }

        // Destroy the image object
        Destroy(imageTransform.gameObject);
    }
}
