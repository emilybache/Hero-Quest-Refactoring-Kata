package main

import (
	"fmt"

	"github.com/codecop/Hero-Quest-Refactoring-Kata/hero_quest"
)

func main() {
	result := hero_quest.PlayerToString(hero_quest.PlayerName, hero_quest.PlayerHealth, hero_quest.PlayerStrength, hero_quest.PlayerMagic, hero_quest.PlayerCraftingSkill)
	fmt.Printf("Player at begin\n%s\n", result)

	result = hero_quest.ItemToString(hero_quest.AmuletItemName, hero_quest.AmuletItemKind, hero_quest.AmuletItemPower)
	fmt.Printf("Player found an item\n%s\n", result)

	hero_quest.ItemApplyEffectToPlayer(hero_quest.AmuletItemName, hero_quest.AmuletItemKind, hero_quest.AmuletItemPower, &hero_quest.PlayerHealth, &hero_quest.PlayerStrength, &hero_quest.PlayerMagic)
	hero_quest.ItemReduceByUsage(&hero_quest.AmuletItemKind, &hero_quest.AmuletItemPower)

	result = hero_quest.PlayerToString(hero_quest.PlayerName, hero_quest.PlayerHealth, hero_quest.PlayerStrength, hero_quest.PlayerMagic, hero_quest.PlayerCraftingSkill)
	fmt.Printf("Player now\n%s\n", result)

	result = hero_quest.ItemToString(hero_quest.AmuletItemName, hero_quest.AmuletItemKind, hero_quest.AmuletItemPower)
	fmt.Printf("Item now\n%s\n", result)

	fmt.Print("Player tries to repair item...\n")
	hero_quest.ItemRepair(&hero_quest.AmuletItemPower, hero_quest.PlayerCraftingSkill)
	result = hero_quest.ItemToString(hero_quest.AmuletItemName, hero_quest.AmuletItemKind, hero_quest.AmuletItemPower)
	fmt.Printf("Item now\n%s\n", result)
}
