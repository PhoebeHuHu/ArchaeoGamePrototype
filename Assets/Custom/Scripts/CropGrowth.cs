using UnityEngine;
using AC;

public class CropGrowth : MonoBehaviour
{
    private enum GrowthState
    {
        Seedling,
        Sapling,
        Mature,
        Flower,
    }

    private GrowthState currentGrowthState = GrowthState.Seedling;

    public int seedlingGrowthTime = 3;
    public int saplingGrowthTime = 4;
    public int matureGrowthTime = 5;
    public int flowerGrowthTime = 6;

    public Sprite saplingSprite;
    public Sprite matureSprite;
    public Sprite flowerSprite;
    public Sprite harvestSprite;

    private SpriteRenderer spriteRenderer;

    public GVar growTime;

    void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the growTime variable of the crop   
        growTime = GetComponent<Variables>().GetVariable(0);

    }

    public void Grow()
    {
        if (growTime.IntegerValue != flowerGrowthTime)
        {
            growTime.IntegerValue++;
        }

        switch (currentGrowthState)
        {
            case GrowthState.Seedling:
                if (growTime.IntegerValue == seedlingGrowthTime)
                {
                    currentGrowthState = GrowthState.Sapling;
                    spriteRenderer.sprite = saplingSprite;
                }   
                break;

            case GrowthState.Sapling:
                if (growTime.IntegerValue == saplingGrowthTime)
                {
                    currentGrowthState = GrowthState.Mature;
                    spriteRenderer.sprite = matureSprite;
                }
                break;

            case GrowthState.Mature:
                if (growTime.IntegerValue == matureGrowthTime)
                {
                    currentGrowthState = GrowthState.Flower;
                    spriteRenderer.sprite = flowerSprite;
                }
                break;

            case GrowthState.Flower:
                if (growTime.IntegerValue == flowerGrowthTime)
                {
                    spriteRenderer.sprite = harvestSprite;
                }
                break;


            default:
                Debug.LogError("Unknown growth stage!");
                break;
        }
    }

    public void Setup()
    {
        if (growTime.IntegerValue >= seedlingGrowthTime)
        {
            currentGrowthState = GrowthState.Sapling;
            spriteRenderer.sprite = saplingSprite;
        }

        if (growTime.IntegerValue >= saplingGrowthTime)
        {
            currentGrowthState = GrowthState.Mature;
            spriteRenderer.sprite = matureSprite;
        }

        if (growTime.IntegerValue >= matureGrowthTime)
        {
            currentGrowthState = GrowthState.Flower;
            spriteRenderer.sprite = flowerSprite;
        }

        if (growTime.IntegerValue >= flowerGrowthTime)
        {
            spriteRenderer.sprite = harvestSprite;
        }
    }
}