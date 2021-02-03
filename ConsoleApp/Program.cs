using System;
using BinaryTrees;

namespace BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(12);
            binaryTree.Insert(19);
            binaryTree.Insert(11);
            binaryTree.Insert(15);
            binaryTree.Insert(21);
            binaryTree.Insert(52);
            binaryTree.Insert(49);
            binaryTree.Insert(1);
            binaryTree.Insert(7);
            binaryTree.Insert(8);
            binaryTree.Insert(42);

            Console.WriteLine(binaryTree.isPresent(52));

            binaryTree.Delete(52);

            Console.WriteLine(binaryTree.isPresent(52));

            binaryTree.InOrderTraversal();

            Console.WriteLine(binaryTree.Depth());
            
            

            //                  Todo list

            // Insert a new value                               ✔
            // Check if a value is present                      ✔
            // Depth of the tree                                ✔
            // Sum the tree                                     
            // Lowest common ancestor of two values             
            // Delete a value                                   ✔
            // Output in order, i.e. In-order traversal         ✔

        }
    }
}