package hero_quest

import "fmt"

var (
	PlayerName          = "Conan"
	PlayerHealth        = 100
	PlayerStrength      = 20
	PlayerMagic         = 10
	PlayerCraftingSkill = 10
)

func PlayerToString(playerName string, playerHealth int, playerStrength int, playerMagic int, playerCraftingSkill int) string {
	return fmt.Sprintf(
		"%s's Attributes:\nHealth: %v\nStrength: %v\nMagic: %v\nCrafting Skill: %v\n",
		playerName,
		playerHealth,
		playerStrength,
		playerMagic,
		playerCraftingSkill,
	)
}

func PlayerFallsDown(playerHealth *int, playerStrength *int) {
	fmt.Println("Player drops off a cliff.")

	if *playerStrength < 5 {
		*playerHealth -= 10
		fmt.Println("Player's strength is too small. Health decreases by 10.")
	}
}

var (
	AmuletItemName  = "Amulet of Strength"
	AmuletItemKind  = "Strength"
	AmuletItemPower = 10
)

func ItemToString(itemName string, itemKind string, itemPower int) string {
	return fmt.Sprintf("Item: %s\nKind: %s\nPower: %v\n", itemName, itemKind, itemPower)
}

func ItemReduceByUsage(itemKind *string, itemPower *int) {
	fmt.Printf("Using the item with kind '%s' and power %v\n", *itemKind, *itemPower)

	*itemPower /= 2
	if *itemPower == 0 {
		*itemKind = "Junk"
	}
}

func ItemApplyEffectToPlayer(itemName string, itemKind string, itemPower int, playerHealth *int, playerStrength *int, playerMagic *int) {
	fmt.Printf("Applying the effect of %s (%s):\n", itemName, itemKind)
	switch itemKind {
	case "Health":
		*playerHealth += itemPower
	case "Strength":
		*playerStrength += itemPower
	case "Magic":
		*playerMagic += itemPower
	}
}

func ItemRepair(itemPower *int, playerCraftingSkill int) {
	fmt.Println("Using the repair skill to fix the item:")

	repairAmount := -5 + ((playerCraftingSkill * 2) + 1)

	*itemPower += repairAmount

	fmt.Printf("Repaired the item by %v points. Item's Durability: %v\n", repairAmount, *itemPower)
}
