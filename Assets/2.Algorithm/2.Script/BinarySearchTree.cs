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

    TreeNode root; //�ֻ��� ���
    int[] array = { 8, 3, 10, 1, 6, 14, 4, 7, 13 }; //�迭
    string result;

    private void Start()
    {
        foreach(var v in array) //�����ؼ� ���� �ֱ�         
            root = InsertNode(root, v); //�θ� ����̱⵵ �ϸ鼭 �ֻ��� ������Ʈ�̱⵵ ��.       

        PreOrder(root);
        Debug.Log($"Preorder : {result.TrimEnd(',')}");

        result = string.Empty;
        InOrder(root);
        Debug.Log($"Inorder : {result.TrimEnd(',')}");

        result = string.Empty;
        PostOrder(root);
        Debug.Log($"Postorder : {result.TrimEnd(',')}");
    }
    TreeNode InsertNode(TreeNode node, int v) //���⼭ ���� parent ����� �����ص� ��
    {
        if(node == null) //�� ó�� ���� �� node�� �� ����         
            return new TreeNode(v);
        
        if (v < node.value)        
            node.left = InsertNode(node.left, v);        
        else
            node.right = InsertNode(node.right, v);

        return node; 
    }

    void PreOrder(TreeNode node) //������ȸ
    {
        if (node == null) //�ڽ� ��尡 �ִ��� ������
            return;

        result += $"{node.value},";
        PreOrder(node.left);
        PreOrder(node.right);
    }

    void InOrder(TreeNode node) // ������ȸ
    {
        if (node == null) //�ڽ� ��尡 �ִ��� ������
            return;

        InOrder(node.left);
        result += $"{node.value},";
        InOrder(node.right);
    }

    void PostOrder(TreeNode node) //������ȸ
    {
        if (node == null) //�ڽ� ��尡 �ִ��� ������
            return;

        PostOrder(node.left);
        PostOrder(node.right);
        result += $"{node.value},";
    }
}
