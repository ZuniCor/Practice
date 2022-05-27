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
        if (head == null)
            return false;

        SinglyLinkedListNode slow = head.next;
        SinglyLinkedListNode fast = head.next.next;

        while (slow != null && fast != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }



        return false;
    }

    static void Main(string[] args)
    {
        int tests = 0;

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
