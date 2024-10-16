/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(preorder.Length == 0 || inorder.Length == 0) {
            return null;
        }
        
        // The first element in preorder is the root
        TreeNode root = new TreeNode(preorder[0]);
        
        // Find the index of the root in inorder array
        int mid = Array.IndexOf(inorder, preorder[0]);
        
        // Recursively build the left and right subtrees
        // Left subtree: preorder from 1 to mid + 1, inorder from 0 to mid
        root.left = BuildTree(SubArray(preorder, 1, mid + 1), SubArray(inorder, 0, mid));
        
        // Right subtree: preorder from mid + 1 to end, inorder from mid + 1 to end
        root.right = BuildTree(SubArray(preorder, mid + 1, preorder.Length), SubArray(inorder, mid + 1, inorder.Length));
        
        return root;
    }
    
    private int[] SubArray(int[] array, int start, int end) {
        int length = end - start;
        int[] subArray = new int[length];
        Array.Copy(array, start, subArray, 0, length);
        return subArray;
    }
}
