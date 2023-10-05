// NDC Conf
// See https://aka.ms/new-console-template for more information


// Defaults and nullables for structs
Vector2 vec = default;
Console.WriteLine(vec);

Vector2? vec_nullable_1 = null;
Nullable<Vector2> vec_nullable_2 = null;
Console.WriteLine(vec_nullable_1);
Console.WriteLine(vec_nullable_2);


// Collections and generics
Collection<Vector2> vectors = new Collection<Vector2>();
Console.WriteLine("\nAdding fifty elements to the collection...");
for (int i = 0; i < 50; ++i)
{
    vectors.Add(new Vector2 { X = Random.Shared.NextSingle(), Y = Random.Shared.NextSingle() });
}

Console.WriteLine("\nWriting collection with the ToString() method");
Console.WriteLine(vectors);

Console.WriteLine("\nWriting collection with the IEnumerator<T> and IEnumerable<T> thru foreach");
foreach (var v in vectors)
{
    Console.WriteLine(v);
}


Console.WriteLine("\nYield return example");
foreach (var f in YieldReturnExample())
{
    Console.WriteLine(f);
}


Console.WriteLine("\nDictionary example");
Dictionary<Fruit, int> fruits_and_qty = new Dictionary<Fruit, int>
{
    { Fruit.Apple, 2 },
    { Fruit.Orange, 4 }
};

foreach (KeyValuePair<Fruit, int> kv in fruits_and_qty)
{
    Console.WriteLine($"I have a {kv.Value} of {kv.Key} in the dictionary");
}
fruits_and_qty.Remove(Fruit.Apple);
foreach (KeyValuePair<Fruit, int> kv in fruits_and_qty)
{
    Console.WriteLine($"Now I have a {kv.Value} of {kv.Key} in the dictionary");
}
fruits_and_qty.Add(Fruit.Peach, 10);
fruits_and_qty.Add(Fruit.Plum, 4);
try
{
    Console.WriteLine("Now I'm trying to add Peach again");
    fruits_and_qty.Add(Fruit.Peach, 2);
}
catch (ArgumentException ex)
{
    Console.WriteLine("And I've got an exception");
    Console.WriteLine(ex);
}

if (fruits_and_qty.ContainsKey(Fruit.Peach))
{
    Console.WriteLine("I have a peach in the dictionary");
}

if (fruits_and_qty.TryGetValue(Fruit.Apple, out var applesCount))
{
    Console.WriteLine($"I have {applesCount} apples in the dictionary");
}
else
{
    Console.WriteLine("I don't have any apples in the dictionary");
}

fruits_and_qty.Clear();


Console.WriteLine("\nHashset example");
HashSet<Fruit> my_fruits = new HashSet<Fruit>
{
    Fruit.Apple,
    Fruit.Plum,
    Fruit.Orange,
    Fruit.Peach
};
foreach (var f in my_fruits)
{
    Console.WriteLine($"{f} from the hashset");
}

Console.WriteLine("Adding some more fruits...");
my_fruits.Add(Fruit.Apple);
my_fruits.Add(Fruit.Peach);
my_fruits.Add(Fruit.Orange);
foreach (var f in my_fruits)
{
    Console.WriteLine($"{f} from the hashset");
}

my_fruits.Remove(Fruit.Apple);
if (my_fruits.Contains(Fruit.Apple))
{
    Console.WriteLine("I have an apple in the hashset");
}
else if (my_fruits.Contains(Fruit.Peach))
{
    Console.WriteLine("I have a peach in the hashset");
}
else
{
    Console.WriteLine("I don't have neither apple nor peach");
}

HashSet<Fruit> all_fruits = new HashSet<Fruit>
{
    Fruit.Plum,
    Fruit.Orange,
    Fruit.Peach,
    Fruit.Apple,
};

if (all_fruits.IsSupersetOf(my_fruits))
{
    Console.WriteLine("All fruits is a superset of my fruits hashset");
}

if (!my_fruits.IsSupersetOf(all_fruits))
{
    Console.WriteLine("But my fruits isn't a superset of all fruits hashset, because my friuts has no apples in it.");
}

my_fruits.Add(Fruit.Apple);
if (my_fruits.IsSupersetOf(all_fruits))
{
    Console.WriteLine("If I add an apple to my fruits then it would also become a superset of all fruits hashset");
}

// EnumAndTupleExample
(Fruit Name, int Qty, string Color) fruit = (Fruit.Apple, 2, "red");
Fruit itemByKey = fruit.Item1;
Fruit itemBytName  = fruit.Name;

static IEnumerable<Fruit> YieldReturnExample()
{
    Console.WriteLine("Fetching info about apples...");
    yield return Fruit.Apple;

    Console.WriteLine("Fetching info about oranges...");
    yield return Fruit.Orange;
}
