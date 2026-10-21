package main

import (
	"fmt"
	"strings"

	"github.com/codecop/Hero-Quest-Refactoring-Kata-Struct/hero_quest"
)

func run() {
	questData := hero_quest.QuestData{
		PlayerName:          "Conan",
		PlayerHealth:        100,
		PlayerStrength:      7,
		PlayerMagic:         15,
		PlayerCraftingSkill: 12,
		ItemName:            "Healing Potion",
		ItemKind:            "Health",
		ItemPower:           20,
		EnemyName:           "Goblin Warlord",
		EnemyPower:          12,
	}

	hero_quest.Output = append(hero_quest.Output, "=== QUEST BEGINNING ===\n\n")

	result := hero_quest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	result = hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Exploring the dungeon... ---\n\n")

	hero_quest.PlayerFallsDown(&questData)
	result = hero_quest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Using the healing item ---\n\n")

	hero_quest.ItemApplyEffectToPlayer(&questData)
	result = hero_quest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	result = hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Item degradation from repeated use ---\n\n")

	hero_quest.ItemReduceByUsage(&questData)
	result = hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.ItemReduceByUsage(&questData)
	result = hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Repairing the damaged item ---\n\n")

	hero_quest.ItemRepair(&questData)
	result = hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "=== ENEMY ENCOUNTER ===\n\n")

	result = hero_quest.EnemyToString(questData.EnemyName, questData.EnemyPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.EnemyAttackPlayer(&questData)
	result = hero_quest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")

	hero_quest.Output = append(hero_quest.Output, "--- Player retaliates ---\n\n")

	hero_quest.PlayerChallengeEnemy(&questData)
	result = hero_quest.EnemyToString(questData.EnemyName, questData.EnemyPower)
	hero_quest.Output = append(hero_quest.Output, result)
	hero_quest.Output = append(hero_quest.Output, "\n")
}

func main() {
	hero_quest.Output = []string{}
	run()
	fmt.Print(strings.Join(hero_quest.Output, ""))
}
