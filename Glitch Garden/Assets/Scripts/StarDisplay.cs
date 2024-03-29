using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int _stars = 100;

    Text _starText;

    void Start()
    {
        _starText = GetComponent<Text>();

        UpdateText();
    }

    public void AddStars(int amount)
    {
        _stars += amount;

        UpdateText();
    }
    public bool ExpenStars(int amount)
    {
        if (amount <= _stars)
        {
            _stars -= amount;

            UpdateText();

            return true;
        }

        return false;
    }

    private void UpdateText()
    {
        _starText.text = _stars.ToString();
    }
}
