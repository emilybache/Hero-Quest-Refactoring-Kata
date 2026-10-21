package hero_quest

import "fmt"

var Output []string

type QuestData struct {
	PlayerName          string
	PlayerHealth        int
	PlayerStrength      int
	PlayerMagic         int
	PlayerCraftingSkill int
	ItemName            string
	ItemKind            string
	ItemPower           int
	EnemyName           string
	EnemyPower          int
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
	Output = append(Output, "Player drops off a cliff.\n")

	if questData.PlayerStrength < 5 {
		questData.PlayerHealth -= 10
		Output = append(Output, "Player's strength is too small. Health decreases by 10.\n")
	}
}

func ItemToString(itemName string, itemKind string, itemPower int) string {
	return fmt.Sprintf("Item: %s\nKind: %s\nPower: %v\n", itemName, itemKind, itemPower)
}

func ItemReduceByUsage(questData *QuestData) {
	Output = append(Output, fmt.Sprintf("Using the item with kind '%s' and power %v\n", questData.ItemKind, questData.ItemPower))

	questData.ItemPower = questData.ItemPower / 2
	if questData.ItemPower == 0 {
		questData.ItemKind = "Junk"
	}
}

func ItemApplyEffectToPlayer(questData *QuestData) {
	Output = append(Output, fmt.Sprintf("Applying the effect of %s (%s):\n", questData.ItemName, questData.ItemKind))
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
	Output = append(Output, "Using the repair skill to fix the item:\n")

	repairAmount := -5 + ((questData.PlayerCraftingSkill * 2) + 1)

	questData.ItemPower += repairAmount

	Output = append(Output, fmt.Sprintf("Repaired the item by %v points. Item's Durability: %v\n", repairAmount, questData.ItemPower))
}

func EnemyToString(enemyName string, enemyPower int) string {
	return fmt.Sprintf("Enemy: %s\nPower: %d\n", enemyName, enemyPower)
}

func EnemyAttackPlayer(questData *QuestData) {
	Output = append(Output, fmt.Sprintf("The enemy '%s' attacks!\n", questData.EnemyName))
	damage := questData.EnemyPower

	if questData.PlayerStrength > questData.EnemyPower {
		damage = damage / 2
		Output = append(Output, "Player's strength allows them to reduce the damage!\n")
	}

	questData.PlayerHealth = questData.PlayerHealth - damage
	Output = append(Output, fmt.Sprintf("Player takes %d damage. Health is now: %d\n", damage, questData.PlayerHealth))
}

func PlayerChallengeEnemy(questData *QuestData) {
	Output = append(Output, fmt.Sprintf("The player challenges %s!\n", questData.EnemyName))
	playerAttackPower := questData.PlayerStrength
	if questData.ItemPower > 0 {
		playerAttackPower += questData.ItemPower / 2
	}

	if playerAttackPower > questData.EnemyPower {
		questData.EnemyPower = questData.EnemyPower - (playerAttackPower / 2)
		Output = append(Output, fmt.Sprintf("The player defeats the enemy! Enemy power reduced to %d\n", questData.EnemyPower))
	} else {
		Output = append(Output, "The enemy is too strong. The player retreats!\n")
	}
}
