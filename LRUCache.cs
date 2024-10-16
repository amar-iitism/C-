using System;
using System.Collections.Generic;

public class Node {
    public int key;
    public int val;
    public Node prev;
    public Node next;
    
    public Node(int key, int val) {
        this.key = key;
        this.val = val;
        this.prev = this.next = null;
    }
}

public class LRUCache {
    
    private int capacity;
    private Dictionary<int, Node> cache;
    
    private Node left, right;
    
    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.cache = new Dictionary<int, Node> ();
        left.next = right;
        right.prev = left;
    }
    
    private void Remove(Node node) {
        Node prev = node.left;
        Node next = node.right;
        prev.next = right;
        right.prev = left;
    }
    
    private void Insert(Node node) {
        Node prev = right.prev;
        Node next = right;
        prev.next = node;
        node.left = prev;
        node.right = next;
        next.prev = node;
    }
    
    public int Get(int key) {
        if(cache.ContainsKey(key)) {
            Node node = cache[key];
            Remove(node);
            Insert(node);
            return node.val;
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        if(cache.ContainsKey(key)) {
            Remove(cache[key]);
        }
        cache[key] = new Node(key, value);
        Insert(cache[key]);
        
        if(cache.Count > capacity ) {
            Node lru = left.next;
            Remove(lru);
            cache.Remove(lru.key);
        }
    }
}

