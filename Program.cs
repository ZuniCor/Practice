using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;
        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    // Complete the hasCycle function below.

    /*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
    static bool hasCycle(SinglyLinkedListNode head)
    {
        var tracker = new Dictionary<SinglyLinkedListNode, List<int>>();

        SinglyLinkedListNode? node = null;

        do 
        {
            if (!tracker.ContainsKey(head.next))
                tracker.Add(head.next, new List<int> { head.data });
            else
                tracker[head.next].Add(head.data);

            node.next = head.next.next;

        } while (node != null);

        foreach (var item in tracker)
        {
            if (item.Value.Count > 1)
                return true;
        }

        return false;
    }

    static void Main(string[] args)
    {
        int tests = 1;

        for (int testsItr = 0; testsItr < tests; testsItr++)
        {
            int index = Convert.ToInt32(args[testsItr]);

            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = args.Length;

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(args[i]);
                llist.InsertNode(llistItem);
            }

            SinglyLinkedListNode extra = new SinglyLinkedListNode(-1);
            SinglyLinkedListNode temp = llist.head;

            for (int i = 0; i < llistCount; i++)
            {
                if (i == index)
                    extra = temp;

                if (i != llistCount - 1)
                    temp = temp.next;
            }
            temp.next = extra;
            bool result = hasCycle(llist.head);
            Console.WriteLine((result ? 1 : 0));
        }
    }
}
