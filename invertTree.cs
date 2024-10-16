using System;
using System.Collections.Generic;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    
    public TreeNode( int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
    
}

public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        if(root == null) {
            return null;
        }
        
        TreeNode left = InvertTree(root.left);
        TreeNode right = InvertTree(root.right);
        
        root.left = right;
        root.right = left;
        
        return root;
    }
}

public class Program {
    
    public static void PrintInorder(TreeNode root) {
        if(root == null)
        return;
        
        PrintInorder(root.left);
        Console.WriteLine(root.val + " ");
        PrintInorder(root.right);
        
    }
    
    public static void Main(string[] args) {
        TreeNode root = new TreeNode(4);
        root.left = new TreeNode(2);
        root.right = new TreeNode(7);
        root.left.left = new TreeNode(1);
        root.left.right = new TreeNode(3);
        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(9);
        
        
        Console.WriteLine("Original Tree (In-Order):");
        PrintInorder(root);
        Console.WriteLine(); // new line

        // Invert the tree
        Solution solution = new Solution();
        TreeNode invertedRoot = solution.InvertTree(root);

        // Print the inverted tree (in-order traversal)
        Console.WriteLine("Inverted Tree (In-Order):");
        PrintInorder(invertedRoot);
        
    }
    
    
}
