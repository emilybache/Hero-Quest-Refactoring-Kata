from hero_quest import HeroQuest

if __name__ == '__main__':
    quest_data = {
        "player_name": "Conan",
        "player_health": 100,
        "player_strength": 20,
        "player_magic": 10,
        "player_crafting_skill": 10,
        "item_name": "Amulet of Strength",
        "item_kind": "Strength",
        "item_power": 10
    }

    result = HeroQuest.player_to_string(quest_data["player_name"], quest_data["player_health"], quest_data["player_strength"],
                                        quest_data["player_magic"], quest_data["player_crafting_skill"])
    print(f"Player at begin\n{result}\n", end="")

    result = HeroQuest.item_to_string(quest_data["item_name"], quest_data["item_kind"], quest_data["item_power"])
    print(f"Player found an item\n{result}\n", end="")

    HeroQuest.item_apply_effect_to_player(quest_data)
    HeroQuest.item_reduce_by_usage(quest_data)

    result = HeroQuest.player_to_string(quest_data["player_name"], quest_data["player_health"], quest_data["player_strength"],
                                        quest_data["player_magic"], quest_data["player_crafting_skill"])
    print(f"Player now\n{result}\n", end="")

    result = HeroQuest.item_to_string(quest_data["item_name"], quest_data["item_kind"], quest_data["item_power"])
    print(f"Item now\n{result}\n", end="")

    print("Player tries to repair item...\n", end="")
    HeroQuest.item_repair(quest_data)
    result = HeroQuest.item_to_string(quest_data["item_name"], quest_data["item_kind"], quest_data["item_power"])
    print(f"Item now\n{result}\n", end="")
