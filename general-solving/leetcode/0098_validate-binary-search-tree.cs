/***************************************************************************
* Problem Name: Validate Binary Search Tree
* Problem URL : https://leetcode.com/problems/validate-binary-search-tree/
* Date        : Oct 31 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : A clever inorder traversal and updating the previous root each
*   time solves the problem
*   related: leetcode/095_validate-binary-search-tree.cpp
*               
*   Why the solution is like this?
*   http://blogs.msdn.com/b/csharpfaq/archive/2004/05/11/
*   why-doesn-t-c-support-static-method-variables.aspx
* meta        : tag-binary-tree, tag-recursion
***************************************************************************/
public class Solution {
  // Moving this declaration inside a method is not supported
  static TreeNode prev;

  // This additional method could not gotten rid of since this method is called
  // multiple times from leetcode online judge. But, prev static property is
  // initialized single time when the class was instantiated
  public bool IsValidBST(TreeNode root) {
    prev = null;
    return IsValidBSTRec(root);
  }

  public bool IsValidBSTRec(TreeNode root) {
    if (root == null) return true;
    
    if (IsValidBSTRec(root.left) == false)
      return false;
    if (prev != null && root.val <= prev.val)
      return false;
    
    prev = root;
    if (IsValidBSTRec(root.right) == false)
      return false;
    return true;
  }
}