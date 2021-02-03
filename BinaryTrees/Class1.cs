using System;

namespace BinaryTrees
{
    public class BinaryTree
    {
        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }
        }



        public void Insert(int data)
        {
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {
                root = new TreeNode(data);
            }
        }

        public bool isPresent(int data)
        {
            if (root != null)
            {
                return root.isPresent(data);
            }
            else
            {
                return false;
            }
        }

        public int Depth()
        {
            if (root == null)
            { return 0; }

            return root.Depth();
        }

        public void Delete(int data)
        {
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false;

            // Checks for empty tree
            if (current == null)
            {
                return;
            }

            // Find the Node to delete
            while (current != null && current.Data != data)
            {
                parent = current;

                if (data < current.Data)
                {
                    current = current.LeftNode;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightNode;
                    isLeftChild = false;
                }
            }

            if (current == null)
            {
                return;
            }

            // Delete a leaf node
            if (current.RightNode == null && current.LeftNode == null)
            {

                if (current == root)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                    {

                        parent.LeftNode = null;
                    }
                    else
                    {
                        parent.RightNode = null;
                    }
                }
            }
            else if (current.RightNode == null) // One child (left)
            {
                if (current == root)
                {
                    root = current.LeftNode;
                }
                else
                {

                    if (isLeftChild)
                    {
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            else if (current.LeftNode == null) // One child (right)
            {
                if (current == root)
                {
                    root = current.RightNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            else // Two children
            {
                TreeNode successor = GetSuccessor(current);

                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftNode = successor;
                }
                else
                {
                    parent.RightNode = successor;
                }

            }

        }

        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.RightNode;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;
            }
            if (successor != node.RightNode)
            {
                parentOfSuccessor.LeftNode = successor.RightNode;

                successor.RightNode = node.RightNode;
            }

            successor.LeftNode = node.LeftNode;

            return successor;
        }

        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }
    }
}




public class TreeNode
{
    private int data;
    public int Data
    {
        get { return data; }
    }

    private TreeNode rightNode;
    public TreeNode RightNode
    {
        get { return rightNode; }
        set { rightNode = value; }
    }

    private TreeNode leftNode;
    public TreeNode LeftNode
    {
        get { return leftNode; }
        set { leftNode = value; }
    }

    public TreeNode(int value)
    {
        data = value;
    }

    public void Insert(int value)
    {
        if (value >= data)
        {
            if (rightNode == null)
            {
                rightNode = new TreeNode(value);
            }
            else
            {
                rightNode.Insert(value);
            }
        }
        else
        {
            if (leftNode == null)
            {
                leftNode = new TreeNode(value);
            }
            else
            {
                leftNode.Insert(value);
            }
        }
    }

    public bool isPresent(int value)
    {
        TreeNode currentNode = this;

        while (currentNode != null)
        {
            if (value == currentNode.data)
            {
                return true;
            }
            else if (value > currentNode.data)
            {
                currentNode = currentNode.rightNode;
            }
            else
            {
                currentNode = currentNode.leftNode;
            }
        }
        return false;
    }

    public int Depth()
    {
    
        if (this.leftNode == null && this.rightNode == null)
        {
            return 1; // Just a leaf node is in the tree
        }

        int left = 0;
        int right = 0;

        if (this.leftNode != null)
            left = this.leftNode.Depth();
        if (this.rightNode != null)
            right = this.rightNode.Depth();

        // Determine greater depth of both branches
        if (left > right)
        {
            return (left + 1);
        }
        else
        {
            return (right + 1);
        }

    }

    public void InOrderTraversal()
    {

        if (leftNode != null)
            leftNode.InOrderTraversal();

        Console.Write(data + " ");


        if (rightNode != null)
            rightNode.InOrderTraversal();
    }
}