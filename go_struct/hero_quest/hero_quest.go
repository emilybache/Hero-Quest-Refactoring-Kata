package hero_quest

import "fmt"

type QuestData struct {
	PlayerName          string
	PlayerHealth        int
	PlayerStrength      int
	PlayerMagic         int
	PlayerCraftingSkill int
	ItemName            string
	ItemKind            string
	ItemPower           int
}

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

func PlayerFallsDown(questData *QuestData) {
	fmt.Println("Player drops off a cliff.")

	if questData.PlayerStrength < 5 {
		questData.PlayerHealth -= 10
		fmt.Println("Player's strength is too small. Health decreases by 10.")
	}
}

func ItemToString(itemName string, itemKind string, itemPower int) string {
	return fmt.Sprintf("Item: %s\nKind: %s\nPower: %v\n", itemName, itemKind, itemPower)
}

func ItemReduceByUsage(questData *QuestData) {
	fmt.Printf("Using the item with kind '%s' and power %v\n", questData.ItemKind, questData.ItemPower)

	questData.ItemPower = questData.ItemPower / 2
	if questData.ItemPower == 0 {
		questData.ItemKind = "Junk"
	}
}

func ItemApplyEffectToPlayer(questData *QuestData) {
	fmt.Printf("Applying the effect of %s (%s):\n", questData.ItemName, questData.ItemKind)
	switch questData.ItemKind {
	case "Health":
		questData.PlayerHealth += questData.ItemPower
	case "Strength":
		questData.PlayerStrength += questData.ItemPower
	case "Magic":
		questData.PlayerMagic += questData.ItemPower
	}
}

func ItemRepair(questData *QuestData) {
	fmt.Println("Using the repair skill to fix the item:")

	repairAmount := -5 + ((questData.PlayerCraftingSkill * 2) + 1)

	questData.ItemPower += repairAmount

	fmt.Printf("Repaired the item by %v points. Item's Durability: %v\n", repairAmount, questData.ItemPower)
}
