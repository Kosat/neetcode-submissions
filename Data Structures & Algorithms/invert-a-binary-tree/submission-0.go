/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */

func invertTree(root *TreeNode) *TreeNode {

	if root == nil {
		return nil
	}

	temp := root.Right
	root.Right = root.Left
	root.Left = temp

	root.Left = invertTree(root.Left)
	root.Right = invertTree(root.Right)

	return root
}
