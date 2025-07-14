using JetBrains.Annotations;
using UnityEngine;

public class BinarySearchTree : MonoBehaviour
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }

    TreeNode root; //최상위 노드
    int[] array = { 8, 3, 10, 1, 6, 14, 4, 7, 13 }; //배열
    string result;

    private void Start()
    {
        foreach(var v in array) //정렬해서 노드로 넣기         
            root = InsertNode(root, v); //부모 노드이기도 하면서 최상위 오브젝트이기도 함.       

        PreOrder(root);
        Debug.Log($"Preorder : {result.TrimEnd(',')}");

        result = string.Empty;
        InOrder(root);
        Debug.Log($"Inorder : {result.TrimEnd(',')}");

        result = string.Empty;
        PostOrder(root);
        Debug.Log($"Postorder : {result.TrimEnd(',')}");
    }
    TreeNode InsertNode(TreeNode node, int v) //여기서 노드는 parent 노드라고 생각해도 됨
    {
        if(node == null) //맨 처음 실행 시 node는 널 상태         
            return new TreeNode(v);
        
        if (v < node.value)        
            node.left = InsertNode(node.left, v);        
        else
            node.right = InsertNode(node.right, v);

        return node; 
    }

    void PreOrder(TreeNode node) //전위순회
    {
        if (node == null) //자식 노드가 있는지 없는지
            return;

        result += $"{node.value},";
        PreOrder(node.left);
        PreOrder(node.right);
    }

    void InOrder(TreeNode node) // 중위순회
    {
        if (node == null) //자식 노드가 있는지 없는지
            return;

        InOrder(node.left);
        result += $"{node.value},";
        InOrder(node.right);
    }

    void PostOrder(TreeNode node) //후위순회
    {
        if (node == null) //자식 노드가 있는지 없는지
            return;

        PostOrder(node.left);
        PostOrder(node.right);
        result += $"{node.value},";
    }
}
