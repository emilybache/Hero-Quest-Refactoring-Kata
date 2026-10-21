from hero_quest import HeroQuest


def run():
    quest_data = {
        "player_name": "Conan",
        "player_health": 100,
        "player_strength": 7,
        "player_magic": 15,
        "player_crafting_skill": 12,
        "item_name": "Healing Potion",
        "item_kind": "Health",
        "item_power": 20,
        "enemy_name": "Goblin Warlord",
        "enemy_power": 12
    }

    HeroQuest.output.append("=== QUEST BEGINNING ===\n\n")

    result = HeroQuest.player_to_string(quest_data["player_name"], quest_data["player_health"], quest_data["player_strength"],
                                        quest_data["player_magic"], quest_data["player_crafting_skill"])
    HeroQuest.output.append(f"{result}\n")

    result = HeroQuest.item_to_string(quest_data["item_name"], quest_data["item_kind"], quest_data["item_power"])
    HeroQuest.output.append(f"{result}\n")

    HeroQuest.output.append("--- Exploring the dungeon... ---\n\n")

    HeroQuest.player_falls_down(quest_data)
    result = HeroQuest.player_to_string(quest_data["player_name"], quest_data["player_health"], quest_data["player_strength"],
                                        quest_data["player_magic"], quest_data["player_crafting_skill"])
    HeroQuest.output.append(f"{result}\n")

    HeroQuest.output.append("--- Using the healing item ---\n\n")

    HeroQuest.item_apply_effect_to_player(quest_data)
    result = HeroQuest.player_to_string(quest_data["player_name"], quest_data["player_health"], quest_data["player_strength"],
                                        quest_data["player_magic"], quest_data["player_crafting_skill"])
    HeroQuest.output.append(f"{result}\n")

    result = HeroQuest.item_to_string(quest_data["item_name"], quest_data["item_kind"], quest_data["item_power"])
    HeroQuest.output.append(f"{result}\n")

    HeroQuest.output.append("--- Item degradation from repeated use ---\n\n")

    HeroQuest.item_reduce_by_usage(quest_data)
    result = HeroQuest.item_to_string(quest_data["item_name"], quest_data["item_kind"], quest_data["item_power"])
    HeroQuest.output.append(f"{result}\n")

    HeroQuest.item_reduce_by_usage(quest_data)
    result = HeroQuest.item_to_string(quest_data["item_name"], quest_data["item_kind"], quest_data["item_power"])
    HeroQuest.output.append(f"{result}\n")

    HeroQuest.output.append("--- Repairing the damaged item ---\n\n")

    HeroQuest.item_repair(quest_data)
    result = HeroQuest.item_to_string(quest_data["item_name"], quest_data["item_kind"], quest_data["item_power"])
    HeroQuest.output.append(f"{result}\n")

    HeroQuest.output.append("=== ENEMY ENCOUNTER ===\n\n")

    result = HeroQuest.enemy_to_string(quest_data["enemy_name"], quest_data["enemy_power"])
    HeroQuest.output.append(f"{result}\n")

    HeroQuest.enemy_attack_player(quest_data)
    result = HeroQuest.player_to_string(quest_data["player_name"], quest_data["player_health"], quest_data["player_strength"],
                                        quest_data["player_magic"], quest_data["player_crafting_skill"])
    HeroQuest.output.append(f"{result}\n")

    HeroQuest.output.append("--- Player retaliates ---\n\n")

    HeroQuest.player_challenge_enemy(quest_data)
    result = HeroQuest.enemy_to_string(quest_data["enemy_name"], quest_data["enemy_power"])
    HeroQuest.output.append(f"{result}\n")


if __name__ == "__main__":
    HeroQuest.output = []
    run()
    print("".join(HeroQuest.output), end="")
