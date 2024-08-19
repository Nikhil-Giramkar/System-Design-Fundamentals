package implementation

import "fmt"

//We can use the List package for using doubley linked list - https://pkg.go.dev/container/list
//I created mine for practice purpose

type node struct {
	next *node
	prev *node
	key  string
}

func newNode(key string) *node {
	return &node{
		next: nil,
		prev: nil,
		key:  key,
	}
}

type doublyLinkedList struct {
	head *node
	tail *node
}

func (d *doublyLinkedList) detachNode(toBeRemoved *node) *node {
	if toBeRemoved == nil {
		return toBeRemoved
	}

	if toBeRemoved.prev != nil {
		toBeRemoved.prev.next = toBeRemoved.next
	} else {
		d.head = d.head.next
		d.head.prev = nil
	}

	if toBeRemoved.next != nil {
		toBeRemoved.next.prev = toBeRemoved.prev
	} else {
		d.tail = d.tail.prev
		d.tail.next = nil
	}

	return toBeRemoved
}

func (d *doublyLinkedList) attachNodeToEnd(toobeAttached *node) *node {
	if toobeAttached == nil {
		return toobeAttached
	}

	if d.head == nil {
		d.head = toobeAttached
		d.tail = d.head
		d.head.prev = nil
		d.tail.next = nil
	} else {
		d.tail.next = toobeAttached
		toobeAttached.prev = d.tail
		toobeAttached.next = nil
		d.tail = toobeAttached
	}
	return d.tail

}

func (d *doublyLinkedList) evict() *node {
	if d.head == nil {
		return d.head
	}
	toBeRemoved := d.head
	d.head = d.head.next
	d.head.prev = nil
	return toBeRemoved
}

type LRUCache struct {
	store    map[string]string
	dll      *doublyLinkedList
	nodeMap  map[string]node
	capacity int
}

// Get implements contracts.Cache.
func (c LRUCache) Get(key string) string {
	val, isFound := c.store[key]
	if !isFound {
		return "Not in Cache"
	}
	nodeForKey := c.nodeMap[key]
	removedNode := c.dll.detachNode(&nodeForKey)
	if removedNode.next != nil {
		//Add updated next and prev for adjacent node in nodeMap
		c.nodeMap[removedNode.next.key] = *removedNode.next
	}
	c.dll.attachNodeToEnd(&nodeForKey)
	c.nodeMap[key] = nodeForKey
	return val
}

// Initialize implements contracts.Cache.
func (c *LRUCache) initialize(capacity int) {
	c.capacity = capacity
	c.store = make(map[string]string)
	c.nodeMap = make(map[string]node)
	c.dll = &doublyLinkedList{
		head: nil,
		tail: nil,
	}
}

// Set implements contracts.Cache.
func (c LRUCache) Set(key string, value string) {
	if len(c.store) >= c.capacity {
		removedNode := c.dll.evict()
		if removedNode.next != nil {
			//Add updated next and prev for adjacent node in nodeMap
			c.nodeMap[removedNode.next.key] = *removedNode.next
		}
		delete(c.store, removedNode.key)
		delete(c.nodeMap, removedNode.key)
	}
	c.store[key] = value
	newNode := newNode(key)
	tailNode := c.dll.attachNodeToEnd(newNode)
	c.nodeMap[tailNode.key] = *tailNode

	if tailNode.prev != nil {
		//Add updated next and prev for adjacent node in nodeMap
		c.nodeMap[tailNode.prev.key] = *tailNode.prev
	}
}

func (c LRUCache) ShowCache() {
	if c.dll.head == nil {
		fmt.Println("Cache empty")
	}
	var cacheList string
	for curr := c.dll.head; curr != nil; curr = curr.next {
		cacheList += "-->" + curr.key
	}
	fmt.Println(cacheList)
}
