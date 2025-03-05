package main

import (
	"fmt"

	"github.com/codecop/Hero-Quest-Refactoring-Kata-Struct/hero_quest"
)

func main() {
	questData := hero_quest.QuestData{
		PlayerName:          "Conan",
		PlayerHealth:        100,
		PlayerStrength:      20,
		PlayerMagic:         10,
		PlayerCraftingSkill: 10,
		ItemName:            "Amulet of Strength",
		ItemKind:            "Strength",
		ItemPower:           10,
	}

	result := hero_quest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill)
	fmt.Printf("Player at begin\n%s\n", result)

	result = hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)
	fmt.Printf("Player found an item\n%s\n", result)

	hero_quest.ItemApplyEffectToPlayer(&questData)
	hero_quest.ItemReduceByUsage(&questData)

	result = hero_quest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill)
	fmt.Printf("Player now\n%s\n", result)

	result = hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)
	fmt.Printf("Item now\n%s\n", result)

	fmt.Print("Player tries to repair item...\n")
	hero_quest.ItemRepair(&questData)
	result = hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)
	fmt.Printf("Item now\n%s\n", result)
}
