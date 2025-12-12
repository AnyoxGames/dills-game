using AO;

namespace Assembly.scripts;

public partial class Mob
{
    private static readonly Dictionary<Type, MobDropTable> DropTables = new();

    public static void InitDropTables(GameItems items)
    {
        DropTables.Add(typeof(Mob_Chicken), new MobDropTable
        {
            Guaranteed = new[] { (items.ChickenRaw, 1, 1) },
            Primary = new () { {(null, 0, 0), 20 }, {(items.Feather, 1, 30), 80 }}
        });
    }

    private bool TryGetDropTableForMob(Type type, out MobDropTable dropTable)
    {
        dropTable = default;
        
        if (!DropTables.ContainsKey(type))
            return false;

        dropTable = DropTables[type];
        
        return true;
    }

    public struct MobDropTable
    {
        public (Item_Definition, int, int)[] Guaranteed;
        public WeightedList<(Item_Definition, int, int)> Primary;
        public WeightedList<(Item_Definition, int, int)> Secondary;

        public List<(Item_Definition, int)> GetDrops()
        {
            List<(Item_Definition, int)> drops = new();
            foreach (var valueTuple in Guaranteed)
            {
                drops.Add((valueTuple.Item1, Random.Shared.Next(valueTuple.Item2, valueTuple.Item3)));
            }

            var primaryDrop = Primary?.Next() ?? (null, 0, 0);
            if (primaryDrop.Item1 != null)
            {
                drops.Add((primaryDrop.Item1, Random.Shared.Next(primaryDrop.Item2, primaryDrop.Item3)));
            }

            var secondaryDrop = Secondary?.Next() ?? (null, 0, 0);
            if (secondaryDrop.Item1 != null)
            {
                drops.Add((secondaryDrop.Item1, Random.Shared.Next(secondaryDrop.Item2, secondaryDrop.Item3)));
            }
            
            return drops;
        }
    }
}