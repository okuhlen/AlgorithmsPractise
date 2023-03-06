using PractiseAlgorithms.DataStructures.BinaryTrees;
using PractiseAlgorithms.DataStructures.SinglyLinkedList;
using PractiseAlgorithms.Models;

var person1 = new Person { Name = "Okuhle", Surname = "Ngada", Age = 18 };
var person2 = new Person { Name = "Jack", Surname = "The Ripper", Age = 80 };
var person3 = new Person { Name = "Naruto", Surname = "Uzumaki", Age = 30 };
var person4 = new Person { Name = "Roxham", Surname = "Road", Age = 7 };
var person5 = new Person { Name = "Jilly", Surname = "Jameson", Age = 13 };

var linkedList = new SinglyLinkedList<Person>();
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
binarySearchTree.Insert(person5);

//todo: how to iterate a binary search tree??
//todo: how to delete items from the tree?

binarySearchTree.Traverse(TreeTraversalMode.PreOrderTraversal);
Console.ReadLine();