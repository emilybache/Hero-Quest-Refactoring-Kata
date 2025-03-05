class HeroQuest:

    @staticmethod
    def player_to_string(player_name: str, player_health: int, player_strength: int, player_magic: int, player_crafting_skill: int):
        return ("{0}'s Attributes:\nHealth: {1}\nStrength: {2}\nMagic: {3}\nCrafting Skill: {4}\n"
                .format(player_name, player_health, player_strength, player_magic, player_crafting_skill))

    @staticmethod
    def player_falls_down(quest_data: dict):
        print("Player drops off a cliff.")

        if quest_data["player_strength"] < 5:
            quest_data["player_health"] -= 10
            print("Player's strength is too small. Health decreases by 10.")

    @staticmethod
    def item_to_string(item_name: str, item_kind: str, item_power: int):
        return "Item: {0}\nKind: {1}\nPower: {2}\n".format(item_name, item_kind, item_power)

    @staticmethod
    def item_reduce_by_usage(quest_data: dict):
        print(f"Using the item with kind '{quest_data['item_kind']}' and power {quest_data['item_power']}")

        quest_data["item_power"] = int(quest_data["item_power"] / 2)
        if quest_data["item_power"] == 0:
            quest_data["item_kind"] = "Junk"

    @staticmethod
    def item_apply_effect_to_player(quest_data: dict):
        print(f"Applying the effect of {quest_data['item_name']} ({quest_data['item_kind']}):")

        if quest_data["item_kind"] == "Health":
            quest_data["player_health"] += quest_data["item_power"]
        elif quest_data["item_kind"] == "Strength":
            quest_data["player_strength"] += quest_data["item_power"]
        elif quest_data["item_kind"] == "Magic":
            quest_data["player_magic"] += quest_data["item_power"]
        else:
            pass  # ignore unknown item kind

    @staticmethod
    def item_repair(quest_data: dict):
        print("Using the repair skill to fix the item:")

        repair_amount = -5 + ((quest_data["player_crafting_skill"] * 2) + 1)
        
        quest_data["item_power"] += repair_amount

        print(f"Repaired the item by {repair_amount} points. Item's Durability: {quest_data['item_power']}")
