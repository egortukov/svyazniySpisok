using System;
using System.Collections;
using System.Collections.Generic;


public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T value, Node<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T>? head;

    public void Add(T value)
    {
        if (head == null)
        {
            head = new Node<T>(value);
        }
        else
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new Node<T>(value);
        }
    }

    public void InsertAfter(T target, T value)
    {
        var current = Find(target);
        if (current != null)
        {
            current.Next = new Node<T>(value, current.Next);
        }
    }

    public Node<T>? Find(T value)
    {
        var current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
                return current;
            current = current.Next;
        }

        return null;
    }

    public void Remove(T value)
    {
        if (head == null) return;

        if (EqualityComparer<T>.Default.Equals(head.Value, value))
        {
            head = head.Next;
            return;
        }

        var current = head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Value, value))
            {
                current.Next = current.Next.Next;
                return;
            }

            current = current.Next;
        }
    }

    public int Count()
    {
        int count = 0;
        var current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public static class LinkedListExtensions
{
    public static void PrintToConsole<T>(this LinkedList<T> list)
    {
        foreach (var value in list)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine();
    }
}

public class Zadacha
{
    public static void Main()
    {
        var list = new LinkedList<int>();


        for (int i = 1; i <= 10; i++)
        {
            list.Add(i);
        }


        list.InsertAfter(5, 42);


        var nodeToReplace = list.Find(9);
        if (nodeToReplace != null)
        {
            nodeToReplace.Value = -1;
        }


        list.Remove(3);


        Console.WriteLine($"Длина списка: {list.Count()}");


        list.PrintToConsole();
    }
}