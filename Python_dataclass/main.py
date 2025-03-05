from hero_quest import HeroQuest, QuestData

if __name__ == '__main__':
    quest_data = QuestData("Conan", 100, 20, 10, 10, "Amulet of Strength", "Strength", 10)

    result = HeroQuest.player_to_string(quest_data.player_name, quest_data.player_health, quest_data.player_strength,
                                        quest_data.player_magic, quest_data.player_crafting_skill)
    print(f"Player at begin\n{result}\n", end="")

    result = HeroQuest.item_to_string(quest_data.item_name, quest_data.item_kind, quest_data.item_power)
    print(f"Player found an item\n{result}\n", end="")

    HeroQuest.item_apply_effect_to_player(quest_data)
    HeroQuest.item_reduce_by_usage(quest_data)

    result = HeroQuest.player_to_string(quest_data.player_name, quest_data.player_health, quest_data.player_strength,
                                        quest_data.player_magic, quest_data.player_crafting_skill)
    print(f"Player now\n{result}\n", end="")

    result = HeroQuest.item_to_string(quest_data.item_name, quest_data.item_kind, quest_data.item_power)
    print(f"Item now\n{result}\n", end="")

    print("Player tries to repair item...\n", end="")
    HeroQuest.item_repair(quest_data)
    result = HeroQuest.item_to_string(quest_data.item_name, quest_data.item_kind, quest_data.item_power)
    print(f"Item now\n{result}\n", end="")
