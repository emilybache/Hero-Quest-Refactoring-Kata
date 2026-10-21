package main

import (
	"fmt"
	"strings"

	"github.com/codecop/Hero-Quest-Refactoring-Kata/hero_quest"
)

func run() {
	playerName := "Conan"
	playerHealth := 100
	playerStrength := 7
	playerMagic := 15
	playerCraftingSkill := 12
	itemName := "Healing Potion"
	itemKind := "Health"
	itemPower := 20
	enemyName := "Goblin Warlord"
	enemyPower := 12

	hero_quest.Output = append(hero_quest.Output, "=== QUEST BEGINNING ===\n\n")

	result := hero_quest.PlayerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	result = hero_quest.ItemToString(itemName, itemKind, itemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Exploring the dungeon... ---\n\n")

	hero_quest.PlayerFallsDown(&playerHealth, &playerStrength)
	result = hero_quest.PlayerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Using the healing item ---\n\n")

	hero_quest.ItemApplyEffectToPlayer(itemName, itemKind, itemPower, &playerHealth, &playerStrength, &playerMagic)
	result = hero_quest.PlayerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	result = hero_quest.ItemToString(itemName, itemKind, itemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Item degradation from repeated use ---\n\n")

	hero_quest.ItemReduceByUsage(&itemKind, &itemPower)
	result = hero_quest.ItemToString(itemName, itemKind, itemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.ItemReduceByUsage(&itemKind, &itemPower)
	result = hero_quest.ItemToString(itemName, itemKind, itemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Repairing the damaged item ---\n\n")

	hero_quest.ItemRepair(&itemPower, playerCraftingSkill)
	result = hero_quest.ItemToString(itemName, itemKind, itemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "=== ENEMY ENCOUNTER ===\n\n")

	result = hero_quest.EnemyToString(enemyName, enemyPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.EnemyAttackPlayer(enemyName, enemyPower, playerStrength, &playerHealth)
	result = hero_quest.PlayerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Player retaliates ---\n\n")

	hero_quest.PlayerChallengeEnemy(enemyName, playerStrength, itemPower, &enemyPower)
	result = hero_quest.EnemyToString(enemyName, enemyPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")
}

func main() {
	hero_quest.Output = []string{}
	run()
	fmt.Print(strings.Join(hero_quest.Output, ""))
}
