package hero_quest

import "fmt"

var Output []string

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
	Output = append(Output, "Player drops off a cliff.\n")

	if *playerStrength < 5 {
		*playerHealth -= 10
		Output = append(Output, "Player's strength is too small. Health decreases by 10.\n")
	}
}

func ItemToString(itemName string, itemKind string, itemPower int) string {
	return fmt.Sprintf("Item: %s\nKind: %s\nPower: %v\n", itemName, itemKind, itemPower)
}

func ItemReduceByUsage(itemKind *string, itemPower *int) {
	Output = append(Output, fmt.Sprintf("Using the item with kind '%s' and power %v\n", *itemKind, *itemPower))

	*itemPower /= 2
	if *itemPower == 0 {
		*itemKind = "Junk"
	}
}

func ItemApplyEffectToPlayer(itemName string, itemKind string, itemPower int, playerHealth *int, playerStrength *int, playerMagic *int) {
	Output = append(Output, fmt.Sprintf("Applying the effect of %s (%s):\n", itemName, itemKind))
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
	Output = append(Output, "Using the repair skill to fix the item:\n")

	repairAmount := -5 + ((playerCraftingSkill * 2) + 1)

	*itemPower += repairAmount

	Output = append(Output, fmt.Sprintf("Repaired the item by %v points. Item's Durability: %v\n", repairAmount, *itemPower))
}

func EnemyToString(enemyName string, enemyPower int) string {
	return fmt.Sprintf("Enemy: %s\nPower: %d\n", enemyName, enemyPower)
}

func EnemyAttackPlayer(enemyName string, enemyPower int, playerStrength int, playerHealth *int) {
	Output = append(Output, fmt.Sprintf("The enemy '%s' attacks!\n", enemyName))
	damage := enemyPower

	if playerStrength > enemyPower {
		damage = damage / 2
		Output = append(Output, "Player's strength allows them to reduce the damage!\n")
	}

	*playerHealth = *playerHealth - damage
	Output = append(Output, fmt.Sprintf("Player takes %d damage. Health is now: %d\n", damage, *playerHealth))
}

func PlayerChallengeEnemy(enemyName string, playerStrength int, itemPower int, enemyPower *int) {
	Output = append(Output, fmt.Sprintf("The player challenges %s!\n", enemyName))
	playerAttackPower := playerStrength
	if itemPower > 0 {
		playerAttackPower += itemPower / 2
	}

	if playerAttackPower > *enemyPower {
		*enemyPower = *enemyPower - (playerAttackPower / 2)
		Output = append(Output, fmt.Sprintf("The player defeats the enemy! Enemy power reduced to %d\n", *enemyPower))
	} else {
		Output = append(Output, "The enemy is too strong. The player retreats!\n")
	}
}
