using AO;

namespace Assembly.scripts;

public static class Commands
{
    [ChatCommand("addxp", "Grants xp in the specified skill", ChatCommandPermissions.YouTuber)]
    public static void AddXp(MyPlayer player, string skillName, int xpAmount)
    {
        if (MyUtil.TryParseSkillType(skillName, out SkillType type))
        {
            player.GetSkillFromType(type).ServerAwardXp(xpAmount);
            Chat.SendMessage(player, $"Added {xpAmount} xp to {skillName}");
            return;
        }
        
        Chat.SendMessage(player, $"Cannot find the skill with name \"{skillName}\"");
    }
    
    [ChatCommand("setlvl", "Sets a skill to a specific level", ChatCommandPermissions.YouTuber)]
    public static void SetLevel(MyPlayer player, string skillName, int level)
    {
        if (MyUtil.TryParseSkillType(skillName, out SkillType type))
        {
            player.GetSkillFromType(type).ServerSetXp(MyUtil.GetXPForLevel(level));
            Chat.SendMessage(player, $"Set {skillName} to level {level}");
            return;
        }
        
        Chat.SendMessage(player, $"Cannot find the skill with name \"{skillName}\"");
    }

    [ChatCommand("resetlvls", "Sets all skills to their minimum level", ChatCommandPermissions.YouTuber)]
    public static void ResetAllLevels(MyPlayer player)
    {
        foreach (var skillType in Enum.GetValues<SkillType>())
        {
            if (skillType == SkillType.Null)
                continue;

            var skill = player.GetSkillFromType(skillType);
            skill.ServerSetXp(skill.DefaultXP);
        }
    }
    
    [ChatCommand("maxlvls", "Sets all skills to their maximum level", ChatCommandPermissions.YouTuber)]
    public static void MaxAllLevels(MyPlayer player)
    {
        foreach (var skillType in Enum.GetValues<SkillType>())
        {
            if (skillType == SkillType.Null)
                continue;
            
            var skill = player.GetSkillFromType(skillType);
            skill.ServerSetXp(MyUtil.GetXPForLevel(skill.LevelCap));
        }
    }

    [ChatCommand("additem", "Adds the specified item and quantity to the players inventory", ChatCommandPermissions.YouTuber)]
    public static void AddItem(MyPlayer player, string itemId, int amount)
    {
        Item_Definition itemDef = null;
        
        foreach (var item in GameItems.Instance.AllItems)
        {
            if (item.Id == itemId)
            {
                itemDef = item;
                break;
            }
        }

        if (itemDef == null)
        {
            Chat.SendMessage(player, $"Cannot find the item with id \"{itemId}\"");
            return;
        }

        if (!player.ServerTryAddItem(itemDef, amount))
        {
            Chat.SendMessage(player, $"Could not add {amount}x {itemDef.Name}");
            return;
        }
        
        Chat.SendMessage(player, $"Added {amount}x {itemDef.Name}");
    }
    
    [ChatCommand("die", "Unalive yourself", ChatCommandPermissions.YouTuber)]
    public static void Die(MyPlayer player)
    {
        player.ServerTakeDamage(player.CurrentHealth, null);
    }

    [ChatCommand("damageself", "Deals X damage to yourself, for whatever reason", ChatCommandPermissions.YouTuber)]
    public static void DamageSelf(MyPlayer player, int damage)
    {
        player.ServerTakeDamage(damage, null);
    }
    
    [ChatCommand("healself", "Restores X health on yourself", ChatCommandPermissions.YouTuber)]
    public static void HealSelf(MyPlayer player, int amountRestored)
    {
        player.ServerHeal(amountRestored, null);
    }
}