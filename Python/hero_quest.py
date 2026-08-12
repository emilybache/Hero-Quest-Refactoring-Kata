class HeroQuest:
    output = []

    @staticmethod
    def player_to_string(player_name: str, player_health: int, player_strength: int, player_magic: int, player_crafting_skill: int):
        return ("{0}'s Attributes:\nHealth: {1}\nStrength: {2}\nMagic: {3}\nCrafting Skill: {4}\n"
                .format(player_name, player_health, player_strength, player_magic, player_crafting_skill))

    @staticmethod
    def enemy_to_string(enemy_name: str, enemy_power: int):
        return "Enemy: {0}\nPower: {1}\n".format(enemy_name, enemy_power)

    @staticmethod
    def item_to_string(item_name: str, item_kind: str, item_power: int):
        return "Item: {0}\nKind: {1}\nPower: {2}\n".format(item_name, item_kind, item_power)

    @staticmethod
    def player_falls_down(player_strength: int, player_health: int):
        HeroQuest.output.append("Player drops off a cliff.\n")

        if player_strength < 5:
            player_health -= 10
            HeroQuest.output.append("Player's strength is too small. Health decreases by 10.\n")
        
        return player_health

    @staticmethod
    def item_reduce_by_usage(item_kind: str, item_power: int):
        HeroQuest.output.append(f"Using the item with kind '{item_kind}' and power {item_power}\n")

        item_power = int(item_power / 2)
        if item_power == 0:
            item_kind = "Junk"
        
        return item_kind, item_power

    @staticmethod
    def item_apply_effect_to_player(item_name: str, item_kind: str, item_power: int, player_health: int, player_strength: int, player_magic: int):
        HeroQuest.output.append(f"Applying the effect of {item_name} ({item_kind}):\n")

        if item_kind == "Health":
            player_health += item_power
        elif item_kind == "Strength":
            player_strength += item_power
        elif item_kind == "Magic":
            player_magic += item_power
        else:
            pass  # ignore unknown item kind
        
        return player_health, player_strength, player_magic

    @staticmethod
    def item_repair(player_crafting_skill: int, item_power: int):
        HeroQuest.output.append("Using the repair skill to fix the item:\n")

        repair_amount = -5 + ((player_crafting_skill * 2) + 1)
        
        item_power += repair_amount

        HeroQuest.output.append(f"Repaired the item by {repair_amount} points. Item's Durability: {item_power}\n")
        
        return item_power

    @staticmethod
    def enemy_attack_player(enemy_name: str, enemy_power: int, player_strength: int, player_health: int):
        HeroQuest.output.append(f"The enemy '{enemy_name}' attacks!\n")
        damage = enemy_power

        if player_strength > enemy_power:
            damage = int(damage / 2)
            HeroQuest.output.append("Player's strength allows them to reduce the damage!\n")

        player_health -= damage
        HeroQuest.output.append(f"Player takes {damage} damage. Health is now: {player_health}\n")

        return player_health

    @staticmethod
    def player_challenge_enemy(enemy_name: str, player_strength: int, item_power: int, enemy_power: int):
        HeroQuest.output.append(f"The player challenges {enemy_name}!\n")
        player_attack_power = player_strength + (int(item_power / 2) if item_power > 0 else 0)

        if player_attack_power > enemy_power:
            enemy_power -= int(player_attack_power / 2)
            HeroQuest.output.append(f"The player defeats the enemy! Enemy power reduced to {enemy_power}\n")
        else:
            HeroQuest.output.append("The enemy is too strong. The player retreats!\n")

        return enemy_power
