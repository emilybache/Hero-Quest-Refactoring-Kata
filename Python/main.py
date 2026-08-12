from hero_quest import HeroQuest

if __name__ == '__main__':
    HeroQuest.output = []
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

    result = HeroQuest.player_to_string(quest_data["player_name"], quest_data["player_health"],
                                        quest_data["player_strength"],
                                        quest_data["player_magic"], quest_data["player_crafting_skill"])
    print(result, end="")
