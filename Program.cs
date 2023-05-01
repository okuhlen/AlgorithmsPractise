using PractiseAlgorithms.DataStructures.BinaryTrees;
using PractiseAlgorithms.DataStructures.Graphs;
using PractiseAlgorithms.DataStructures.SinglyLinkedList;
using PractiseAlgorithms.Models;

var person1 = new Person { Name = "Okuhle", Surname = "Ngada", Age = 18 };
var person2 = new Person { Name = "Jack", Surname = "The Ripper", Age = 80 };
var person3 = new Person { Name = "Naruto", Surname = "Uzumaki", Age = 30 };
var person4 = new Person { Name = "Roxham", Surname = "Road", Age = 7 };
var person5 = new Person { Name = "Jilly", Surname = "Jameson", Age = 13 };

//--- Basic Graph ---//
var graph = new Graph<int, Person>();
//Okuhle node
graph.Add(person1.Age, person1, new List<KeyValuePair<int, Person>>()
{
    new(person2.Age, person2),
    new(person3.Age, person3)
});
//Naruto node
graph.Add(person3.Age, person3, new List<KeyValuePair<int, Person>>()
{
    new(person5.Age, person5)
});
//jilly node
graph.Add(person5.Age, person5, new List<KeyValuePair<int, Person>>());
//jack node
graph.Add(person2.Age, person2, new List<KeyValuePair<int, Person>>()
{
    new(person4.Age, person4)
});
//rox node
graph.Add(person4.Age, person4, new List<KeyValuePair<int, Person>>()
{
    new(person3.Age, person3)
});

Console.WriteLine("Expected Traversal: (1) Okuhle, (2) Naruto, (3) Jilly, (4) Jack, (5) Rox, (6) Naruto");
//depth-first traversal: using a stack
graph.TraverseDepthFirst(new Node<int, Person>()
{
    Key = person1.Age,
    Value = person1
});

Console.ReadLine();







/*var linkedList = new SinglyLinkedList<Person>();
linkedList.Add(person1);
linkedList.Add(person2);
linkedList.Add(person3);

linkedList.PrintAllItems();
Console.WriteLine();

Console.WriteLine($"Now searching for {person2}");
var findItem = linkedList.Find(person2);
if (findItem is null)
    Console.WriteLine($"Could not find: {person2}");
else
    Console.WriteLine($"Found {person2}! The operator overloading worked!");


ITree<Person> binarySearchTree = new BinarySearchTree<Person>();
binarySearchTree.Insert(person1);
binarySearchTree.Insert(person2);
binarySearchTree.Insert(person3);
binarySearchTree.Insert(person4);
binarySearchTree.Insert(person5);*/

//todo: how to iterate a binary search tree??
//todo: how to delete items from the tree?

/*binarySearchTree.Traverse(TreeTraversalMode.PreOrderTraversal);
Console.ReadLine();*/