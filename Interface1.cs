using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work___1
{
    
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
            Node FindNodeIndex(int index); // ищет элемент по его значению
    }

    public class LinkedList : ILinkedList
    {
        
        private Node head { get; set; }
        private Node tail { get; set; }
       

        public LinkedList()
        {
            head = tail = null;
        }

        public int GetCount ()
        {
            int count = 0;
            var Node = head;
            if (Node != null)
            {
                while (Node.NextNode != null)
                {
                    count++;
                    Node = Node.NextNode;
                }
                count++;
            }           
            return count;
        }
        public void AddNode(int value)
        {
            var NewNode = new Node { Value = value };
            if (head == null)
            {
                head = tail = NewNode;

            }
            else
            {
                tail.NextNode = NewNode;
                NewNode.PrevNode = tail;
                tail = NewNode;

            }
        }

        public void AddNodeAfter(Node node, int value)
        {
            var NewNode = new Node { Value = value };
            if (node == tail)
            {
                tail.NextNode = NewNode;
                NewNode.PrevNode = tail;
                tail = NewNode;
            }
            else
            {                
                var nextItem = node.NextNode;
                node.NextNode = NewNode;
                NewNode.NextNode = nextItem;
                nextItem.PrevNode = NewNode;
                NewNode.PrevNode = node;
            }
        }

        public Node FindNode(int searchValue)
        {
            if (head == null)
            {
                return null;
            }
            else
            {
                var currentNode = head;
                while (currentNode.NextNode != null)
                {
                    if (currentNode.Value == searchValue)
                    {
                        return currentNode;
                    }
                    currentNode = currentNode.NextNode;
                }
                if (currentNode.NextNode == null && currentNode.Value == searchValue)
                {
                    return currentNode;
                }
                else
                   return null;
            }
        }

        public Node FindNodeIndex(int index)
        {
            var i = 0;
            if (head == null)
            {
                return null;
            }
            else
            {
                var currentNode = head;
                while (i != index && currentNode != tail)
                {                   
                    currentNode = currentNode.NextNode;
                    i++;
                }
                return currentNode;
            }
        }


        public void RemoveNode(int index)
        {
            int i = 0;
            var currentNode = head;
            
            if (head == null)
            {
                return;
            }
            else
            {
                if (index == 0)
                {
                    head = currentNode.NextNode;

                }
                else
                {
                    while (i < index && currentNode.NextNode != null)  //!!! возможно "=" нужно поставить
                    {
                        currentNode = currentNode.NextNode;
                        i++;
                    }
                    if (currentNode.NextNode == null)
                    {
                        tail = currentNode.PrevNode;
                        tail.NextNode = null;
                    }
                    else
                    {
                        currentNode.PrevNode.NextNode = currentNode.NextNode;
                        currentNode.NextNode.PrevNode = currentNode.PrevNode;
                    }
                    
                }
                
            }

        }

        public void RemoveNode(Node node)
        {
            var currentNode = head;
            if (head == null)
            {
                return;
            }
            else
            {
                if (node.PrevNode == null)
                {
                    head = currentNode.NextNode;

                }
                else
                {
                   
                        while (currentNode.Value != node.Value)
                        {
                            currentNode = currentNode.NextNode;
                        }
                        if (currentNode.NextNode == null)
                        {
                            tail = currentNode.PrevNode;
                            tail.NextNode = null;
                        }
                        else
                        {
                            currentNode.PrevNode.NextNode = currentNode.NextNode;
                            currentNode.NextNode.PrevNode = currentNode.PrevNode;
                        }
                    
                    
                        
                }
                    
            }
        }

    }
}
