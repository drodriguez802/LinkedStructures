namespace LinkedStructures
{
    /// <summary>
    /// Class that contains the implementation of a generic Singly Linked List
    /// </summary>
    class SinglyLinkedList<E>
    {
        /// <summary>
        /// Nested class that has the Node properties
        /// </summary>
        private class Node
        {
            public Node next;
            public E element;

            /// <summary>
            /// Creates a new Node
            /// </summary>
            /// <param name="next">Next node on the list</param>
            /// <param name="element">Element that the node will contain</param>
            public Node(Node next, E element)
            {
                this.next = next;
                this.element = element;
            }
        }

        Node head;
        int size = 0;

        /// <summary>
        /// Gets the current size of the list
        /// </summary>
        /// <returns>Integer size</returns>
        public int getSize()
        {
            return size;
        }       
        
        /// <summary>
        /// Adds a new node at the end of the list
        /// </summary>
        /// <param name="element">Element that the new node will contain</param>
        public void add(E element)
        {
            if (size == 0)
            {
                head = new Node(null, element);
            }
            else
            {
                recAddLast(head, new Node(null, element));
            }
            size++;
        }

        /// <summary>
        /// Adds a new Node at the beginning of the list
        /// </summary>
        /// <param name="element"></param>
        public void addFirst(E element)
        {
            head = new Node(head, element);
        }

        /// <summary>
        /// Helper method for addLast. Recrusively adds a new Node to the end of a list
        /// </summary>
        /// <param name="node">Header node, or the current node in the recursive iteration</param>
        /// <param name="toAdd">Node to add at the end of the list</param>
        /// <returns></returns>
        private static Node recAddLast(Node node, Node toAdd)
        {            
            if (node != null)
            {
                node.next=(recAddLast(node.next, toAdd));
                return node;
            }
            return toAdd;
        }

        /// <summary>
        /// Helper method for removeLast. Recursively finds the last node and removes it by setting its value to null;
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static Node recRemoveLast(Node node)
        {
            if (node.next != null)
            {
                node.next = (recRemoveLast(node.next));
                return node;
            }
            node = null;
            return node;
        }

        /// <summary>
        /// Removes the first Node of the list
        /// </summary>
        public void removeFirst()
        {
            head = head.next;
        }

        /// <summary>
        /// Removes the last node of the list
        /// </summary>
        public void removeLast()
        {
            recRemoveLast(head);
        }

        /// <summary>
        /// Prints the current contents of the list from the beginning to end
        /// </summary>
        public void print()
        {
            Node toPrE = head;
            while (toPrE != null)
            {
                System.Console.WriteLine(toPrE.element);
                toPrE = toPrE.next;
            }
        }
    }
}